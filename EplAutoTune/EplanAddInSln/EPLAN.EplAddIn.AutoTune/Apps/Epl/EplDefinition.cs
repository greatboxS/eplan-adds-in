using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public enum EplDefinition
    {
        EPL_INSERT_SYMBOL_MCR,
        PLC_INSERT_SYMBOL_MCR,
        EPL_INSERT_PAGE_MCR,
        EPL_CREATE_PAGE,
        EPL_INSERT_MCR,
        EPL_INSERT_WINDOW_MCR,
        EPL_INSERT_DEVICE,
        EPL_PLACE_CONNECTION,
        EPL_GEN_CONNECTION_NUM,
        EPL_PLACE_CONNECTION_DEFINITION,
        EPL_INSERT_CONNECTING_POINT,
    }

    public enum EplError
    {
        EPL_ERROR=404,

    }
}
