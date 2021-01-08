using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    static class EplDrawControlExtension
    {
        public static void DrawRectangle(this Page page, PointD location, bool fill, double width, double height,
            double pen_width, short colorId, short styleId = (short)EplDrawStyle.from_layer)
        {
            EplDrawingExtention.Rectangle(ref page, location, fill, width, height, pen_width, colorId, styleId);
        }

        public static Page GetActivePage(this Project project)
        {
            SelectionSet selectionSet = new SelectionSet();
            if (selectionSet.CurrentlyEdited.GetType().Name == "Page")
                return (selectionSet.CurrentlyEdited as Page);
            else
                return GenGlobal.ActivePage;
        }
    }
}
