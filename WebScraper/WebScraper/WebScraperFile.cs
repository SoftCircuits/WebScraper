using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public static class WebScraperFile
    {
        public static string GetCsvPath(string dataFile)
        {
            if (string.IsNullOrWhiteSpace(dataFile))
                dataFile = "WebScraper";
            return Path.Combine(GetMyDocumentsPath(), Path.GetFileNameWithoutExtension(dataFile)) + ".csv";
        }

        public static string LogPath => Path.Combine(GetMyDocumentsPath(), "WebScraper.log");

        public static string SettingsPath => Path.Combine(GetMyDocumentsPath(), "WebScraper.ini");

        /// <summary>
        /// Returns the application's MyDocuments folder. The folder is created if needed.
        /// </summary>
        public static string GetMyDocumentsPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "WebScraper");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
