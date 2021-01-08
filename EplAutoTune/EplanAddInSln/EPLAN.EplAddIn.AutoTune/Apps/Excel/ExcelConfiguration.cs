using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    class ExcelConfiguration
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string BasePath { get; set; }
        public int TotalChecking { get; set; }
        public EplProjectProperties EplProjectProperties { get; set; }
        public List<EplPageProperties> EplPageProperties { get; set; }

        private ExcelExtension ExcelExtension { get; set; }

        public ExcelConfiguration(string filePath, string basePath)
        {
            FilePath = filePath;
            BasePath = basePath;
            EplProjectProperties = new EplProjectProperties();
            EplPageProperties = new List<EplPageProperties>();
            TotalChecking = 20;
        }

        public void ReadFromExcelConfiguration()
        {
            ExcelExtension = new ExcelExtension(FilePath);
            BasePath = ExcelExtension.ProjectSheet.GetCellText("F7");
            TotalChecking = ExcelExtension.ProjectSheet.GetCellValue<int>("F6");
            EplProjectProperties = ExcelExtension.GetProjectProperties();
            EplPageProperties = ExcelExtension.GetPageProperties(TotalChecking);
            ExcelExtension.CloseExcelFile();
        }

        public void Generating(ref Eplan.EplApi.DataModel.Project project)
        {
            project.Properties.PROJ_CUSTOMERTITLE = EplProjectProperties.ProjectTitle;
            project.Properties.PROJ_INSTALLATIONNAME = EplProjectProperties.Descriptions;
            project.Properties.PROJ_REVISION_APPROVEDBY = EplProjectProperties.ApprovedPersion;
            project.Properties.PROJ_REVISION_CHECKEDBY = EplProjectProperties.CheckPersion;
            project.Properties.PROJ_CREATORNAME1 = EplProjectProperties.Creator;
            foreach (var item in EplPageProperties)
            {
                Eplan.EplApi.DataModel.Page page = null;
                EplExtension.CreateNewPage(ref project, ref page, new Apps.EplPageProperties
                {
                    PageName = item.PageName,
                    PageTitle = item.PageTitle,
                    PageDescription = item.PageDescription,
                    DesignationPlant = item.DesignationPlant,
                    Location = item.Location,
                    PageNumber = item.PageNumber,
                    PlotFrame = item.PlotFrame,
                });

                foreach (var macro in item.EplMacroProperties)
                {
                    macro.FilePath = Path.Combine(BasePath, macro.FileName);
                    EplExtension.InsertMacro(ref project, ref page, macro);
                }
            }
        }
    }
}
