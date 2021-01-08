using Eplan.EplApi.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPLAN.EplAddIn.AutoTune.Apps;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;

namespace EPLAN.EplAddIn.PartImportAction
{
    public class PartImportAction : IEplAction
    {
        private ImportPartForm ImportPartForm { get; set; }
        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            if (ImportPartForm == null || ImportPartForm.IsDisposed)
                ImportPartForm = new ImportPartForm();
            ImportPartForm.Show();
            ImportPartForm.BringToFront();
            return true;
        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {

        }

        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = GenGlobal.ImportPartAction;
            Ordinal = 20;
            return true;
        }
    }


}
