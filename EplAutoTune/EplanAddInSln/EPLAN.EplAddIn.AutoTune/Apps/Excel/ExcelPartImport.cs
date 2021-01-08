using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.MasterData;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using OfficeOpenXml;

namespace EPLAN.EplAddIn.AutoTune.Apps.Excel
{
    public class ExcelPartImport
    {
        private ExcelExtension ExcelExtension;
        public string FilePath { get; set; }
        private Project CurrentProject { get; set; }
        private ExcelWorksheets PartSheets { get; set; }
        public MDPartsDatabase PartsDataBase { get; set; }
        public MDPartsManagement PartsManagerment { get; set; }


        public event PartImportEventHandle InsertPartChanged;
        public event PartImportEventHandle ExcelGetPartItemDone;
        public event PartImportEventHandle ExcelReadDone;
        public event PartImportEventHandle ImportDone;
        public event PartImportEventHandle OnExceptionThrown;

        public ExcelPartImport(string filePath, Project project)
        {
            Open(filePath, project);
        }

        public void Open(string filePath, Project project)
        {
            PartsManagerment = new MDPartsManagement();
            PartsDataBase = PartsManagerment.OpenDatabase();
            FilePath = filePath;
            CurrentProject = project;
            ExcelExtension = new ExcelExtension(FilePath, true);
            PartSheets = ExcelExtension.ExcelPackage.Workbook.Worksheets;
        }

        public void Dispose()
        {
            PartsDataBase?.Close();
            ExcelExtension?.CloseExcelFile();
        }
        /* A1        B2       C3       D4       E5       F6       G7       H8
         * group    select   desc   partNum    Unit   quantity   Manuf    Origin
         * 
         * I9       F10      K11     12         13          14      15          16       17             18
         * char    macro   symbol    voltage voltagetype current  tripCurrent  Cpoint switchCap MaxPowerDissipation
         */
        public EplPartProperties GetPartProperty(int row, bool selected, ExcelWorksheet sheet)
        {
            try
            {
                EplPartProperties eplPartProperties = new EplPartProperties();
                if (selected)
                {
                    string select = sheet.GetCellText(2, row).ToLower();
                    if (select != "x")
                        return null;
                }

                eplPartProperties.PartNumber = sheet.GetCellText(4, row);
                eplPartProperties.PartGroup = sheet.Name;
                eplPartProperties.Description = sheet.GetCellText(3, row);
                eplPartProperties.Unit = sheet.GetCellText(5, row);
                eplPartProperties.Quantity = sheet.GetCellValue<int>(6, row);
                eplPartProperties.Manufacturer = sheet.GetCellText(7, row);
                eplPartProperties.Supplier = sheet.GetCellText(8, row);
                eplPartProperties.Characteristic = sheet.GetCellText(9, row);
                eplPartProperties.Symbol = sheet.GetCellText(10, row);
                eplPartProperties.Macro = sheet.GetCellText(11, row);

                eplPartProperties.Voltage = sheet.GetCellText(12, row);
                eplPartProperties.VoltageType = sheet.GetCellText(13, row);
                eplPartProperties.Current = sheet.GetCellText(14, row);
                eplPartProperties.TrippingCurrent = sheet.GetCellText(15, row);
                eplPartProperties.ConnectionPointCrossSection = sheet.GetCellText(16, row);
                eplPartProperties.SwitchingCapacity = sheet.GetCellText(17, row);
                eplPartProperties.MaxPowerDissipation = sheet.GetCellText(18, row);

                if (string.IsNullOrEmpty(eplPartProperties.PartNumber) ||
                    string.IsNullOrEmpty(eplPartProperties.Description))
                    return null;

                for (int i = 0; i < 10; i++)
                {
                    int col = i * 3 + 19;
                    string des = sheet.GetCellText(col, row);
                    if (string.IsNullOrEmpty(des))
                        break;

                    eplPartProperties.PartFreeProperties.Add(new PartFreeProperties
                    {
                        Description = sheet.GetCellText(col, row),
                        Value = sheet.GetCellText(col + 1, row),
                        Unit = sheet.GetCellText(col + 2, row),
                    });

                    eplPartProperties.TotalFreeProperty = i + 1;
                }

                ExcelGetPartItemDone?.Invoke(eplPartProperties);
                return eplPartProperties;
            }
            catch (Exception ex)
            {
                OnExceptionThrown?.Invoke($"Get excel part properties failed at {row}");
                Logger.WriteLine($"Get excel part properties failed at {row}", ex);
                return null;
            }
        }

