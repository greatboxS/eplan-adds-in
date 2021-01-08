using Eplan.EplApi.ApplicationFramework;
using EPLAN.EplAddIn.AutoTune.Apps;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune
{
    public class AutoTuneAction : IEplAction
    {
        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            if (GenGlobal.AutoTuneApp == null || GenGlobal.AutoTuneApp.IsDisposed)
                GenGlobal.AutoTuneApp = new AutoTuneApp();

            GenGlobal.AutoTuneApp.AutoTuneLoading();
            GenGlobal.AutoTuneApp.Show();
            GenGlobal.AutoTuneApp.BringToFront();
            return true;
        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {

        }

        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = GenGlobal.Action;
            Ordinal = 20;
            return true;
        }
    }

    
}
