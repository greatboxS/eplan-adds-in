using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps.Modules
{
    public class GenerationRules
    {
        private int top;

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        private int left;

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private int right;

        public int Right
        {
            get { return right; }
            set { right = value; }
        }


        private string baseFolder;

        public string BaseFolder
        {
            get { return baseFolder; }
            set { baseFolder = value; }
        }
    }
}
