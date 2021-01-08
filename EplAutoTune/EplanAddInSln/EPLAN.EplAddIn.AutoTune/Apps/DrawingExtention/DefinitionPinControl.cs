using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public partial class DefinitionPinControl : UserControl
    {
        private DrawPinModel DrawPinModel;

        public event RemoveEvent RemoveEvent;
        public string Place { get; set; }
        public DefinitionPinControl()
        {
            InitializeComponent();
            DrawPinModel = new DrawPinModel();
            BindingSource.DataSource = DrawPinModel;
        }

        public DefinitionPinControl(DrawPinModel pinItem)
        {
            InitializeComponent();
            UpdateUI(pinItem);
        }

        public void UpdateUI(DrawPinModel pinItem)
        {
            DrawPinModel = pinItem;
            UpdateUI();
        }

        public void UpdateUI()
        {
            Place = (DrawPinModel.PinGroup + 1).ToString();
            lbPinItemPlace.Text = Place;
            BindingSource.DataSource = DrawPinModel;
        }

        private void btnFontPicker_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((char.IsNumber(e.KeyChar)) ||
                (e.KeyChar == (char)Keys.Decimal) ||
                (e.KeyChar == (char)Keys.Back));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveEvent?.Invoke(DrawPinModel.PinGroup);
            this.Dispose();
        }
    }

    public delegate void RemoveEvent(int id);
}
