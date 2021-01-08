using Eplan.EplApi.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps.Modules
{
    public class GenGlobal
    {
        public static AutoTuneApp AutoTuneApp;
        public static AppConfig AppConfig = new AppConfig();
        public static GenerationRules GenerationRules = new GenerationRules();
        public static GenRulesForm GenRulesForm = new GenRulesForm();
        public static Project CurrentProject;
        public static ProjectManager ProjectManager { get; set; }
        public static Page ActivePage  = null;
        public static bool EnableDebug { get; internal set; } = true;
        public static string Action = "AutoEPlan";
        public static string AutoDrawAction = "AutoDrawing";
        public static string ImportPartAction = "ImportPart";

        public static bool GetSetting(AutoTuneSettings autoTuneSettings)
        {
            try
            {
                switch (autoTuneSettings)
                {
                    case AutoTuneSettings.GEN_RULES:
                        GenerationRules = JsonConvert.DeserializeObject<GenerationRules>(AutoTuneSetting.Default.GenRules);
                        if (GenerationRules == null)
                        {
                            GenerationRules = new GenerationRules();
                            SaveSetting(AutoTuneSettings.GEN_RULES);
                        }
                        break;

                    case AutoTuneSettings.OLD_GEN_CONFIG:
                        AppConfig = JsonConvert.DeserializeObject<AppConfig>(AutoTuneSetting.Default.GenConfig);
                        if (AppConfig == null)
                        {
                            AppConfig = new AppConfig();
                            SaveSetting(AutoTuneSettings.OLD_GEN_CONFIG);
                        }

                        break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); return false; }
        }

        public static void SaveSetting(AutoTuneSettings autoTuneSettings)
        {
            switch (autoTuneSettings)
            {
                case AutoTuneSettings.GEN_RULES:
                    AutoTuneSetting.Default.GenRules = JsonConvert.SerializeObject(GenerationRules);
                    AutoTuneSetting.Default.Save();
                    break;
                case AutoTuneSettings.OLD_GEN_CONFIG:
                    AutoTuneSetting.Default.GenConfig = JsonConvert.SerializeObject(AppConfig);
                    AutoTuneSetting.Default.Save();
                    break;
                default:
                    break;
            }
        }

        public enum AutoTuneSettings
        {
            GEN_RULES,
            OLD_GEN_CONFIG,
        }
    }
}
