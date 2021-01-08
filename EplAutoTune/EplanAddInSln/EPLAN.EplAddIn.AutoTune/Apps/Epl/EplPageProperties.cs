using Eplan.EplApi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplPageProperties
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public int  PageNumber { get; set; }
        public string Location { get; set; }
        public string DesignationPlant { get; set; }
        public string PlotFrame { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string[] UserDefinitionText { get; set; }

        public DocumentTypeManager.DocumentType DocumentType { get; set; } = DocumentTypeManager.DocumentType.Circuit;
        public List<EplSymbolProperties> SymbolMacroList { get; set; } = new List<EplSymbolProperties>();
        public List<EplWindowMacroProperties> WindowMacroList { get; set; } = new List<EplWindowMacroProperties>();
        public List<EplPageMacroProperties> PageMacroList { get; set; } = new List<EplPageMacroProperties>();
        public List<EplMacroProperties> EplMacroProperties { get; set; } = new List<EplMacroProperties>();
    }
}
