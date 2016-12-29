using FontManager.FontService;
using FontManager.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharpNghia;

namespace FontManager
{
    public class FileManager
    {
        private static FileManager mInstance;
        private FontFormatCollection FontFormatCollection { get; set; }

        private FileManager()
        {

        }

        public static FileManager GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new FileManager();
            }
            return mInstance;
        }

        /// <summary>
        /// Get Operation System Installed Path
        /// </summary>
        /// <returns>Path of OS</returns>
        public String GetPathInstalledOS()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }

        /// <summary>
        /// Get Fonts System Folder
        /// </summary>
        /// <returns>Path of Font System Folder</returns>
        public String GetFontsSystemFolder()
        {
            return Environment.GetFolderPath((Environment.SpecialFolder.Fonts));
        }

        /// <summary>
        /// Move file to Destination path
        /// </summary>
        /// <param name="file">FileInfo object</param>
        /// <param name="destination">Path you want copy to</param>
        public void MoveFile(FileInfo file, String destination)
        {
            if (!String.IsNullOrEmpty(destination.Trim()))
                file.MoveTo(@destination + file.Name);
        }

        /// <summary>
        /// Move files to Destinaion Path
        /// </summary>
        /// <param name="listFile">List FileInfo</param>
        /// <param name="destination">Path Destination</param>
        public void MoveFiles(IEnumerable<FileInfo> listFile, String destination)
        {
            if (!String.IsNullOrEmpty(destination.Trim()))
            {
                foreach (FileInfo item in listFile)
                {
                    item.MoveTo(@destination + item.Name);

                }
            }
        }


        /// <summary>
        /// Get Destination path
        /// </summary>
        /// <param name="fileSourceInput">Input Path</param>
        /// <param name="fileFolderDestinaion">Folder Destination</param>
        /// <returns>Path after</returns>
        public String GetDestinationPath(String fileSourceInput, String fileFolderDestinaion)
        {
            if (CheckValidInput(fileSourceInput, fileFolderDestinaion))
                return Path.Combine(fileFolderDestinaion, Path.GetFileName(fileSourceInput));
            return String.Empty;
        }


        /// <summary>
        /// Move File to Destination Path
        /// </summary>
        /// <param name="filePath">Input File Path</param>
        /// <param name="destinationPath">Destination Path</param>
        public void MoveFile(String filePath, String destinationPath)
        {
            if (CheckValidInput(filePath, destinationPath))
            {
                string des = GetDestinationPath(filePath, destinationPath);
                File.Move(filePath, des);
            }
        }

        public void MoveFiles(IEnumerable<String> listFilePath, String destinationPath)
        {
            if (listFilePath != null && !String.IsNullOrEmpty(destinationPath))
            {
                foreach (String item in listFilePath)
                {
                    File.Move(item, GetDestinationPath(item, destinationPath));
                }
            }
        }

        public void CopyFileTo(FileInfo fileInfo, String destination, bool overrite = true)
        {
            if (CheckInValidInput(fileInfo, destination))
            {
                fileInfo.CopyTo(GetDestinationPath(fileInfo.FullName, destination));
            }
        }

        public void CopyFilesTo(IEnumerable<FileInfo> filesInfo, String destination, bool overwrite = true)
        {
            try
            {
                foreach (FileInfo item in filesInfo)
                {
                    item.CopyTo(destination, overwrite);
                }
            }
            catch (ArgumentException)
            {

            }
            catch (NotSupportedException)
            {

            }
        }

        private bool CheckInValidInput(FileInfo fileInfo, String destination)
        {
            return fileInfo != null && !String.IsNullOrEmpty(destination.Trim());
        }

        private bool CheckValidInput(String a, String b)
        {
            return (!String.IsNullOrEmpty(a.Trim()) && !String.IsNullOrEmpty(b.Trim()));
        }

        public void CopyFileTo(String filePath, String destinationPath)
        {
            if (CheckValidInput(filePath, destinationPath))
            {
                String destinationFile = GetDestinationPath(filePath, destinationPath);
                if (!File.Exists(destinationFile))
                    File.Copy(filePath, destinationFile);
            }
        }

        private bool CheckValidInput(IEnumerable<String> listPathFile, String destination)
        {
            return (listPathFile != null && !String.IsNullOrEmpty(destination.Trim()));
        }

        public void CopyFilesTo(IEnumerable<String> listPathFiles, String destination)
        {
            if (CheckValidInput(listPathFiles, destination))
            {
                foreach (String item in listPathFiles)
                {
                    File.Copy(item, GetDestinationPath(item, destination));
                }
            }
        }

        /// <summary>
        /// Get Lists File with FontFormatCollection
        /// </summary>
        /// <param name="collection">FontFormatCollection</param>
        /// <returns>List FontInfo</returns>
        public IEnumerable<FileInfo> GetListFile(FontFormatCollection collection)
        {
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo fontFolder = new DirectoryInfo(GetFontsSystemFolder());
            foreach (var file in fontFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly))
            {
                if (collection.ContainsExt(file.Extension))
                {
                    files.Add(file);
                }
            }
            return files;
        }

        /// <summary>
        /// Get All Files in Path Folder
        /// </summary>
        /// <param name="path">Folder</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetListFiles(String pathFolder)
        {
            if (Directory.Exists(pathFolder))
            {
                DirectoryInfo info = new DirectoryInfo(pathFolder);
                return info == null ? null : info.GetFiles("*.*").ToList();
            }

            return null;
        }

        public bool Exist(String path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(String filePath)
        {
            if (!String.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void DeleteFile(FileInfo info)
        {
            if(info != null)
            {
                info.Delete();
            }
        }

        public String GetCurrentFolderWorking()
        {
            return Environment.CurrentDirectory;
        }

        public String GetFontsFolderProject()
        {
            //return Path.Combine(Directory.GetParent(Directory.GetParent(GetCurrentFolderWorking()).FullName).FullName, "Fonts");
            return Path.Combine(GetCurrentFolderWorking(), "Fonts");
        } 

        public string GetCachedFolderProject()
        {
            //return Path.Combine(Directory.GetParent(Directory.GetParent(GetCurrentFolderWorking()).FullName).FullName, "Cached");
            return Path.Combine(GetCurrentFolderWorking(), "Cached");
        }

        public string GetDisableFontProject()
        {
            return Path.Combine(GetFontsFolderProject(), "Disable");
        }

        public void SaveFontData(List<FontInfo> fontInfo)
        {
            if (fontInfo == null)
                return;
            string fileName = Path.Combine(GetCachedFolderProject(), "FontData.txt");
            //using(FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            //{
            //    using(StreamWriter writer = new StreamWriter(fileStream))
            //    {
            //        string json = JsonConvert.SerializeObject(fontInfo);
            //        writer.Write(@json);
            //    }
            //}

            string json = JsonConvert.SerializeObject(fontInfo);
            File.WriteAllBytes(fileName, System.Text.Encoding.ASCII.GetBytes(json));
        }
        
        public void SaveCacheFile(List<FontInfo> listAdded)
        {

            using (FileStream fileStream = new FileStream(Path.Combine(GetCachedFolderProject(), "Cached.txt"),
                FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(JsonConvert.SerializeObject(listAdded));
                }

            }
        }

        public List<FontInfo> GetFontDataCached()
        {
            string fileName = Path.Combine(GetCachedFolderProject(), "FontData.txt");
            string json = string.Empty;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    json = reader.ReadToEnd();
                }
            }

            if (json != string.Empty)
                return JsonConvert.DeserializeObject<List<FontInfo>>(json);

            return null;
        }

        public static void LoadSubsetDataFromFile()
        {
            string fileName = Path.Combine(FileManager.GetInstance().GetCachedFolderProject(), "Subset.txt");
            string content = string.Empty;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    content = reader.ReadToEnd();
                }
            }

            //int convert = int.Parse("0080", System.Globalization.NumberStyles.HexNumber);

            if (string.Empty != content)
            {
                SharedData.SharedData.Subsets = JsonConvert.DeserializeObject<List<Subset>>(content);
                SharedData.SharedData.IsSubsetsLoaded = true;
            }
        }
    }
}
