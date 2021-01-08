using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.MasterData;
using Eplan.EplApi.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public static class EplControlExtension
    {
        private static MDPartsManagement mDPartsManagement;
        private static MDPartsDatabase mDPartsDatabase;
        public static Connection[] GetConnectionList(this Function[] functions)
        {
            List<Connection> ConnList = new List<Connection>();
            if (functions != null)
                foreach (var func in functions)
                {
                    foreach (var conn in func.Connections)
                    {
                        ConnList.Add(conn);
                    }
                }
            return ConnList.ToArray();
        }

        public static void GenNumber(this Page[] pages, int startVal, int increment, bool structureOriented = false, bool keeptext = true)
        {
            Eplan.EplApi.HEServices.Renumber renumber = new Eplan.EplApi.HEServices.Renumber();
            renumber.Pages(pages, structureOriented, startVal, increment, false, keeptext, Eplan.EplApi.HEServices.Renumber.Enums.SubPages.Retain);
        }

        public static void GenNumber(this Page page, int startVal, int increment, bool structureOriented = false, bool keeptext = true)
        {
            Eplan.EplApi.HEServices.Renumber renumber = new Eplan.EplApi.HEServices.Renumber();
            renumber.Pages(new Page[] { page }, structureOriented, startVal, increment, false, keeptext, Eplan.EplApi.HEServices.Renumber.Enums.SubPages.Retain);
        }

        public static void PagesNumber(this Project project, int startVal, int increment, bool structureOriented = false, bool keeptext = true)
        {

            Eplan.EplApi.HEServices.Renumber renumber = new Eplan.EplApi.HEServices.Renumber();
            renumber.Pages(project.Pages, structureOriented, startVal, increment, false, keeptext, Eplan.EplApi.HEServices.Renumber.Enums.SubPages.Retain);
        }

        public static string PlaceConnectionDefinitionPoint(this Page page, string scheme, bool regenerate)
        {
            return EplExtension.PlaceConnectionDefifinitionPoint(page, scheme, regenerate);
        }

        public static string PlaceConnectionNumber(this Page page, string scheme, bool regenerate)
        {
            return EplExtension.PlaceConnectionNumber(page, scheme, regenerate);
        }

        public static string PlaceConnections(this Page page, string scheme, bool regenerate)
        {
            return EplExtension.PlaceConnections(page, scheme, regenerate);
        }
        public static Page CreateNewPage(this Project project, ref Page page, string pageName, string title, int number, string plant, string location, string description, string[] userText = null)
        {
            EplPageProperties pageProperties = new EplPageProperties
            {
                DesignationPlant = plant,
                Location = location,
                PageTitle = title,
                PageNumber = number,
                PageName = pageName,
                PageDescription = description,
            };

            if (userText != null)
                pageProperties.UserDefinitionText = userText;

            EplExtension.CreateNewPage(ref project, ref page, pageProperties);
            return page;
        }

        public static string InsertDevice(this Page page, string lib, string symbol, string part, string DT, PointD location,
            string functionT, string characteristic, string engravingT, string mountingT,
            string[] connections = null, string[] connectionDes = null)
        {
            var deviceP = new EplDeviceProperties
            {
                SymbolLibraryName = lib,
                SymbolName = symbol,
                SymbolVariant = 0,
                PartName = part,
                Characteristics = characteristic,
                FunctionText = functionT,
                EngravingText = engravingT,
                MountingSite = mountingT,
                DisplayText = DT,
                Location = location,
            };

            if (connections != null)
                deviceP.ConnectionDesignations = connections;

            if (connectionDes != null)
                deviceP.ConnectionPointDescription = connectionDes;

            return EplExtension.InsertDevice(ref page, deviceP);
        }


        public static string InsertConnectingPoint(this Page page, string lib, string symbolname, PointD location)
        {

            string msg = EplDefinition.EPL_INSERT_CONNECTING_POINT.ToString();
            try
            {
                using (LockingStep oLS = new LockingStep())
                {
                    page.Project.LockAllObjects();
                    SymbolLibrary symboLib = new SymbolLibrary(page.Project, lib);
                    Symbol symbol = new Symbol(symboLib, symbolname);
                    SymbolVariant oSymbolVariant = new SymbolVariant();
                    oSymbolVariant.Initialize(symbol, 0);
                    Function function = new Function();
                    function.Create(page, oSymbolVariant);
                    function.Location = location;
                    function.Properties.FUNC_CONNECTIONDESIGNATION[1] = "1";
                }
            }
            catch (Exception ex)
            {
                EplExtension.EplException("Insert symbol error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static bool SaveChanges(this MDPart part, EplPartProperties eplPartProperties)
        {
            try
            {
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

                if (eplPartProperties.PartFreeProperties != null)
                {
                    for (int i = 0; i < eplPartProperties.PartFreeProperties.Count; i++)
                    {
                        part.Properties.ARTICLE_FREE_DATA_DESCRIPTION[i + 1] = eplPartProperties.PartFreeProperties[i].Description;
                        part.Properties.ARTICLE_FREE_DATA_VALUE[i + 1] = eplPartProperties.PartFreeProperties[i].Value;
                        part.Properties.ARTICLE_FREE_DATA_UNIT[i + 1] = eplPartProperties.PartFreeProperties[i].Unit;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Save part", ex);
                return false;
            }
        }

        public static List<EplPartProperties> Search(string partNumber)
        {
            try
            {
                if (mDPartsManagement == null)
                    mDPartsManagement = new MDPartsManagement();

                if (mDPartsDatabase == null || !mDPartsDatabase.IsOpen)
                    mDPartsDatabase = mDPartsManagement.OpenDatabase();

                var parts = mDPartsDatabase.Parts.Where(i => i.PartNr.Contains(partNumber) || partNumber.Contains(i.PartNr)).ToList();

                if (parts == null)
                    return null;

                var result = parts.Select(s => new EplPartProperties
                {
                    PartNumber = s.PartNr,
                    Supplier = s.Properties.ARTICLE_SUPPLIER,
                    Description = s.Properties.ARTICLE_NOTE,
                    Manufacturer = s.Properties.ARTICLE_MANUFACTURER,
                    OrderNumber = s.Properties.ARTICLE_ORDERNR,
                    Unit = s.Properties.ARTICLE_QUANTITYUNIT,
                    Quantity = s.Properties.ARTICLE_PACKAGINGQUANTITY,
                    Macro = s.Properties.ARTICLE_MACRO,
                    Characteristic = s.Properties.ARTICLE_CHARACTERISTICS,
                    Price = s.Properties.ARTICLE_PACKAGINGPRICE_1,
                    PartGroup = s.Properties.ARTICLE_GROUPNUMBER,
                    Symbol = (s.Properties.ARTICLE_REPORT_SYMBOL[1].IsEmpty ? "" : s.Properties.ARTICLE_REPORT_SYMBOL[1].ToString()),
                    //ProductGroup = s.ProductGroup,
                    //ProductSubGroup = s.ProductSubGroup,
                    //ProductTopGroup = s.GenericProductGroup,
                    Voltage = s.Properties.ARTICLE_VOLTAGE,
                    VoltageType = s.Properties.ARTICLE_VOLTAGETYPE,
                    Current = s.Properties.ARTICLE_ELECTRICALCURRENT,
                    TrippingCurrent = s.Properties.ARTICLE_TRIGGERCURRENT,
                    ConnectionPointCrossSection = s.Properties.ARTICLE_CONNECTIONCROSSSECTION,
                    SwitchingCapacity = s.Properties.ARTICLE_ELECTRICALPOWER,
                    MaxPowerDissipation = s.Properties.ARTICLE_POWERDISSIPATION,

                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Search error.", ex);
                return null;
            }
        }

        public static void Remove(this EplPartProperties eplPartProperties)
        {
            var part = GetMDPart(eplPartProperties);
            if (part != null)
                mDPartsDatabase.RemovePart(part);
        }

        public static void Remove(string partNumber)
        {
            var part = GetMDPart(partNumber);
            if (part != null)
                mDPartsDatabase.RemovePart(part);
        }

        public static bool SaveChanges(this EplPartProperties eplPartProperties)
        {
            try
            {
                var part = GetMDPart(eplPartProperties);
                if (part == null)
                    return false;
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
                part.Properties.ARTICLE_REPORT_SYMBOL[1] = eplPartProperties.Symbol;

                if (eplPartProperties.PartFreeProperties != null)
                {
                    for (int i = 0; i < eplPartProperties.PartFreeProperties.Count; i++)
                    {
                        part.Properties.ARTICLE_FREE_DATA_DESCRIPTION[i + 1] = eplPartProperties.PartFreeProperties[i].Description;
                        part.Properties.ARTICLE_FREE_DATA_VALUE[i + 1] = eplPartProperties.PartFreeProperties[i].Value;
                        part.Properties.ARTICLE_FREE_DATA_UNIT[i + 1] = eplPartProperties.PartFreeProperties[i].Unit;
                    }
                }

                mDPartsDatabase.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Save part", ex);
                return false;
            }
        }


        public static void CloseDb()
        {
            if (mDPartsDatabase != null && mDPartsDatabase.IsOpen)
                mDPartsDatabase.Close();
        }

        public static MDPart GetMDPart(this EplPartProperties eplPartProperties)
        {

            if (mDPartsManagement == null)
                mDPartsManagement = new MDPartsManagement();

            if (mDPartsDatabase == null || !mDPartsDatabase.IsOpen)
                mDPartsDatabase = mDPartsManagement.OpenDatabase();

            var part = mDPartsDatabase.Parts.Where(i => i.PartNr == eplPartProperties.PartNumber).FirstOrDefault();
            return part;
        }

        public static MDPart GetMDPart(string partnumber)
        {

            if (mDPartsManagement == null)
                mDPartsManagement = new MDPartsManagement();

            if (mDPartsDatabase == null || !mDPartsDatabase.IsOpen)
                mDPartsDatabase = mDPartsManagement.OpenDatabase();

            var part = mDPartsDatabase.Parts.Where(i => i.PartNr == partnumber).FirstOrDefault();
            return part;
        }
    }
}
