using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplAutoGenConfig
    {
        public int GenType { get; set; }
        public EplProjectProperties EplProjectProperties { get; set; } = new EplProjectProperties();
        public List<EplPageProperties> EplPageProperties { get; set; } = new List<EplPageProperties>();
    }
}
