using Eplan.EplApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplObjectDisplay: EplSymbolDefinition
    {
        public string DisplayText { get; set; }
        public string FunctionText { get; set; }
        public string Characteristics { get; set; }
        public string EngravingText { get; set; }
        public string Description { get; set; }
        public string MountingSite { get; set; }
        public string[] ConnectionDesignations { get; set; }
        public string[] ConnectionPointDescription { get; set; }
    }

    public class EplSymbolDefinition
    {
        public string SymbolName { get; set; }
        public int SymbolNumber { get; set; }
        public string SymbolLibraryName { get; set; }
        public string SymbolDescription { get; set; }
        public string PartName { get; set; }
        public int SymbolVariant { get; set; }
        public PointD Location { get; set; }
    }
}
