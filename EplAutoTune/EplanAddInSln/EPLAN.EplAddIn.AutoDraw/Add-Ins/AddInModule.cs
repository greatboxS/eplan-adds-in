using Eplan.EplApi.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoDraw
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
            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            bLoadOnStart = true;
            Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
            oMenu.AddMainMenu("Add-Ins", Eplan.EplApi.Gui.Menu.MainMenuName.eMainMenuHelp,
                "Auto Drawing", "AutoDrawing", "C# custom add-in tool", 1);
            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }
    }
}
