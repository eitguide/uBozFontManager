using FontManager.Model;
using FontManager.Utils;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.FontService
{
    public class FontInstallation
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern int RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                            string lpFileName);

        private RegistryKey registryKey;
        private FileManager fileManager;

        public FontInstallation()
        {
            registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts", true);
            fileManager = FileManager.GetInstance();
        }

        public List<string> GetListFontNameInstalled()
        {
            return registryKey.GetValueNames().ToList();
        }

        public List<FontInfo> GetListFontInfoInstalled()
        {
            List<string> fontNames = GetListFontNameInstalled();

            if (fontNames == null || fontNames.Count == 0)
                return null;



            List<FontInfo> infos = new List<FontInfo>();
            int count = fontNames.Count;
            for (int i = 0; i < count; i++)
            {
                object name = this.registryKey.GetValue(fontNames[i]);
                if (name != null)
                {
                    FontInfo info = new FontInfo();
                    info.NameInRegistry = fontNames[i];
                    info.FileNameInRegistry = name as string;
                    info.Disable = false;
                    info.Owner = FontOwner.System;
                    infos.Add(info);
                }
            }

            return infos;
        }

        public List<FontInfo> GetListFontUserFromFile()
        {
            string content = String.Empty;
            string path = Path.Combine(fileManager.GetCachedFolderProject(), "Cached.txt");

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    content = reader.ReadToEnd();
                }
            }

            List<FontInfo> info = JsonConvert.DeserializeObject<List<FontInfo>>(content);
            return info;
        }

        private bool CheckSupportFormat(string filename, FontFormatCollection formatCollectioin)
        {
            string extension = Path.GetExtension(filename);
            return formatCollectioin.ContainsExt(extension);
        }

        public List<FontInfo> GetListFontInfoInstalled(FontFormatCollection formatCollection)
        {

            List<String> fontNames = GetListFontNameInstalled();

            if (fontNames == null || fontNames.Count == 0)
                return null;

            for (int i = 0; i < fontNames.Count; i++)
            {
                string item = (string)this.registryKey.GetValue(fontNames[i]);
                if (!CheckSupportFormat(item, formatCollection))
                {
                    fontNames.Remove(fontNames[i]);
                }
            }

            List<FontInfo> infos = new List<FontInfo>();
            int count = fontNames.Count;
            for (int i = 0; i < count; i++)
            {
                object name = this.registryKey.GetValue(fontNames[i]);
                if (name != null)
                {
                    FontInfo info = new FontInfo();
                    info.NameInRegistry = fontNames[i];
                    info.FileNameInRegistry = name as string;
                    info.Disable = false;
                    infos.Add(info);
                }
            }

            return infos;

        }


        private bool CheckFontIntalledInRegistry(string fileNameNoExtenstoin, string fileName)
        {
            bool condi = this.registryKey.GetValueNames().Contains(fileNameNoExtenstoin);
            bool condi2 = (string)this.registryKey.GetValue(fileNameNoExtenstoin) == fileName;
            if (condi && condi2)
                return true;
            return false;
        }

        public InstallError InstallFont(string filepath)
        {
            string fileNoExtentsion = Path.GetFileNameWithoutExtension(filepath);
            string fileName = Path.GetFileName(filepath);

            string fontFolderSystem = fileManager.GetFontsSystemFolder();
            string destinationFontFile = Path.Combine(fontFolderSystem, fileName);

            bool exits = File.Exists(destinationFontFile);

            //if (exits || CheckFontIntalledInRegistry(fileNoExtentsion, fileName))
            //    return InstallError.INSTALL_DUPLICATE;

            fileManager.CopyFileTo(filepath, fontFolderSystem);
            this.registryKey.SetValue(fileNoExtentsion, fileName);

            return InstallError.INSTALL_SUSCESS;
        }

        public void RemoveFont(string fileName)
        {
            string fontFolderSystem = fileManager.GetFontsSystemFolder();
            string destinationFontFile = Path.Combine(fontFolderSystem, fileName);

            string key = Path.GetFileNameWithoutExtension(fileName);

            if (this.registryKey.GetValue(key) == null)
                return;

            this.registryKey.DeleteValue(key);

            if (File.Exists(destinationFontFile))
                fileManager.DeleteFile(destinationFontFile);
        }

        public void DisableFont(string nameInRegistry)
        {
            string fileName = (string)this.registryKey.GetValue(nameInRegistry);
            string fontFolderSystem = fileManager.GetFontsSystemFolder();
            string destinationFontFile = Path.Combine(fontFolderSystem, fileName);

            string key = Path.GetFileNameWithoutExtension(fileName);

            string disableFontPath = Path.Combine(fileManager.GetFontsFolderProject(), "Disable");

            if (!File.Exists(destinationFontFile))
                return;

            this.registryKey.DeleteValue(nameInRegistry);

            // fileManager.CopyFileTo(destinationFontFile, disableFontPath);

            fileManager.DeleteFile(destinationFontFile);
        }


        public bool DisableFont(FontInfo info)
        {
          
            string destinationFontFile = info.Location;

            string key = info.NameInRegistry;

            string disableFontPath = Path.Combine(fileManager.GetFontsFolderProject(), "Disable");

            if (!File.Exists(destinationFontFile))
                return false;

            fileManager.CopyFileTo(info.Location, fileManager.GetDisableFontProject());
            try {
                this.registryKey.DeleteValue(key);
            }
            catch (Exception ex)
            {
                Logger.d(ex.Message);
            }

            return true;
           
        }

    }


}
