using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Scripts
{
    public class RegisterScriptMenu
    {
        [DeclareAction("MyScriptActionWithMenu")]
        public void MyFunctionAsAction()
        {
            string strAction = "AutoTune";
            ActionManager oAMnr = new ActionManager();
            Eplan.EplApi.ApplicationFramework.Action oAction = oAMnr.FindAction(strAction);
            if (oAction != null)
            {
                ActionCallingContext ctx = new ActionCallingContext();
                bool bRet = oAction.Execute(ctx);
            }
        }

        [DeclareMenu]
        public void MenuFunction()
        {
            Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
            oMenu.AddMenuItem("AutoEPLAN", "MyScriptActionWithMenu");
        }
    }
}
