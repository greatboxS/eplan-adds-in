using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public enum EplDrawStyle
    {
        from_layer = 16002,
        continous = 0, //0 = continous: ------
        dash = 1, //1 = dash: - - - - -
        dot = 2, //2 = dot: .......
        dashdot = 3,//3 = dashdot: _._._._
        dashdotdot = 4,//4 = dashdotdot: _.._.._
        dashlongdot = 6//6 = dashlongdot: __ _
    }

    public enum EplDrawColor
    {
        from_layer = 16002,
        black = 0,//0 = black
        red = 1,//1 = red
        yellow = 2,//2 = yellow
        green = 3,//3 = green
        cyan = 4,//4 = cyan
        blue = 5,//5 = blue
        magenta = 6,//6 = magenta
        white = 7,//7 = white
        darkgray = 252,//252 = darkgray
        gray = 253,//253 = gray
    }

    public enum EplDrawPosition
    {
        Left,
        Right,
        Bottom,
        Top,
    }

    public enum EplDrawPinFunction
    {
        POWER_AC,
        POWER_DC,
        SIGNAL_PIN,
        INPUT_AC_V,
        INPUT_AC_A,
        INPUT_DC_V,
        INPUT_DC_A,
        OUPUT_AC_V,
        OUPUT_AC_A,
        OUPUT_DC_V,
        OUPUT_DC_A,
        CONTACT_NO,
        CONTACT_NC,
        CONTACT_NOC,
        SHILED,
        EARTH,
        RECTANGLE,
        CIRCLE,
        TEXT,
    }
}
