using Eplan.EplApi.DataModel.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplMacroProperties
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int Quantity { get; set; }
        public int Variant { get; set; } = 0;
        public double Tollerence { get; set; }

        public Eplan.EplApi.Base.PointD Position  = new Eplan.EplApi.Base.PointD(0, 0);
        public Eplan.EplApi.HEServices.Insert.MoveKind MoveKind { get; set; } = Eplan.EplApi.HEServices.Insert.MoveKind.Relative;

        public T As<T>()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);

            if (type.BaseType != null)
            {
                var properties = type.BaseType.GetProperties();
                foreach (var property in properties)
                    if (property.CanWrite)
                        property.SetValue(instance, property.GetValue(this, null), null);
            }

            return (T)instance;
        }
    }
}
