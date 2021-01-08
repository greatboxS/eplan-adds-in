using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class ExcelExtension
    {
        public ExcelWorksheet ProjectSheet { get; set; }
        public ExcelWorksheet PageSheet { get; set; }
        public ExcelWorksheet PageDetailSheet { get; set; }
        public ExcelPackage ExcelPackage { get; set; }

        public bool Override { get; set; }
        public ExcelExtension(string FilePath)
        {
            ExcelPackage = OpenExcelFile(FilePath);
            ProjectSheet = ExcelPackage.Workbook.Worksheets[0];
            PageSheet = ExcelPackage.Workbook.Worksheets[1];
            PageDetailSheet = ExcelPackage.Workbook.Worksheets[2];
        }

        public ExcelExtension(string FilePath, bool overRide)
        {
            ExcelPackage = OpenExcelFile(FilePath);
            Override = overRide;
        }

        public EplProjectProperties GetProjectProperties()
        {
            EplProjectProperties EplProjectProperties = new EplProjectProperties();
            try
            {
                EplProjectProperties.ProjectName = ProjectSheet.GetCellText("C2");
                EplProjectProperties.ProjectTitle = ProjectSheet.GetCellText("C3");
                EplProjectProperties.OrderNumber = ProjectSheet.GetCellText("C4");
                EplProjectProperties.ProductNumber = ProjectSheet.GetCellText("C5");
                EplProjectProperties.Date = ProjectSheet.GetCellText("C6");
                EplProjectProperties.Descriptions = ProjectSheet.GetCellText("C7");
                EplProjectProperties.CheckPersion = ProjectSheet.GetCellText("C8");
                EplProjectProperties.ApprovedPersion = ProjectSheet.GetCellText("C9");
                EplProjectProperties.Creator = ProjectSheet.GetCellText("C10");

                for (int i = 0; i < 10; i++)
                {
                    int addr = i * 3 + 13;
                    EplProjectProperties.Revisions[i].Name = ProjectSheet.GetCellText("C", addr);
                    EplProjectProperties.Revisions[i].Description = ProjectSheet.GetCellText("C", addr + 1);
                    EplProjectProperties.Revisions[i].Date = ProjectSheet.GetCellText("C", addr + 2);
                }

                EplProjectProperties.PageLayout.Width = ProjectSheet.GetCellValue<double>("F2");
                EplProjectProperties.PageLayout.Heigth = ProjectSheet.GetCellValue<double>("F3");

                return EplProjectProperties;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Get project properties failed.", ex);
                return null;
            }


        }

        public EplPageProperties GetPageProperty(int row)
        {
            EplPageProperties EplPageProperties = new EplPageProperties();
            try
            {
                string pick = PageSheet.GetCellText($"B{row}");
                if (pick.ToLower() != "x")
                    return null;

                EplPageProperties.Id = EplPageProperties.PageNumber = PageSheet.GetCellValue<int>($"A{row}");
                EplPageProperties.PageName = PageSheet.GetCellText($"C{row}");
                EplPageProperties.Location = PageSheet.GetCellText($"D{row}");
                EplPageProperties.DesignationPlant = PageSheet.GetCellText($"E{row}");
                EplPageProperties.PlotFrame = PageSheet.GetCellText($"F{row}");
                EplPageProperties.PageTitle = PageSheet.GetCellText($"G{row}");
                EplPageProperties.PageDescription = PageSheet.GetCellText($"H{row}");
                return EplPageProperties;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Get project properties failed.", ex);
                return null;
            }
        }

        public List<EplPageProperties> GetPageProperties(int totalCheckRow)
        {
            List<EplPageProperties> EplPageProperties = new List<EplPageProperties>();
            try
            {
                int row = 2;
                while (--totalCheckRow > 0)
                {
                    var result = GetPageProperty(row++);
                    if (result != null)
                    {
                        GetPageDetailDrawing(ref result);
                        EplPageProperties.Add(result);
                    }
                }

                return EplPageProperties;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Get project properties failed.", ex);
                return null;
            }
        }

        public void GetPageDetailDrawing(ref EplPageProperties EplPageProperties)
        {
            try
            {
                int pageIdResult = 0;
                int row = 2;
                do
                {
                    pageIdResult = GetPageDetailDrawing(ref EplPageProperties, EplPageProperties.Id, row++);
                } while (pageIdResult > 0);
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Get page detail drawing failed.", ex);
            }
        }

        public int GetPageDetailDrawing(ref EplPageProperties EplPageProperties, int pageId, int row)
        {
            int PageId = 0;
            try
            {
                PageId = PageDetailSheet.GetCellValue<int>($"A{row}");
                if (pageId != PageId)
                    return PageId;

                EplMacroProperties EplMacroProperties = new EplMacroProperties();
                EplMacroProperties.FileName = PageDetailSheet.GetCellText($"B{row}");
                EplMacroProperties.Position.X = PageDetailSheet.GetCellValue<double>($"C{row}");
                EplMacroProperties.Position.Y = PageDetailSheet.GetCellValue<double>($"D{row}");
                EplMacroProperties.Tollerence = PageDetailSheet.GetCellValue<double>($"E{row}");
                EplMacroProperties.Quantity = PageDetailSheet.GetCellValue<int>($"H{row}");

                string movekine = PageDetailSheet.GetCellText($"G{row}");
                if (movekine.ToLower().IndexOf("relative") > -1)
                    EplMacroProperties.MoveKind = Eplan.EplApi.HEServices.Insert.MoveKind.Relative;
                else
                    EplMacroProperties.MoveKind = Eplan.EplApi.HEServices.Insert.MoveKind.Absolute;

                EplPageProperties.EplMacroProperties.Add(EplMacroProperties);
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Get page detail drawing failed.", ex);
            }

            return PageId;
        }

        public static ExcelPackage OpenExcelFile(string filename)
        {
            try
            {
                // If you use EPPlus in a noncommercial context
                // according to the Polyform Noncommercial license:
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                return new ExcelPackage(new FileInfo(filename));
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Close excel package failed.", ex);
                return null;
            }
        }

        public void CloseExcelFile()
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                ExcelPackage.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Close excel package failed.", ex);
            }
        }

        public static void CloseExcelFile(ref ExcelPackage excelPackage)
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                excelPackage.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Close excel package failed.", ex);
            }
        }
    }


    public static class ExcelUserExtension
    {
        public static string GetCellText(this ExcelWorksheet excelSheet, int column, int row)
        {
            var cell = excelSheet.Cells[row, column];
            return cell != null ? cell.Text.Trim().ToUpper() : string.Empty;
        }

        public static T GetCellValue<T>(this ExcelWorksheet excelSheet, int column, int row)
        {
            var cell = excelSheet.Cells[row, column];
            if (cell != null)
                return cell.GetValue<T>();
            else
                return default(T);
        }

        public static string GetCellText(this ExcelWorksheet excelSheet, string column, int row)
        {
            var cell = excelSheet.Cells[$"{column}{row}"];
            return cell != null ? cell.Text.Trim().ToUpper() : string.Empty;
        }

        public static T GetCellValue<T>(this ExcelWorksheet excelSheet, string column, int row)
        {
            var cell = excelSheet.Cells[$"{column}{row}"];
            if (cell != null)
                return cell.GetValue<T>();
            else
                return default(T);
        }

        public static string GetCellText(this ExcelWorksheet excelSheet, string cellAddr)
        {
            var cell = excelSheet.Cells[cellAddr];
            return cell != null ? cell.Text.Trim().ToUpper() : string.Empty;
        }

        public static T GetCellValue<T>(this ExcelWorksheet excelSheet, string cellAddr)
        {
            var cell = excelSheet.Cells[cellAddr];
            if (cell != null)
                return cell.GetValue<T>();
            else
                return default(T);
        }
    }
}
