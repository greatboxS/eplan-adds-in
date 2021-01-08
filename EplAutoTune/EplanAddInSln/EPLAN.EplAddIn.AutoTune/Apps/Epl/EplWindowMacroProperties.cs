using Eplan.EplApi.DataModel.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplWindowMacroProperties :EplMacroProperties
    {
        public WindowMacro.Enums.RepresentationType representType = WindowMacro.Enums.RepresentationType.Graphics;
        public WindowMacro.Enums.NumerationMode NumerationMode { get; set; } = WindowMacro.Enums.NumerationMode.Number;
    }
}
