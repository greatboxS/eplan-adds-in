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
    public partial class PartFreePropertiesForm : Form
    {
        private EplPartProperties EplPartProperties { get; set; }
        public PartFreePropertiesForm()
        {
            InitializeComponent();
        }

        public PartFreePropertiesForm(EplPartProperties eplPartProperties)
        {
            InitializeComponent();
            EplPartProperties = eplPartProperties;

            var mdPart = EplPartProperties.GetMDPart();

            for (int i = 0; i < 10; i++)
            {
                if (mdPart.Properties.ARTICLE_FREE_DATA_DESCRIPTION[i + 1].IsEmpty)
                    break;
                EplPartProperties.PartFreeProperties.Add(new PartFreeProperties
                {
                    Description = mdPart.Properties.ARTICLE_FREE_DATA_DESCRIPTION[i + 1],
                    Unit = mdPart.Properties.ARTICLE_FREE_DATA_UNIT,
                    Value = mdPart.Properties.ARTICLE_FREE_DATA_VALUE,
                });
            }

            FreePropertiesSource.DataSource = EplPartProperties.PartFreeProperties;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Logger.WriteLine("Save free properties", JsonConvert.SerializeObject(EplPartProperties.PartFreeProperties));
            if(EplPartProperties.SaveChanges())
                MessageBox.Show("Save changes successed");
            else
                MessageBox.Show("Save changes failed");

            EplControlExtension.CloseDb();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EplPartProperties.PartFreeProperties.Add(new PartFreeProperties());
            FreePropertiesSource.DataSource = EplPartProperties.PartFreeProperties;
            FreePropViewer.Rows.Add();
        }
    }
}
