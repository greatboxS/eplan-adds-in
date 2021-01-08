using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps.Modules
{
    public class AppConfig
    {
        public static string GenFolder = "autoepl_config";
        public static string SourceFolder = "autoepl_src";
        public static string DesFolder = "autoepl_des";


        public bool SingleLine { get; set; }
        public bool Multiline { get; set; }
        public string DesProject { get; set; }
        public string BasePath { get; set; }
        public string GenFile { get; set; }
        public string GenDesFile { get; set; }
    }
}
