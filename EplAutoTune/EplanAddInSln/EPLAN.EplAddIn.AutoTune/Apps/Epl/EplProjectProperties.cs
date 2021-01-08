using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplProjectProperties
    {
        public string Descriptions { get; set; }
        public string ProjectName { get; set; }
        public string ApprovedPersion { get; set; }
        public string CheckPersion { get; set; }
        public string Creator { get; set; }
        public string Date { get; set; }
        public string OrderNumber { get; set; }
        public string ProductNumber { get; set; }
        public PageLayout PageLayout = new PageLayout();
        public string ProjectTitle { get; internal set; }
        public Revision[] Revisions { get; set; } = new Revision[10];
    }
    public struct Revision
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }

    public struct PageLayout
    {
        public double Width { get; set; }
        public double Heigth { get; set; }
    }
}
