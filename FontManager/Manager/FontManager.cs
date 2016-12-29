using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontManager.FontService;
using System.Runtime.InteropServices;
using System.ComponentModel;
using FontManager.FontService;

namespace FontManager.Manager
{
    public class FontManager
    {
        private static FontManager mInstance;
        private FileManager mFileInstance = FileManager.GetInstance();
        private static string CurentFontsFolder = Environment.CurrentDirectory;
        private FontFormatCollection fontCollection = new FontFormatCollection();

        private FontManager()
        {
           
        }

        public static FontManager GetInstance()
        {
            if(mInstance == null)
            {
                mInstance = new FontManager();
                
            }
            return mInstance;
        }

        public void ActiveFont(String filePath)
        {
            int error = -1;
           int result = FontInstallation.AddFontResource(filePath);

            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                Console.WriteLine(new Win32Exception(error).Message);
            }
            else
            {
                Console.WriteLine((result == 0) ? "Font is already installed." :
                                                  "Font installed successfully.");
            }
        }

        public void ActiveFont(FileInfo info)
        {
            FontInstallation.AddFontResource(info.FullName);
        }

        public void DisableFont(FileInfo info)
        {
            
        }

        public void DisableFont(String filePath)
        {
            FontInstallation.RemoveFontResource(filePath);
        }

        public void AddFontFormat(FontType type)
        {
            fontCollection.Add(type);
        }

        public FontFormatCollection GetFontFormatCollection()
        {
            return this.fontCollection;
        }

        public IEnumerable<FileInfo> GetAllFontsIntalled()
        {
          return mFileInstance.GetListFile(fontCollection);
        }
    }
}
