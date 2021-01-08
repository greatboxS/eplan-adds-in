using Eplan.EplApi.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPLAN.EplAddIn.AutoTune.Apps;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;

namespace EPLAN.EplAddIn.AutoDraw
{
    public class AutoDrawAction : IEplAction
    {
        private SymbolAutoDrawingForm DrawingForm { get; set; }
        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            if (DrawingForm == null || DrawingForm.IsDisposed)
                DrawingForm = new SymbolAutoDrawingForm();
            DrawingForm.Show();
            DrawingForm.BringToFront();
            return true;
        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {

        }

        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = GenGlobal.AutoDrawAction;
            Ordinal = 20;
            return true;
        }
    }


}