        public List<EplPartProperties> GetPartProperties(int max, bool selectSelected)
        {
            List<EplPartProperties> EplPartProperties = new List<EplPartProperties>();
            foreach (ExcelWorksheet sheet in PartSheets)
            {
                for (int i = 1; i < max; i++)
                {
                    try
                    {
                        var part = GetPartProperty(i, selectSelected, sheet);
                        if (part != null)
                            EplPartProperties.Add(part);
                    }
                    catch (Exception e)
                    {
                        Logger.WriteLine("Get part properties error.", e);
                    }
                }
            }

            ExcelReadDone?.Invoke(EplPartProperties);

            ExcelExtension?.CloseExcelFile();
            return EplPartProperties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <param name="eplPartProperties"></param>
        /// <returns>true if successed</returns>
        public bool InsertPart(EplPartProperties eplPartProperties, PartAction action)
        {
            try
            {
                MDPart part = GetPart(eplPartProperties.PartNumber);

                if (part != null)
                {
                    switch (action)
                    {
                        case PartAction.OVERRIDE:
                            PartsDataBase.RemovePart(part);
                            part = AddPart(eplPartProperties.PartNumber);
                            break;
                        case PartAction.UPDATE:
                            break;
                        case PartAction.SKIP:
                            return true;
                    }
                }
                else
                {
                    part = AddPart(eplPartProperties.PartNumber);
                }

                if (part == null)
                {
                    Logger.WriteLine("Add new part failed.");
                    return false;
                }

                part.GenericProductGroup = MDPartsDatabaseItem.Enums.ProductTopGroup.Electric;
                part.ProductGroup = MDPartsDatabaseItem.Enums.ProductGroup.Common;
                part.ProductSubGroup = MDPartsDatabaseItem.Enums.ProductSubGroup.Common;

                part.Properties.ARTICLE_SUPPLIER = eplPartProperties.Supplier;
                part.Properties.ARTICLE_NOTE = eplPartProperties.Description;
                part.Properties.ARTICLE_MANUFACTURER = eplPartProperties.Manufacturer;
                part.Properties.ARTICLE_ORDERNR = eplPartProperties.OrderNumber;
                part.Properties.ARTICLE_QUANTITYUNIT = eplPartProperties.Unit;
                part.Properties.ARTICLE_PACKAGINGQUANTITY = eplPartProperties.Quantity;
                part.Properties.ARTICLE_MACRO = eplPartProperties.Macro;
                part.Properties.ARTICLE_CHARACTERISTICS = eplPartProperties.Characteristic;
                part.Properties.ARTICLE_PACKAGINGPRICE_1 = eplPartProperties.Price;
                part.Properties.ARTICLE_REPORT_SYMBOL[1] = eplPartProperties.Symbol;
                part.Properties.ARTICLE_GROUPNUMBER = eplPartProperties.PartGroup;

                part.Properties.ARTICLE_VOLTAGE = eplPartProperties.Voltage;
                part.Properties.ARTICLE_VOLTAGETYPE = eplPartProperties.VoltageType;
                part.Properties.ARTICLE_ELECTRICALCURRENT = eplPartProperties.Current;
                part.Properties.ARTICLE_TRIGGERCURRENT = eplPartProperties.TrippingCurrent;
                part.Properties.ARTICLE_CONNECTIONCROSSSECTION = eplPartProperties.ConnectionPointCrossSection;
                part.Properties.ARTICLE_ELECTRICALPOWER = eplPartProperties.SwitchingCapacity;
                part.Properties.ARTICLE_POWERDISSIPATION = eplPartProperties.MaxPowerDissipation;

                if (eplPartProperties.PartFreeProperties != null)
                {
                    for (int i = 0; i < eplPartProperties.PartFreeProperties.Count; i++)
                    {
                        part.Properties.ARTICLE_FREE_DATA_DESCRIPTION[i + 1] = eplPartProperties.PartFreeProperties[i].Description;
                        part.Properties.ARTICLE_FREE_DATA_VALUE[i + 1] = eplPartProperties.PartFreeProperties[i].Value;
                        part.Properties.ARTICLE_FREE_DATA_UNIT[i + 1] = eplPartProperties.PartFreeProperties[i].Unit;
                    }
                }

                Logger.WriteLine($"Create part: {eplPartProperties.PartNumber} successfully.");
                return true;
            }
            catch (Exception e)
            {
                OnExceptionThrown?.Invoke($"Insert Part {eplPartProperties.PartNumber} error.");
                Logger.WriteLine("InsertPart error.", e);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="max"> Number of part to be added to database</param>
        /// <returns></returns>
        public bool ImportPart(int max, bool selectSeleted, PartAction action, CancellationToken token)
        {
            List<EplPartProperties> EplParts = GetPartProperties(max, selectSeleted);
            foreach (var item in EplParts)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }

                if (InsertPart(item, action))
                    InsertPartChanged?.Invoke(item);    // rase an event to main window

            }

            ImportDone?.Invoke(EplParts);

            Dispose();
            return true;
        }

        public MDPart AddPart(string partNumber)
        {
            try
            {
                return PartsDataBase?.AddPart(partNumber);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Add part {partNumber} error.", ex);
                return null;
            }
        }

        public MDPart GetPart(string partNumber)
        {
            try
            {
                return PartsDataBase?.GetPart(partNumber);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Add part {partNumber} error.", ex);
                return null;
            }
        }
    }
    public enum PartAction
    {
        OVERRIDE,
        UPDATE,
        SKIP,
    }

    public delegate void PartImportEventHandle(object sender);
}
