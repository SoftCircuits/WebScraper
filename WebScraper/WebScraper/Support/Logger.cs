using System;
using System.IO;

namespace WebScraper
{
    public class Logger
    {
        private string FileName;
        public bool SuppressLogging;

        public Logger(string filename)
        {
            FileName = filename;
            SuppressLogging = false;
        }

        public void Log(string text)
        {
            if (!SuppressLogging)
            {
                using (StreamWriter writer = File.AppendText(FileName))
                {
                    writer.Write(DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
                    writer.Write(" : ");
                    writer.WriteLine(text);
                }
            }
        }

        public void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }

        /// <summary>
        /// Logs a row of asterisks to help divide content
        /// </summary>
        public void LogDivider()
        {
            Log(new string('*', 80));
        }

        /// <summary>
        /// Clears any previous log data by deleting the log file.
        /// </summary>
        public void Clear()
        {
            File.Delete(FileName);
        }
    }
}
