using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.DataModel.Graphics;
using Newtonsoft.Json;
using Eplan.EplApi.HEServices;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplDrawingExtention
    {
        public static void Rectangle(ref Page refPage, PointD location, bool fill, double width, double height,
            double pen_width, short colorId, short styleId)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Create(refPage);
            rectangle.Location = location;
            rectangle.IsSurfaceFilled = fill;
            rectangle.Pen.Width = pen_width;
            rectangle.Pen.StyleId = styleId;
            rectangle.Pen.ColorId = colorId;
            rectangle.SetArea(location, new PointD(location.X + width, location.Y + height));
        }

        public static void Rectangle(ref Page refPage, Outline outline)
        {
            Logger.WriteLine(JsonConvert.SerializeObject(outline));
            Rectangle rectangle = new Rectangle();
            rectangle.Create(refPage);
            rectangle.IsSurfaceFilled = outline.Fill;
            rectangle.Pen.Width = outline.OutlineWidthVal;
            rectangle.Pen.StyleId = outline.StyleId;
            rectangle.Pen.ColorId = outline.ColorId;
            rectangle.Angle = outline.Angle;
            PointD Location = new PointD(outline.PositionX, outline.PositionY);
            rectangle.Location = Location;
            rectangle.SetArea(Location, new PointD(Location.X + outline.DimensionX, Location.Y + outline.DimensionY));
        }

        public static void Rectangle(ref Page refPage, Outline outline, PointD location)
        {
            Logger.WriteLine(JsonConvert.SerializeObject(outline));
            Rectangle rectangle = new Rectangle();
            rectangle.Create(refPage);
            rectangle.IsSurfaceFilled = outline.Fill;
            rectangle.Pen.Width = outline.OutlineWidthVal;
            rectangle.Pen.StyleId = outline.StyleId;
            rectangle.Pen.ColorId = outline.ColorId;
            rectangle.Angle = outline.Angle;
            rectangle.Location = location;
            rectangle.SetArea(location, new PointD(location.X + outline.DimensionX, location.Y + outline.DimensionY));
        }

        public PointD BasePosition { get; set; }

        public void DrawPinOutline(ref Page refPage, string shape, PointD location, bool fill, double width, double height,
            double pen_width, short colorId, short styleId)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Create(refPage);
            rectangle.IsSurfaceFilled = fill;
            rectangle.Pen.Width = pen_width;
            rectangle.Pen.StyleId = styleId;
            rectangle.Pen.ColorId = colorId;
            rectangle.Location = new PointD(location.X + BasePosition.X, location.Y + BasePosition.Y);
            rectangle.SetArea(location, new PointD(location.X + width, location.Y + height));
        }

        public void DrawPinOutline(ref Page refPage, DrawPinModel pinModel, PointD baselocation)
        {
            Logger.WriteLine(JsonConvert.SerializeObject(pinModel));
            PointD location = new PointD(pinModel.PositionX + baselocation.X, pinModel.PositionY + baselocation.Y);
            Rectangle rectangle = new Rectangle();
            rectangle.Create(refPage);
            rectangle.IsSurfaceFilled = pinModel.Fill;
            rectangle.Pen.Width = pinModel.OutlineWidthVal;
            rectangle.Pen.StyleId = pinModel.StyleId;
            rectangle.Pen.ColorId = pinModel.ColorId;
            rectangle.Location = location;
            rectangle.SetArea(location, new PointD(location.X + pinModel.DimensionX, location.Y + pinModel.DimensionY));
        }

        public void DrawPinOutline(ref Page refPage, DrawPinModel pinModel)
        {
            DrawPinOutline(ref refPage, pinModel, BasePosition);
        }



        public void DrawPolyline(ref Page refPage, DrawPinModel pinModel)
        {
            Logger.WriteLine(JsonConvert.SerializeObject(pinModel));

            string symbolName = "";
            PointD[] PinTextPos = new PointD[2];
            PointD DescriptionTextPos = new PointD();
            PointD[] PinOutline = new PointD[5];
            PointD[] points = new PointD[10];
            int index = 0;

            string[] pinDefs = pinModel.Number.Split(new string[] { "(", ")" }, StringSplitOptions.None);
            string[] pinName = new string[pinDefs.Length];
            string[] pinNum = new string[pinDefs.Length];
            string[] pinDescription = pinModel.FunctionDescription.Split(new string[] { "," }, StringSplitOptions.None);

            foreach (var item in pinDefs)
            {
                string[] temp = item.Split(new string[] { "," }, StringSplitOptions.None);
                if (temp.Length >= 2)
                {
                    pinName[index] = temp[1];
                    pinNum[index] = temp[0];
                    index++;
                }
            }

            int pinMarkSize = (int)pinModel.Font.Size;
            int offset = Math.Max(pinModel.DimensionX, pinModel.DimensionY) + pinMarkSize;
            offset = offset + pinModel.PolylineOffset;

            switch (pinModel.LocationSide)
            {
                case EplDrawPosition.Left:
                    symbolName = "LeftConnectionPoint";
                    PinOutline[0] = new PointD(pinModel.PositionX + pinMarkSize, pinModel.PositionY);
                    PinOutline[1] = new PointD(pinModel.PositionX + pinMarkSize, pinModel.PositionY + pinModel.PinDistance);

                    points[0] = new PointD(PinOutline[0].X, PinOutline[0].Y + pinModel.DimensionY / 2);
                    points[1] = new PointD(PinOutline[0].X + offset, PinOutline[0].Y + pinModel.DimensionY / 2);
                    points[2] = new PointD(PinOutline[0].X + offset, PinOutline[0].Y + pinModel.PinDistance - pinModel.DimensionY / 2); ;
                    points[3] = new PointD(PinOutline[0].X, PinOutline[0].Y + pinModel.PinDistance - pinModel.DimensionY / 2);

                    PinTextPos[0] = new PointD(points[0].X, points[0].Y + offset);
                    PinTextPos[1] = new PointD(points[3].X, points[0].Y - offset);

                    DescriptionTextPos = new PointD(points[0].X + 5, points[0].Y + pinModel.PinDistance / 2);
                    break;
                case EplDrawPosition.Right:
                    symbolName = "RightConnectionPoint";
                    PinOutline[0] = new PointD(pinModel.PositionX - pinMarkSize, pinModel.PositionY);
                    PinOutline[1] = new PointD(pinModel.PositionX - pinMarkSize, pinModel.PositionY + pinModel.PinDistance);

                    points[0] = new PointD(PinOutline[0].X, PinOutline[0].Y + pinModel.DimensionY / 2);
                    points[1] = new PointD(PinOutline[0].X - offset, PinOutline[0].Y + pinModel.DimensionY / 2);
                    points[2] = new PointD(PinOutline[0].X - offset, PinOutline[0].Y + pinModel.PinDistance - pinModel.DimensionY / 2); ;
                    points[3] = new PointD(PinOutline[0].X, PinOutline[0].Y + pinModel.PinDistance - pinModel.DimensionY / 2);

                    PinTextPos[0] = new PointD(points[0].X, points[0].Y + offset);
                    PinTextPos[1] = new PointD(points[3].X, points[0].Y - offset);

                    DescriptionTextPos = new PointD(points[0].X - 5, points[0].Y + pinModel.PinDistance / 2);
                    break;
                case EplDrawPosition.Bottom:
                    symbolName = "BottomConnectionPoint";
                    PinOutline[0] = new PointD(pinModel.PositionX, pinModel.PositionY + pinMarkSize);
                    PinOutline[1] = new PointD(pinModel.PositionX + pinModel.PinDistance, pinModel.PositionY + pinMarkSize);

                    points[0] = new PointD(PinOutline[0].X + pinModel.DimensionY / 2, PinOutline[0].Y);
                    points[1] = new PointD(PinOutline[0].X + pinModel.DimensionY / 2, PinOutline[0].Y + offset);
                    points[2] = new PointD(PinOutline[0].X + pinModel.PinDistance - pinModel.DimensionY / 2, PinOutline[0].Y + offset); ;
                    points[3] = new PointD(PinOutline[0].X + pinModel.PinDistance - pinModel.DimensionY / 2, PinOutline[0].Y);

                    PinTextPos[0] = new PointD(points[0].X + offset, points[0].Y);
                    PinTextPos[1] = new PointD(points[3].X - offset, points[0].Y);

                    DescriptionTextPos = new PointD(points[0].X + pinModel.PinDistance / 2, points[0].Y + 5);
                    break;
                case EplDrawPosition.Top:
                    symbolName = "TopConnectionPoint";
                    PinOutline[0] = new PointD(pinModel.PositionX, pinModel.PositionY - pinMarkSize);
                    PinOutline[1] = new PointD(pinModel.PositionX + pinModel.PinDistance, pinModel.PositionY - pinMarkSize);

                    points[0] = new PointD(PinOutline[0].X + pinModel.DimensionY / 2, PinOutline[0].Y);
                    points[1] = new PointD(PinOutline[0].X + pinModel.DimensionY / 2, PinOutline[0].Y - offset);
                    points[2] = new PointD(PinOutline[0].X + pinModel.PinDistance - pinModel.DimensionY / 2, PinOutline[0].Y - offset);
                    points[3] = new PointD(PinOutline[0].X + pinModel.PinDistance - pinModel.DimensionY / 2, PinOutline[0].Y);

                    PinTextPos[0] = new PointD(points[0].X + offset, points[0].Y);
                    PinTextPos[1] = new PointD(points[3].X - offset, points[0].Y);

                    DescriptionTextPos = new PointD(points[0].X + pinModel.PinDistance / 2, points[0].Y - 5);
                    break;
                default:
                    break;
            }

            Rectangle(ref refPage, pinModel, PinOutline[0]);
            Rectangle(ref refPage, pinModel, PinOutline[1]);

            refPage.InsertConnectingPoint("MY_LIB_K", symbolName, PinOutline[0]);
            refPage.InsertConnectingPoint("MY_LIB_K", symbolName, PinOutline[1]);

            Text text1 = new Text();
            text1.Create(refPage, pinName[0], pinModel.Font.Height);
            Text text2 = new Text();
            text2.Create(refPage, pinName[1], pinModel.Font.Height);
            text1.Location = PinTextPos[0];
            text2.Location = PinTextPos[1];
            PolyLine polyLine = new PolyLine();
            polyLine.Create(refPage);
            polyLine.Pen.Width = pinModel.OutlineWidthVal;
            for (int i = 0; i < 4; i++)
            {
                polyLine.SetPointAt(i, ref points[i]);
            }

            Text text3 = new Text();
            switch (pinModel.Function)
            {
                case EplDrawPinFunction.POWER_AC:

                    text3.Create(refPage, "PWR AC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.POWER_DC:
                    text3.Create(refPage, "PWR DC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.SIGNAL_PIN:
                    break;
                case EplDrawPinFunction.INPUT_AC_V:
                    text3.Create(refPage, "Input\nV-AC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.INPUT_AC_A:
                    text3.Create(refPage, "Input\nA-AC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.INPUT_DC_V:
                    text3.Create(refPage, "Input\nV-DC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.INPUT_DC_A:
                    text3.Create(refPage, "Input\nA-DC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.OUPUT_AC_V:
                    text3.Create(refPage, "Output\nV-AC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.OUPUT_AC_A:
                    text3.Create(refPage, "Output\nV-AC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.OUPUT_DC_V:
                    text3.Create(refPage, "Output\nV-DC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.OUPUT_DC_A:
                    text3.Create(refPage, "Output\nA-DC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.CONTACT_NO:
                    text3.Create(refPage, "NO", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.CONTACT_NC:
                    text3.Create(refPage, "NC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.CONTACT_NOC:
                    text3.Create(refPage, "NO-NC", pinModel.Font.Height);
                    text3.Location = DescriptionTextPos;
                    break;
                case EplDrawPinFunction.SHILED:
                    break;
                case EplDrawPinFunction.EARTH:
                    break;
                case EplDrawPinFunction.RECTANGLE:
                    break;
                case EplDrawPinFunction.CIRCLE:
                    break;
                case EplDrawPinFunction.TEXT:
                    break;
                default:
                    break;
            }
        }

        public static System.Drawing.Color GetDisplayColor(string color)
        {
            if (color == EplDrawColor.from_layer.ToString())
            {
                return System.Drawing.Color.Black;
            }
            else
                if (color == EplDrawColor.black.ToString())
            {
                return System.Drawing.Color.Black;
            }
            else
                if (color == EplDrawColor.red.ToString())
            {
                return System.Drawing.Color.Red;
            }
            else
                if (color == EplDrawColor.yellow.ToString())
            {
                return System.Drawing.Color.Yellow;
            }
            else
                if (color == EplDrawColor.green.ToString())
            {
                return System.Drawing.Color.Green;
            }
            else
                if (color == EplDrawColor.cyan.ToString())
            {
                return System.Drawing.Color.Cyan;
            }
            else
                if (color == EplDrawColor.blue.ToString())
            {
                return System.Drawing.Color.Blue;
            }
            else
                if (color == EplDrawColor.magenta.ToString())
            {
                return System.Drawing.Color.Magenta;
            }
            else
                if (color == EplDrawColor.white.ToString())
            {
                return System.Drawing.Color.White;
            }
            else
                if (color == EplDrawColor.darkgray.ToString())
            {
                return System.Drawing.Color.DarkGray;
            }
            else
                if (color == EplDrawColor.gray.ToString())
            {
                return System.Drawing.Color.Gray;
            }
            return System.Drawing.Color.Black;
        }

        public static short GetColorId(string color)
        {
            if (color == EplDrawColor.from_layer.ToString())
            {
                return (short)EplDrawColor.from_layer;
            }
            else
                if (color == EplDrawColor.black.ToString())
            {
                return (short)EplDrawColor.black;
            }
            else
                if (color == EplDrawColor.red.ToString())
            {
                return (short)EplDrawColor.red;
            }
            else
                if (color == EplDrawColor.yellow.ToString())
            {
                return (short)EplDrawColor.yellow;
            }
            else
                if (color == EplDrawColor.green.ToString())
            {
                return (short)EplDrawColor.green;
            }
            else
                if (color == EplDrawColor.cyan.ToString())
            {
                return (short)EplDrawColor.cyan;
            }
            else
                if (color == EplDrawColor.blue.ToString())
            {
                return (short)EplDrawColor.blue;
            }
            else
                if (color == EplDrawColor.magenta.ToString())
            {
                return (short)EplDrawColor.magenta;
            }
            else
                if (color == EplDrawColor.white.ToString())
            {
                return (short)EplDrawColor.white;
            }
            else
                if (color == EplDrawColor.darkgray.ToString())
            {
                return (short)EplDrawColor.darkgray;
            }
            else
                if (color == EplDrawColor.gray.ToString())
            {
                return (short)EplDrawColor.gray;
            }
            return 0;
        }
    }
}
