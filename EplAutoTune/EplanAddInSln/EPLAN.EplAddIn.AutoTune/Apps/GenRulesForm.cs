using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public partial class GenRulesForm : Form
    {
        public GenRulesForm()
        {
            InitializeComponent();

            if(!GenGlobal.GetSetting(GenGlobal.AutoTuneSettings.GEN_RULES))
            {
                GenGlobal.GenerationRules = new GenerationRules();
                GenGlobal.SaveSetting(GenGlobal.AutoTuneSettings.GEN_RULES);
            }

            GenerationRules = GenGlobal.GenerationRules;
            GenRulesProp.SelectedObject = GenerationRules;
        }

        private GenerationRules GenerationRules;

        private void GenRulesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GenGlobal.SaveSetting(GenGlobal.AutoTuneSettings.GEN_RULES);
        }
    }
}
