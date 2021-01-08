using Eplan.EplApi.ApplicationFramework;
using EPLAN.EplAddIn.AutoTune.Apps;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune
{
    public class AddInModule : IEplAddIn
    {
        public bool OnExit()
        {
            return true;
        }

        public bool OnInit()
        {
            return true;
        }

        /// <summary>
        /// This function is called by the framework of EPLAN, when the framework already has initialized its
        /// graphical user interface (GUI) and the add-in can start to modify the GUI.
        /// The function only is called, if the add-in is loaded on system-startup.
        /// </summary>
        /// <returns>true, if function succeeds</returns>
        public bool OnInitGui()
        {
            Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
            var id = oMenu.AddMainMenu("Add-Ins", Eplan.EplApi.Gui.Menu.MainMenuName.eMainMenuHelp,
                "Auto EPLAN", GenGlobal.Action, "C# custom add-in tool", 1);
            oMenu.AddMenuItem("Auto drawing", GenGlobal.AutoDrawAction, "Auto Drawing", id, 1, false, false);
            oMenu.AddMenuItem("Import parts", GenGlobal.ImportPartAction, "Import parts", id, 1, false, false);
            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            bLoadOnStart = true;
            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }
    }
}
