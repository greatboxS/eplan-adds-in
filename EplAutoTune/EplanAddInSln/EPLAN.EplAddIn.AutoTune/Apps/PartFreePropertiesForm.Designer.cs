namespace EPLAN.EplAddIn.AutoTune.Apps
{
    partial class PartFreePropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FreePropertiesSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbPartNumber = new System.Windows.Forms.Label();
            this.FreePropViewer = new System.Windows.Forms.DataGridView();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FreePropertiesSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreePropViewer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FreePropertiesSource
            // 
            this.FreePropertiesSource.DataSource = typeof(EPLAN.EplAddIn.AutoTune.Apps.PartFreeProperties);
            // 
            // lbPartNumber
            // 
            this.lbPartNumber.AutoSize = true;
            this.lbPartNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPartNumber.Location = new System.Drawing.Point(5, 5);
            this.lbPartNumber.Name = "lbPartNumber";
            this.lbPartNumber.Size = new System.Drawing.Size(13, 13);
            this.lbPartNumber.TabIndex = 0;
            this.lbPartNumber.Text = "  ";
            // 
            // FreePropViewer
            // 
            this.FreePropViewer.AutoGenerateColumns = false;
            this.FreePropViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FreePropViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.FreePropViewer.DataSource = this.FreePropertiesSource;
            this.FreePropViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreePropViewer.Location = new System.Drawing.Point(5, 18);
            this.FreePropViewer.Name = "FreePropViewer";
            this.FreePropViewer.Size = new System.Drawing.Size(376, 365);
            this.FreePropViewer.TabIndex = 1;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveChanges.Location = new System.Drawing.Point(298, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 22);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSaveChanges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 383);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(376, 28);
            this.panel1.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 22);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PartFreePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 416);
            this.Controls.Add(this.FreePropViewer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbPartNumber);
            this.Name = "PartFreePropertiesForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "PartFreePropertiesForm";
            ((System.ComponentModel.ISupportInitialize)(this.FreePropertiesSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreePropViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource FreePropertiesSource;
        private System.Windows.Forms.Label lbPartNumber;
        private System.Windows.Forms.DataGridView FreePropViewer;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAdd;
    }
}