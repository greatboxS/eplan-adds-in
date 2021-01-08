using Eplan.EplApi.DataModel.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplPageMacroProperties :EplMacroProperties
    {
        public bool Overwrite { get; set; }
        public PageMacro.Enums.NumerationMode NumerationMode { get; set; } = PageMacro.Enums.NumerationMode.Number;
    }
}
