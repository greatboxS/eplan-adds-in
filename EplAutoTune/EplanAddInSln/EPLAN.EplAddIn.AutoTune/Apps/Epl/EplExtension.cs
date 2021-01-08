using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.MasterData;
using Eplan.EplApi.HEServices;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class EplExtension
    {
        public static string CreateNewPage(ref Project refProject, ref Page refPage, EplPageProperties pageProperties)
        {
            string msg = EplDefinition.EPL_CREATE_PAGE.ToString();
            try
            {
                PagePropertyList pPropList = new PagePropertyList();
                pPropList[Properties.Page.PAGE_NAME] = pageProperties.PageName;
                pPropList[Properties.Page.DESIGNATION_PLANT] = pageProperties.DesignationPlant;
                pPropList[Properties.Page.DESIGNATION_LOCATION] = pageProperties.Location;
                if (refPage == null)
                    refPage = new Page();

                
                string pageNull = $"={pageProperties.DesignationPlant}+{pageProperties.Location}/{pageProperties.PageName}";

                var exsitedPage = refProject.Pages.Where(i => i.Properties.PAGE_FULLNAME == pageNull).FirstOrDefault();

                exsitedPage?.Remove();

                refPage.Create(refProject, pageProperties.DocumentType, pPropList);
                refPage.Properties.PAGE_NAME = pageProperties.PageName;
            }
            catch (Exception ex)
            {
                EplException("Create new page error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static string PlaceConnections(Page page, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_PLACE_CONNECTION.ToString();
            try
            {
                mesg += "\n" + PlaceConnectionDefifinitionPoint(page, scheme, regenerate);
                mesg += "\n" + PlaceConnectionNumber(page, scheme, regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place page connections error.", ex);
            }

            return mesg;
        }

        public static string PlaceConnections(Connection[] connections, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_PLACE_CONNECTION.ToString();
            try
            {
                mesg += "\n" + PlaceConnectionDefifinitionPoint(connections, scheme, regenerate);
                mesg += "\n" + PlaceConnectionNumber(connections, scheme, regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place page connections error.", ex);
            }

            return mesg;
        }

        public static string PlaceConnectionDefifinitionPoint(Connection[] connections, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_PLACE_CONNECTION_DEFINITION.ToString();
            try
            {
                ConnectionService connectionService = new ConnectionService();
                var connectionList = new System.Collections.ArrayList(connections);
                // Place connection definition points
                connectionService.PlaceConnectionDefinitionPoints(connectionList, "DI_DO_connection", regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place connection difinition error.", ex);
            }

            return mesg;
        }

        public static string PlaceConnectionNumber(Connection[] connections, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_GEN_CONNECTION_NUM.ToString();
            try
            {
                ConnectionService connectionService = new ConnectionService();
                var connectionList = new System.Collections.ArrayList(connections);
                //Place connection number, base on the definition placed previous time.
                connectionService.DesignateConnections(connectionList, scheme, ConnectionService.DesignateOverwrition.ExceptManuals, true, regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place connection number error.", ex);
            }

            return mesg;
        }

        public static string PlaceConnectionDefifinitionPoint(Page page, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_PLACE_CONNECTION_DEFINITION.ToString();
            try
            {
                ConnectionService connectionService = new ConnectionService();

                var connections = page.Functions.GetConnectionList();

                var connectionList = new System.Collections.ArrayList(connections);

                // Place connection definition points
                connectionService.PlaceConnectionDefinitionPoints(connectionList, "DI_DO_connection", regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place connection difinition error.", ex);
            }

            return mesg;
        }

        public static string PlaceConnectionNumber(Page page, string scheme, bool regenerate)
        {
            string mesg = EplDefinition.EPL_GEN_CONNECTION_NUM.ToString();
            try
            {
                ConnectionService connectionService = new ConnectionService();
                var connections = page.Functions.GetConnectionList();
                var connectionList = new System.Collections.ArrayList(connections);
                //Place connection number, base on the definition placed previous time.
                connectionService.DesignateConnections(connectionList, scheme, ConnectionService.DesignateOverwrition.ExceptManuals, true, regenerate);
            }
            catch (Exception ex)
            {
                mesg = EplError.EPL_ERROR.ToString();
                EplException("Place connection number error.", ex);
            }

            return mesg;
        }

        public static string InsertSymbol(ref Page refPage, EplSymbolProperties symbolProperties)
        {
            string msg = EplDefinition.EPL_INSERT_SYMBOL_MCR.ToString();
            try
            {
                using (LockingStep oLS = new LockingStep())
                {
                    refPage.Project.LockAllObjects();
                    SymbolLibrary symboLib = new SymbolLibrary(refPage.Project, symbolProperties.SymbolLibraryName);
                    Symbol symbol = new Symbol(symboLib, symbolProperties.SymbolName);
                    SymbolVariant oSymbolVariant = new SymbolVariant();
                    oSymbolVariant.Initialize(symbol, symbolProperties.SymbolVariant);
                    Function function = new Function();
                    function.Create(refPage, oSymbolVariant);
                    //function.Properties.FUNC_SYMB_DESC = symbolProperties.SymbolDescription;
                    if (!string.IsNullOrEmpty(symbolProperties.PartName))
                        function.AddArticleReference(symbolProperties.PartName);
                    function.VisibleName = symbolProperties.DisplayText;
                    function.Properties.FUNC_TEXT = symbolProperties.FunctionText;
                    function.Location = symbolProperties.Location;
                    function.Properties.FUNC_GRAVINGTEXT = symbolProperties.EngravingText;
                    function.Properties.FUNC_TECHNICAL_CHARACTERISTIC = symbolProperties.Characteristics;
                    if (symbolProperties.ConnectionDesignations != null)
                    {
                        for (int i = 0; i < symbolProperties.ConnectionDesignations.Length; i++)
                        {
                            function.Properties.FUNC_CONNECTIONDESIGNATION[i + 1] = symbolProperties.ConnectionDesignations[i];
                            if (symbolProperties.ConnectionPointDescription != null)
                                if (symbolProperties.ConnectionPointDescription.Length > i)
                                    function.Properties.FUNC_CONNECTIONDESCRIPTION[i + 1] = symbolProperties.ConnectionPointDescription[i];
                        }
                    }
                    function.Properties.FUNC_MOUNTINGLOCATION = symbolProperties.MountingSite;

                }

            }
            catch (Exception ex)
            {
                EplException("Insert symbol error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static string InsertDevice(ref Page refPage, EplDeviceProperties deviceProperties)
        {
            string msg = EplDefinition.EPL_INSERT_DEVICE.ToString();
            try
            {
                using (LockingStep oLS = new LockingStep())
                {
                    refPage.Project.LockAllObjects();
                    BoxedDevice oBoxedDevice = new BoxedDevice();
                    string slib = string.IsNullOrEmpty(deviceProperties.SymbolLibraryName) ? "GB_symbol" : deviceProperties.SymbolLibraryName;
                    SymbolLibrary sLibrary = new SymbolLibrary(refPage.Project, slib);
                    Symbol s = new Symbol(sLibrary, deviceProperties.SymbolName);
                    SymbolVariant sv = new SymbolVariant();
                    sv.Initialize(s, 0);
                    oBoxedDevice.Create(refPage);
                    oBoxedDevice.SymbolVariant = sv;
                    //oBoxedDevice.Properties.FUNC_DES = deviceProperties.SymbolDescription;
                    if (!string.IsNullOrEmpty(deviceProperties.PartName))
                        oBoxedDevice.AddArticleReference(deviceProperties.PartName);
                    oBoxedDevice.VisibleName = deviceProperties.DisplayText;
                    oBoxedDevice.Properties.FUNC_TEXT = deviceProperties.FunctionText;
                    oBoxedDevice.Location = deviceProperties.Location;
                    oBoxedDevice.Properties.FUNC_GRAVINGTEXT = deviceProperties.EngravingText;
                    oBoxedDevice.Properties.FUNC_TECHNICAL_CHARACTERISTIC = deviceProperties.Characteristics;
                    if (deviceProperties.ConnectionDesignations != null)
                    {
                        for (int i = 0; i < deviceProperties.ConnectionDesignations.Length; i++)
                        {
                            oBoxedDevice.Properties.FUNC_CONNECTIONDESIGNATION[i + 1] = deviceProperties.ConnectionDesignations[i];
                            if (deviceProperties.ConnectionPointDescription != null)
                                if (deviceProperties.ConnectionPointDescription.Length > i)
                                    oBoxedDevice.Properties.FUNC_CONNECTIONDESCRIPTION[i + 1] = deviceProperties.ConnectionPointDescription[i];
                        }
                    }
                    oBoxedDevice.Properties.FUNC_MOUNTINGLOCATION = deviceProperties.MountingSite;
                }
            }
            catch (Exception ex)
            {
                EplException("Insert device error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }
            return msg;
        }

        public static string InsertWindowMacro(ref Page refPage, EplWindowMacroProperties windowMacroProperties)
        {
            string msg = EplDefinition.EPL_INSERT_WINDOW_MCR.ToString();
            Logger.WriteLine(JsonConvert.SerializeObject(windowMacroProperties));
            try
            {
                Insert insert = new Insert();
                WindowMacro windowMacro = new WindowMacro();
                windowMacro.Open(windowMacroProperties.FilePath, refPage.Project);

                Insert oInsert = new Insert();
                StorableObject[] oInsertedObjects = insert.WindowMacro(
                    windowMacroProperties.FilePath,
                    windowMacroProperties.Variant,
                    refPage,
                    windowMacroProperties.Position,
                    windowMacroProperties.MoveKind);
            }
            catch (Exception ex)
            {
                EplException("Insert window macro error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static string InsertSymbolMacro(ref Page refPage, EplSymbolMacroProperties symbolMacroProperties)
        {
            string msg = EplDefinition.EPL_INSERT_SYMBOL_MCR.ToString();
            try
            {
                Insert insert = new Insert();
                //SymbolMacro symbolMacro = new SymbolMacro();
                //symbolMacro.Open(symbolMacroProperties.FilePath, refPage.Project);

                insert.SymbolMacro(
                    symbolMacroProperties.FilePath,
                    symbolMacroProperties.Variant,
                    refPage,
                    symbolMacroProperties.Position,
                    symbolMacroProperties.MoveKind,
                    symbolMacroProperties.NumerationMode);
            }
            catch (Exception ex)
            {
                EplException("Insert symbol macro error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static string InsertMacro(ref Project refProject, ref Page refPage, EplMacroProperties eplMacroProperties)
        {
            string msg = EplDefinition.EPL_INSERT_MCR.ToString();
            try
            {
                Insert insert = new Insert();
                string macroType = eplMacroProperties.FilePath.Substring(eplMacroProperties.FilePath.LastIndexOf(".") + 1).Trim();
                var offset = eplMacroProperties.Position.X;
                for (int i = 0; i < eplMacroProperties.Quantity; i++)
                {
                    eplMacroProperties.Position.X = i * eplMacroProperties.Tollerence + offset;

                    Logger.WriteLine(JsonConvert.SerializeObject(eplMacroProperties));
                    switch (macroType)
                    {
                        case "ema": //windows macro
                            msg = EplDefinition.EPL_INSERT_WINDOW_MCR.ToString();
                            var windowMacro = eplMacroProperties.As<EplWindowMacroProperties>();
                            windowMacro.Position = eplMacroProperties.Position;
                            msg = InsertWindowMacro(ref refPage, windowMacro);
                            break;

                        case "ems": // symbol macro
                            msg = EplDefinition.EPL_INSERT_SYMBOL_MCR.ToString();
                            var symbolMacro = eplMacroProperties.As<EplSymbolMacroProperties>();
                            symbolMacro.Position = eplMacroProperties.Position;
                            msg = InsertSymbolMacro(ref refPage, symbolMacro);
                            break;

                        case "emp": // page macro
                            msg = EplDefinition.EPL_INSERT_PAGE_MCR.ToString();
                            var pageMacro = eplMacroProperties.As<EplPageMacroProperties>();
                            pageMacro.Position = eplMacroProperties.Position;
                            msg = InsertPageMacro(ref refProject, ref refPage, pageMacro);
                            break;

                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                EplException("Insert macro error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static string InsertPageMacro(ref Project project, ref Page refPage, EplPageMacroProperties pageMacroProperties)
        {
            string msg = EplDefinition.EPL_INSERT_PAGE_MCR.ToString();
            try
            {
                Insert insert = new Insert();
                insert.PageMacro(
                    pageMacroProperties.FilePath,
                    refPage,
                    project,
                    pageMacroProperties.Overwrite,
                    pageMacroProperties.NumerationMode);
            }
            catch (Exception ex)
            {
                EplException("Insert page error.", ex);
                msg = EplError.EPL_ERROR.ToString();
            }

            return msg;
        }

        public static Project[] EplGetOpenedProjects()
        {
            try
            {
                ProjectManager projectManager = new ProjectManager();
                return projectManager.OpenProjects;
            }
            catch (Exception ex)
            {
                EplException("Epl Get Opened Projects error.", ex);
                return null;
            }
        }

        public static Project EplGetProject(string projectName)
        {
            try
            {
                var projects = EplGetOpenedProjects();
                return projects.Where(i => i.ProjectName == projectName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                EplException("Epl Get project error.", ex);
                return null;
            }
        }

        public static Page[] EplGetPages(string pageFilter, Project project)
        {
            DMObjectsFinder oFinder = new DMObjectsFinder(project);
            PagesFilter oPagesFilter = new PagesFilter();
            oPagesFilter.Name = pageFilter;
            oPagesFilter.DocumentType = DocumentTypeManager.DocumentType.Undefined;
            //now we have all pages with names starting with "=AP+ST1" and type with "DocumentType.Frame"
            Page[] oPages = oFinder.GetPages(oPagesFilter);
            return oPages;
        }

        public static void EplException(string cap, Exception e)
        {
            if (GenGlobal.EnableDebug)
                MessageBox.Show(e.ToString(), cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            Logger.WriteLine(cap, e);
        }
    }
}
