using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class Logger
    {
        public static string LogFile
        {
            get
            {
                if (string.IsNullOrEmpty(logfile))
                    logfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "auto_logger.txt");
                return logfile;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    logfile = value;
                    if (!File.Exists(value))
                    {
                        File.Create(logfile);
                    }
                }
            }
        }

        private static string logfile { get; set; }

        public static string LogTime() { return $"====> {DateTime.Now.ToString("dd/ MM/yyyy , HH:mm:ss")}"; }
        public static void WriteLine(string caption, string message)
        {
            try
            {
                using (StreamWriter wt = new StreamWriter(LogFile, true))
                {
                    wt.WriteLine($"{LogTime()} {caption}: \n{message}");
                }
            }
            catch { }
        }

        public static void WriteLine(string caption, Exception exception)
        {
            try
            {
                using (StreamWriter wt = new StreamWriter(LogFile, true))
                {
                    wt.WriteLine($"{LogTime()} {caption}: \n{exception.ToString()}");
                }
            }
            catch { }
        }

        public static void WriteLine(string message)
        {
            try
            {
                using (StreamWriter wt = new StreamWriter(LogFile, true))
                {
                    wt.WriteLine($"{LogTime()} {message}");
                }
            }
            catch { }
        }
    }
}
