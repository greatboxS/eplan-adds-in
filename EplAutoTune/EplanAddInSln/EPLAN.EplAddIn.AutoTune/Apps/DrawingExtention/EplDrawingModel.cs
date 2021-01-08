using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class DrawDisplayText
    {
        public bool DisplayText { get; set; } = true;
        public bool FunctionText { get; set; } = true;
        public bool EngravingText { get; set; } = true;
        public bool Characteristic { get; set; } = true;
        public bool ConnectionPoint { get; set; } = true;
        public bool MountingSite { get; set; } = true;
        public string ModelName { get; set; }
    }

    public class DrawLayoutModel : Outline
    {
        public bool[] Templates { get; set; } = new bool[8];
    }

    public class DrawPinModel : Outline
    {
        public EplDrawPinFunction Function { get; set; }
        public int PinGroup { get; set; }
        public string InputRange { get; set; }
        public string FunctionDescription { get; set; }
        public string Number { get; set; }
        public int PinDistance { get; set; }
        public EplDrawPosition LocationSide { get; set; }
        public int PolylineOffset { get; set; } = 3;
    }

    public class EplDrawSymbolModel
    {
        public DrawLayoutModel MainLayout { get; set; }
        public DrawDisplayText DrawDisplayText { get; set; }
        public List<DrawPinModel> PinCollections { get; set; }

        public int PinGroupIndex
        {
            get
            {
                return PinCollections.Count;
            }
        }

        public DrawPinModel GetPinGroupItem(int index)
        {
            return PinCollections[index];
        }

        public DrawPinModel GetPinGroupItem()
        {
            return PinCollections.Last();
        }

        public void AddPinGroup(DrawPinModel pin)
        {
            if (PinCollections == null)
            {
                PinCollections = new List<DrawPinModel>();
            }

            PinCollections.Add(pin);
        }

        public bool RemotePinGroup(int id)
        {
            try
            {
                var pin = PinCollections.Where(i => i.PinGroup == id).First();

                PinCollections.RemoveAt(id);
                int index = 0;
                foreach (var item in PinCollections)
                {
                    item.PinGroup = index;
                    index++;
                }
            }
            catch { return false; }

            return true;
        }

        public EplDrawSymbolModel()
        {
            MainLayout = new DrawLayoutModel();
            DrawDisplayText = new DrawDisplayText();
            PinCollections = new List<DrawPinModel>();
        }
    }

    public class Outline
    {
        public string Shape { get; set; } = "Rectangle";
        public int DimensionX { get; set; } = 20;
        public int DimensionY { get; set; } = 30;
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public string ColorText { get; set; }
        public string WidthText { get; set; }
        public bool Fill { get; set; }
        public Font Font { get; set; }
        public short ColorId
        {
            get
            {
                return EplDrawingExtention.GetColorId(ColorText);
            }
        }
        public double OutlineWidthVal
        {
            get
            {
                try
                {
                    return double.Parse(WidthText);
                }
                catch (Exception ex)
                {
                    Logger.WriteLine("OutlineWidthVal", ex);
                    return 0.1;
                }
            }
        }
        public double Angle { get; set; }
        public short StyleId { get; set; }
    }
}
