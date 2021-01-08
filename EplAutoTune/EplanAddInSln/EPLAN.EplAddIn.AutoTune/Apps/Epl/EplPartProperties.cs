using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.MasterData;


namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplPartProperties
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }
        public string Characteristic { get; set; }  //
        public string Supplier { get; set; }        // represent for origin
        public string Manufacturer { get; set; }
        public string PartGroup { get; set; }       // represent for Panel Name
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Macro { get; set; }
        public string Symbol { get; set; }
        public int TotalFreeProperty { get; set; }

        public string Voltage { get; set; }        // L
        public string VoltageType { get; set; }
        public string Current { get; set; }
        public string TrippingCurrent { get; set; }
        public string ConnectionPointCrossSection { get; set; }
        public string SwitchingCapacity { get; set; }
        public string MaxPowerDissipation { get; set; }     // useless power

        public List<PartFreeProperties> PartFreeProperties { get; set; }

        public EplPartProperties()
        {
            PartFreeProperties = new List<PartFreeProperties>();
            ProductTopGroup = MDPartsDatabaseItem.Enums.ProductTopGroup.Electric;
            ProductGroup = MDPartsDatabaseItem.Enums.ProductGroup.Common;
            ProductSubGroup = MDPartsDatabaseItem.Enums.ProductSubGroup.Common;
        }

        public MDPartsDatabaseItem.Enums.ProductTopGroup ProductTopGroup { get; set; }
        public MDPartsDatabaseItem.Enums.ProductGroup ProductGroup { get; set; }
        public MDPartsDatabaseItem.Enums.ProductSubGroup ProductSubGroup { get; set; }
    }
}
