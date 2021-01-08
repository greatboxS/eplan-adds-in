using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoCopy
{
    class Program
    {

        static string des = @"C:\Program Files\EPLAN\Platform\2.7.3\Bin";
        static string src = @"D:\vs_19\CSharp\2_Winform\Eplan\EplAutoTune\EplanAddInSln\EPLAN.EplAddIn.AutoTune\bin\Debug\EPLAN.EplAddIn.AutoTune.dll";
        static FileInfo SrcFile;
        static long lastModTimeTick = DateTime.Now.AddDays(-1).Ticks;
        static int copy_counter = 0;
        static bool AutoOpenApp = false;
        static Timer timer;

        static void Main(string[] args)
        {
            Config();
            Console.WriteLine("Start checking file");
        }

        private static void Config()
        {
            bool valid1 = false, valid2 = false;
            bool use_default = false;
            string s, d;

            Helper();

            while (!valid1 && !use_default)
            {
                Console.WriteLine("Add file to check:");
                s = Console.ReadLine();
                if (s == "default")
                {
                    use_default = true;
                    Console.WriteLine("Use default setting");
                    break;
                }

                src = s;
                valid1 = File.Exists(src);
            }

            while (!valid2 && !use_default)
            {
                Console.WriteLine("Add destination folder:");
                d = Console.ReadLine();
                des = d;
                valid2 = Directory.Exists(des);
            }

            SrcFile = new FileInfo(src);

            if (timer != null)
                timer.Dispose();

            timer = new Timer(CheckingTimerCallback, null, 0, 100);
            timer.InitializeLifetimeService();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "restart")
                {
                    Config();
                }

                if (cmd == "help")
                {
                    Helper();
                }

                if (cmd == "epl-auto")
                {
                    AutoOpenApp = true;
                }

                if (cmd == "epl-man")
                {
                    AutoOpenApp = false;
                }

                if (cmd == "epl-open")
                {
                    EplAutoProcess(EplProcess.OPEN);
                }

                if (cmd == "epl-close")
                {
                    EplAutoProcess(EplProcess.CLOSE);
                }

                if (cmd == "epl-restart")
                {
                    EplAutoProcess(EplProcess.RESTART);
                }

                if (cmd == "epl-refresh")
                {
                    EplAutoProcess(EplProcess.REFRESH);
                }

                if (cmd == "epl-kill")
                {
                    EplAutoProcess(EplProcess.FORCE_CLOSE);
                }

                if (cmd == "get-apps")
                {
                    var processList = System.Diagnostics.Process.GetProcesses();
                    foreach (var item in processList)
                    {
                        Console.WriteLine(item.ProcessName);
                    }
                }

                if (cmd == "clear")
                {
                    Console.Clear();
                }


            }
        }
        static void Helper()
        {
            Console.WriteLine("---------------------------AUTO COPY FILE HELPER---------------------------");
            Console.WriteLine("- \"default\" : setting default source file and des path.");
            Console.WriteLine("- \"restart\" : restart configuration.");
            Console.WriteLine("- \"clear\" : clear display.");
            Console.WriteLine("- \"epl-open\" : Open Eplan application.");
            Console.WriteLine("- \"epl-close\" : Close Eplan application.");
            Console.WriteLine("- \"epl-refresh\" : Refresh Eplan application.");
            Console.WriteLine("- \"epl-auto\" : Turn on auto restart Eplan application.");
            Console.WriteLine("- \"epl-man\" : Turn off auto restart Eplan application.");
            Console.WriteLine("---------------------------AUTO COPY FILE HELPER---------------------------");
            Console.WriteLine();
        }

        static void EplAutoProcess(EplProcess cmd)
        {
            List<Process> eplProcess = new List<Process>();
            var processList = Process.GetProcesses();

            eplProcess = processList.Where(i => i.ProcessName.IndexOf("eplan.exe") > -1).ToList();

            if (cmd == EplProcess.CLOSE) // off
            {
                if (eplProcess != null)
                {
                    foreach (var app in eplProcess)
                    {
                        app.CloseMainWindow();
                    }
                    Console.WriteLine("Close Eplan Application.");
                }
            }
            else if (cmd == EplProcess.REFRESH) // refresh
            {
                if (eplProcess != null)
                {
                    foreach (var app in eplProcess)
                    {
                        app.Refresh();
                    }
                    Console.WriteLine("Refresh Eplan Application.");
                }
                else
                {
                    Console.WriteLine("Eplan Application isn't opening");
                }
            }
            else if (cmd == EplProcess.OPEN)
            {
                foreach (var app in eplProcess)
                {
                    app.CloseMainWindow();
                }
                Process.Start("W3u.exe");
                Console.WriteLine("Open Eplan Application.");
            }
            else if (cmd == EplProcess.RESTART)
            {
                if (eplProcess != null)
                {
                    foreach (var app in eplProcess)
                    {
                        app.CloseMainWindow();
                    }
                    Console.WriteLine("Close Eplan Application.");
                }

                Process.Start("W3u.exe");
                Console.WriteLine("Restart Eplan Application.");

            }
            else if (cmd == EplProcess.FORCE_CLOSE) // on
            {
                if (eplProcess != null)
                {
                    foreach (var app in eplProcess)
                    {
                        app.Kill();
                    }
                }
            }
        }

        private static void CheckingTimerCallback(object state)
        {
            try
            {
                if (!File.Exists(src))
                    return;

                SrcFile = new FileInfo(src);

                //Console.WriteLine($"Tick1 {SrcFile.LastAccessTime.Ticks}, Tick2 {lastModTimeTick}");
                if (SrcFile.CreationTime.Ticks > lastModTimeTick)
                {
                    lastModTimeTick = SrcFile.CreationTime.Ticks;
                    string fname = des + src.Substring(src.LastIndexOf("\\"));
                    File.Copy(src, fname, true);
                    Console.WriteLine($"Copy time:{DateTime.Now}  ({++copy_counter})\r\n file name: {fname}");

                    if (AutoOpenApp)
                        EplAutoProcess(EplProcess.RESTART);
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        public enum EplProcess
        {
            OPEN,
            CLOSE,
            REFRESH,
            FORCE_CLOSE,
            RESTART,
        }
    }

}
