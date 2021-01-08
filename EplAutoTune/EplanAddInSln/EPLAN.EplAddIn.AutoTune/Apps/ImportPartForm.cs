using EPLAN.EplAddIn.AutoTune.Apps.Excel;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Eplan.EplApi.MasterData;
using Eplan.EplApi.Base.Internal;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public partial class ImportPartForm : Form
    {
        private string FilePath { get; set; }
        public string Mesg { get; set; }
        public int Counter { get; set; }
        public MessageBase MessageBase { get; set; }

        private ExcelPartImport ExcelPartImport;
        private List<EplPartProperties> EplPartProperties { get; set; }
        private Binding ConsoleBinding { get; set; }

        private bool StartImport = false;
        private CancellationToken CancellationToken;
        private CancellationTokenSource CancellationTokenSource { get; set; }
        private Task ImportTask { get; set; }
        private int Total = 0;
        public ImportPartForm()
        {
            InitializeComponent();

            // console message binding context
            MessageBase = new MessageBase();
            Binding binding = new Binding("Text", MessageBase, "Message", false, DataSourceUpdateMode.OnPropertyChanged);
            ImportConsole.DataBindings.Add(binding);

            Binding pBarBinding = new Binding("Value", MessageBase, "ProcessBarCounter", false, DataSourceUpdateMode.OnPropertyChanged);
            progressBar1.DataBindings.Add(pBarBinding);

            Binding AddBinding = new Binding("Text", MessageBase, "ProcessBarCounter", false, DataSourceUpdateMode.OnPropertyChanged);
            lbAdded.DataBindings.Add(AddBinding);

            PartsDataSource.DataSource = typeof(EplPartProperties);
            //
            PartViewer.ContextMenuStrip = PartMenu;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                txtConfigPath.Text = FilePath;
            }
        }

        public ImportPartForm(string filePath)
        {
            InitializeComponent();
            PartsDataSource.DataSource = typeof(EplPartProperties);
            FilePath = filePath;
            txtConfigPath.Text = FilePath;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            MessageBase.ProcessBarCounter = 0;
            ImportFile();
        }

        private void ImportFile()
        {
            if (StartImport)
            {
                StartImport = false;
                btnStartImport.Text = "Start";
                CancellationTokenSource.Cancel();
            }
            else
            {
                if (string.IsNullOrEmpty(FilePath))
                {
                    MessageBox.Show("Please select part configuration file before import");
                    return;
                }

                PartAction action = PartAction.OVERRIDE;
                if (Update.Checked)
                    action = PartAction.UPDATE;
                if (Skip.Checked)
                    action = PartAction.SKIP;

                ExcelPartImport = new ExcelPartImport(FilePath, GenGlobal.CurrentProject);
                ExcelPartImport.InsertPartChanged += ExcelPartImport_InsertPartChanged;
                ExcelPartImport.ImportDone += ExcelPartImport_ImportDone;
                ExcelPartImport.ExcelGetPartItemDone += ExcelPartImport_ExcelGetPartItemDone;
                ExcelPartImport.OnExceptionThrown += ExcelPartImport_OnExceptionThrown;
                ExcelPartImport.ExcelReadDone += ExcelPartImport_ExcelReadDone;

                int.TryParse(txtTotalImport.Text, out Total);
                txtTotalImport.Text = Total.ToString();
                bool selected = chbSelected.Checked;
                //run an action asynchronously
                StartImport = true;
                btnStartImport.Text = "Cancel";
                CancellationTokenSource = new CancellationTokenSource();
                CancellationToken = CancellationTokenSource.Token;

                ImportTask = Task.Factory.StartNew(() =>
                {
                    ExcelPartImport.ImportPart(Total, selected, action, CancellationToken);
                }, CancellationToken);
            }
        }

        private void ExcelPartImport_ExcelReadDone(object sender)
        {
            List<EplPartProperties> parts = sender as List<EplPartProperties>;
            progressBar1.Maximum = parts.Count;
            MessageBase.ProcessBarCounter = 0;
        }

        private void ExcelPartImport_OnExceptionThrown(object sender)
        {
            string mesg = (string)sender;
            Writeline(mesg);
        }

        private void ExcelPartImport_ExcelGetPartItemDone(object sender)
        {
            var item = sender as EplPartProperties;
            Writeline($"Excel get part: {item.PartNumber}");
        }

        private void ExcelPartImport_ImportDone(object sender)
        {
            var parts = sender as List<EplPartProperties>;
            EplPartProperties = new List<EplPartProperties>(parts);
            BindingPartSource();
            Writeline("Import parts successfully");
            StartImport = false;
            btnStartImport.Text = "Start";
        }

        private void ExcelPartImport_InsertPartChanged(object sender)
        {
            var part = sender as EplPartProperties;
            MessageBase.ProcessBarCounter++;
            Writeline($"Insert part: {part.PartNumber}");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = fileDialog.FileName;
                txtConfigPath.Text = FilePath;
            }
        }

        private void txtTotalImport_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((char.IsNumber(e.KeyChar)) ||
               (e.KeyChar == (char)Keys.Back));
        }

        private void Writeline(string mesg)
        {
            MessageBase.Message = mesg;
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            var selectedItem = PartsDataSource.Current as EplPartProperties;
            if (selectedItem == null)
                return;

            txtConfigPath.Focus();

            MessageBox.Show($"{(selectedItem.SaveChanges() ? "Save changes successed" : "Save changes error")}");

            EplControlExtension.CloseDb();
        }

        private void EditProps_Click(object sender, EventArgs e)
        {
            var selectedItem = PartsDataSource.Current as EplPartProperties;
            if (selectedItem == null)
                return;
            PartFreePropertiesForm PropForm = new PartFreePropertiesForm(selectedItem);
            PropForm.ShowDialog();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            foreach (var item in PartViewer.SelectedRows)
            {
                EplPartProperties part = (item as DataGridViewRow).DataBoundItem as EplPartProperties;
                EplControlExtension.Remove(part.PartNumber);
                var p = EplPartProperties.Where(i => i.PartNumber == part.PartNumber).FirstOrDefault();
                EplPartProperties.Remove(p);
            }
            BindingPartSource();
            EplControlExtension.CloseDb();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearchPart.Text);
        }

        private void Search(string partNumber)
        {
            EplPartProperties = EplControlExtension.Search(partNumber);
            EplControlExtension.CloseDb();

            BindingPartSource();
        }

        private void txtSearchPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Search(txtSearchPart.Text);
        }

        private void BindingPartSource()
        {
            try
            {
                if (EplPartProperties != null)
                {
                    EplPartProperties = EplPartProperties
                        .OrderBy(i => i.PartNumber)
                        .ToList();
                    PartsDataSource.DataSource = EplPartProperties;
                }
            }
            catch { }
        }
    }
}
