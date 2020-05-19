using SoftCircuits.IniFileParser;
using System;
using System.IO;

namespace WebScraper
{
    public static class Settings
    {
        public static string Path { get; private set; }
        public static bool AutoLoad { get; set; }
        public static bool LogResults { get; set; }
        public static bool DeleteLogBeforeRun { get; set; }
        public static bool LoadResultsAfterRun { get; set; }
        public static bool WriteColumnHeaders { get; set; }
        public static string LastFile { get; set; }

        static Settings()
        {
            Path = DataFiles.GetApplicationDataFile("ini");
            AutoLoad = false;
            LogResults = true;
            DeleteLogBeforeRun = true;
            LoadResultsAfterRun = false;
            WriteColumnHeaders = false;
            LastFile = null;
        }

        public static void Load()
        {
            try
            {
                if (File.Exists(Path))
                {
                    IniFile iniFile = new IniFile();
                    iniFile.Load(Path);
                    AutoLoad = iniFile.GetSetting("General", "AutoLoad", false);
                    LogResults = iniFile.GetSetting("General", "LogResults", true);
                    DeleteLogBeforeRun = iniFile.GetSetting("General", "DeleteLogBeforeRun", true);
                    LoadResultsAfterRun = iniFile.GetSetting("General", "LoadResultsAfterRun", false);
                    WriteColumnHeaders = iniFile.GetSetting("General", "WriteColumnHeaders", false);
                    LastFile = iniFile.GetSetting("General", "LastFile");
                    if (string.IsNullOrWhiteSpace(LastFile))
                        LastFile = null;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError("Error loading settings file");
            }
        }

        public static void Save()
        {
            try
            {
                IniFile iniFile = new IniFile();
                iniFile.SetSetting("General", "AutoLoad", AutoLoad);
                iniFile.SetSetting("General", "LogResults", LogResults);
                iniFile.SetSetting("General", "DeleteLogBeforeRun", DeleteLogBeforeRun);
                iniFile.SetSetting("General", "LoadResultsAfterRun", LoadResultsAfterRun);
                iniFile.SetSetting("General", "WriteColumnHeaders", WriteColumnHeaders);
                iniFile.SetSetting("General", "LastFile", LastFile ?? string.Empty);
                iniFile.Save(Path);
            }
            catch (Exception ex)
            {
                ex.ShowError("Error saving settings file");
            }
        }
    }
}
