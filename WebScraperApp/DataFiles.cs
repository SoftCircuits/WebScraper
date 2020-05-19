using System;
using System.IO;

namespace WebScraper
{
    public static class DataFiles
    {
        public static readonly string AppName = "WebScraper";

        /// <summary>
        /// Returns the application data folder and ensures that folder exists.
        /// </summary>
        public static string GetDataFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, AppName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// Returns the full path of the given file name in the application data folder.
        /// </summary>
        /// <param name="fileName">File name to append to the application data folder.</param>
        public static string GetDataFile(string fileName) => Path.Combine(GetDataFolder(), fileName);

        /// <summary>
        /// Returns the full path of a file name in the application data folder with the
        /// same base name as <paramref name="fileName"/> and the specified extension.
        /// <param name="fileName">The file name from which to extract the base name.</param>
        /// <param name="extension">The new file name extension.</param>
        /// <returns></returns>
        public static string GetDataFile(string fileName, string extension)
        {
            fileName = string.IsNullOrWhiteSpace(fileName) ?
                AppName :
                Path.GetFileNameWithoutExtension(fileName);
            return GetDataFile($"{fileName}.{extension}");
        }

        /// <summary>
        /// Returns the full path of a file name in the application data folder, with the
        /// application base name, and the given extension.
        /// </summary>
        /// <param name="extension">The file extension without the dot.</param>
        public static string GetApplicationDataFile(string extension) => GetDataFile($"{AppName}.{extension}");
    }
}
