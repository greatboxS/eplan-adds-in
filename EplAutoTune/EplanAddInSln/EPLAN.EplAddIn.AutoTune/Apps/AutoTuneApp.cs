using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.MasterData;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;
using EPLAN.EplAddIn.AutoTune.Apps.Excel;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public partial class AutoTuneApp : Form
    {
        List<Project> OpenProjects;
        SymbolAutoDrawingForm SymbolAutoDrawingForm;
        private ExcelConfiguration ExcelConfiguration;
        public AutoTuneApp()
        {
            InitializeComponent();
        }

        private void btnExcelBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (GenGlobal.AppConfig.GenFile != null)
                    if (File.Exists(GenGlobal.AppConfig.GenFile))
                        openFileDialog.InitialDirectory = GenGlobal.AppConfig.GenFile;
                    else
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtConfigPath.Text = GenGlobal.AppConfig.GenFile = openFileDialog.FileName;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex.ToString()); }
        }


        private void btnGenRules_Click(object sender, EventArgs e)
        {
            GenGlobal.GenRulesForm.ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelConfiguration = new ExcelConfiguration(GenGlobal.AppConfig.GenFile, GenGlobal.AppConfig.BasePath);
                ExcelConfiguration.ReadFromExcelConfiguration();

                Logger.WriteLine(JsonConvert.SerializeObject(ExcelConfiguration));

                ExcelConfiguration.Generating(ref GenGlobal.CurrentProject);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public void AutoTuneLoading()
        {
            if (GenGlobal.GetSetting(GenGlobal.AutoTuneSettings.OLD_GEN_CONFIG))
                GenConfigBindingSource.DataSource = GenGlobal.AppConfig;
            else
            {
                GenGlobal.AppConfig = new AppConfig();
                GenConfigBindingSource.DataSource = GenGlobal.AppConfig;
            }

            rdbMultiline.Checked = GenGlobal.AppConfig.Multiline;
            rdbSignleline.Checked = GenGlobal.AppConfig.SingleLine;

            GenGlobal.ProjectManager = new ProjectManager();
            OpenProjects = new List<Project>();

            GenGlobal.ProjectManager.LockProjectByDefault = false;
            OpenProjects = new List<Project>(GenGlobal.ProjectManager.OpenProjects);
            if (OpenProjects != null)
            {
                cbbDesProject.Items.Clear();
                cbbDesProject.Items.AddRange(OpenProjects.Select(i => i.ProjectName).ToArray());
                GenGlobal.CurrentProject = GenGlobal.ProjectManager.GetCurrentProjectWithDialog();
                cbbDesProject.Text = GenGlobal.CurrentProject.ProjectName;
                btnGenerate.Enabled = true;
            }
            else
            {
                btnGenerate.Enabled = false;
                WriteLine("Can not find any opned project in your workspace.");
            }
        }

        private void WriteLine(string msg)
        {
            txtGenLog.Text = msg;

        }
        private void WriteLine(EplError error)
        {
            txtGenLog.Text = error.ToString();
        }
        private void WriteLine(EplDefinition e)
        {
            txtGenLog.Text = e.ToString();
        }

        private void cbbDesProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GenGlobal.CurrentProject = OpenProjects.Where(i => i.ProjectName == (sender as ComboBox).Text).FirstOrDefault();
                WriteLine($"Current project: {GenGlobal.CurrentProject.ProjectFullName}");
            }
            catch { }
        }

        private void AutoTuneApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            GenGlobal.SaveSetting(GenGlobal.AutoTuneSettings.OLD_GEN_CONFIG);
        }

        private void rdbMultiline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMultiline.Checked)
            {
                GenGlobal.AppConfig.Multiline = true;
            }
        }

        private void rdbSignleline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMultiline.Checked)
            {
                GenGlobal.AppConfig.SingleLine = true;
            }
        }

        private void btnAutoDrawing_Click(object sender, EventArgs e)
        {
            if (SymbolAutoDrawingForm == null || SymbolAutoDrawingForm.IsDisposed)
            {
                SymbolAutoDrawingForm = new SymbolAutoDrawingForm();
            }
            SymbolAutoDrawingForm.ShowDialog();
        }

        private void btnImportPart_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportPartForm importPartForm = new ImportPartForm(fileDialog.FileName);
                importPartForm.ShowDialog();
            }
        }

        private void txtGenLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtConfigPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
