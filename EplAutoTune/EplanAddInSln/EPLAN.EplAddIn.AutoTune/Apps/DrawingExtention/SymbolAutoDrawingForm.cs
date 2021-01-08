using Eplan.EplApi.DataModel;
using EPLAN.EplAddIn.AutoTune.Apps.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public partial class SymbolAutoDrawingForm : Form
    {
        private DrawPinModel CurrentPinModel;
        public SymbolAutoDrawingForm()
        {
            InitializeComponent();
            EplDrawinSymbolModel = new EplDrawSymbolModel();
            CurrentPinModel = new DrawPinModel { PinGroup = EplDrawinSymbolModel.PinGroupIndex };
            PinOulineBSource.DataSource = CurrentPinModel;
            MainOutlineBSource.DataSource = EplDrawinSymbolModel.MainLayout;
            DisplayTextBSource.DataSource = EplDrawinSymbolModel.DrawDisplayText;

            cbxPinShape.SelectedIndex = 0;
            cbxPinColor.SelectedIndex = 0;
            cbxPinWidth.SelectedIndex = 0;
            cbx_LayoutShape.SelectedIndex = 0;
            cbx_LayoutWidth.SelectedIndex = 0;
            cbxLayoutColor.SelectedIndex = 0;
            EplDrawinSymbolModel.MainLayout.Font = this.Font;
        }
        private EplDrawSymbolModel EplDrawinSymbolModel;

        private void ColorPicker(ComboBox cb)
        {
            var color = EplDrawingExtention.GetDisplayColor(cb.Text);
            if (cb.Name == "cbxPinColor")
                lbPinColor.BackColor = color;
            else
                lbOutlineColor.BackColor = color;
        }

        private void cbxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            ColorPicker(cb);
        }

        private void btnPinColor_Click(object sender, EventArgs e)
        {
            if (ConnectionFontDialog.ShowDialog() == DialogResult.OK)
                CurrentPinModel.Font = ConnectionFontDialog.Font;
        }

        private void btnGenPins_Click(object sender, EventArgs e)
        {
            //EplDrawinSymbolgModel.PinCollectionItem = new List<PinCollectionItem>(EplDrawinSymbolgModel.PinNumber);
            //for (int i = 0; i < EplDrawinSymbolgModel.PinNumber; i++)
            //{
            //    EplDrawinSymbolgModel.PinCollectionItem.Add(new PinCollectionItem { Place = i + 1, Enable = true, Position = EplDrawPosition.Left.ToString() });
            //    //PinCollectionTable.Controls.Add(new DefinitionPinControl(EplDrawinSymbolgModel.PinCollectionItem[i]), 0, i);
            //}
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(JsonConvert.SerializeObject(EplDrawinSymbolModel));

            EplDrawingExtention eplDrawingExtention = new EplDrawingExtention();

            Page currentPage = GenGlobal.CurrentProject.GetActivePage();
            EplDrawingExtention.Rectangle(ref currentPage, EplDrawinSymbolModel.MainLayout);

            eplDrawingExtention.BasePosition = new Eplan.EplApi.Base.PointD(EplDrawinSymbolModel.MainLayout.PositionX, EplDrawinSymbolModel.MainLayout.PositionY);

            eplDrawingExtention.DrawPolyline(ref currentPage, CurrentPinModel);
            //GenGlobal.CurrentProject.GetActivePage().DrawRectangle(new Eplan.EplApi.Base.PointD(EplDrawinSymbolgModel.PositionX, EplDrawinSymbolgModel.PositionY),
            //    EplDrawinSymbolgModel.Fill, EplDrawinSymbolgModel.DimensionX, EplDrawinSymbolgModel.DimensionY, EplDrawinSymbolgModel.OutlineWidthVal, EplDrawinSymbolgModel.ColorId);
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = checkedListBox1.SelectedIndex;
            EplDrawinSymbolModel.MainLayout.Templates[id] =
                checkedListBox1.GetItemCheckState(id) == CheckState.Checked ? true : false;
        }

        private void FixLeftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNewPin_Click(object sender, EventArgs e)
        {
            DefinitionPinControl PinGroupControl = new DefinitionPinControl(CurrentPinModel);
            PinGroupControl.RemoveEvent += PinGroupControl_RemoveEvent;
            PinCollectionTable.Controls.Add(PinGroupControl);
            EplDrawinSymbolModel.AddPinGroup(CurrentPinModel);
            CurrentPinModel = new DrawPinModel { PinGroup = EplDrawinSymbolModel.PinGroupIndex };
            PinOulineBSource.DataSource = CurrentPinModel;
        }

        private void PinGroupControl_RemoveEvent(int id)
        {
            EplDrawinSymbolModel.RemotePinGroup(id);
            PinCollectionTable.Controls.Clear();

            foreach (var item in EplDrawinSymbolModel.PinCollections)
            {
                DefinitionPinControl PinGroupControl = new DefinitionPinControl(item);
                PinGroupControl.RemoveEvent += PinGroupControl_RemoveEvent;
                PinCollectionTable.Controls.Add(PinGroupControl);
            }

            CurrentPinModel.PinGroup = EplDrawinSymbolModel.PinGroupIndex;
            PinOulineBSource.DataSource = CurrentPinModel;
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((char.IsNumber(e.KeyChar)) ||
                (e.KeyChar == (char)Keys.Decimal) ||
                (e.KeyChar == (char)Keys.Back));
        }

        private void cbxPinColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            ColorPicker(cb);
        }
    }
}
