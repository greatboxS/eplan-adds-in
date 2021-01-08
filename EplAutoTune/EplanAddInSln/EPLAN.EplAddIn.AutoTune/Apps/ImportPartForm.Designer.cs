namespace EPLAN.EplAddIn.AutoTune.Apps
{
    partial class ImportPartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPartForm));
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.ImportConsole = new System.Windows.Forms.Label();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chbSelected = new System.Windows.Forms.CheckBox();
            this.txtTotalImport = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.RadioButton();
            this.Skip = new System.Windows.Forms.RadioButton();
            this.Override = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAdded = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PartViewer = new System.Windows.Forms.DataGridView();
            this.PartsDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearchPart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.EditProps = new System.Windows.Forms.ToolStripMenuItem();
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsDataSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Import Part:";
            // 
            // btnStartImport
            // 
            this.btnStartImport.Location = new System.Drawing.Point(175, 87);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(75, 23);
            this.btnStartImport.TabIndex = 7;
            this.btnStartImport.Text = "Start";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // ImportConsole
            // 
            this.ImportConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ImportConsole.Location = new System.Drawing.Point(8, 59);
            this.ImportConsole.Name = "ImportConsole";
            this.ImportConsole.Size = new System.Drawing.Size(425, 16);
            this.ImportConsole.TabIndex = 6;
            this.ImportConsole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.Location = new System.Drawing.Point(84, 7);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.Size = new System.Drawing.Size(292, 20);
            this.txtConfigPath.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(402, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chbSelected
            // 
            this.chbSelected.AutoSize = true;
            this.chbSelected.Location = new System.Drawing.Point(8, 34);
            this.chbSelected.Name = "chbSelected";
            this.chbSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbSelected.Size = new System.Drawing.Size(120, 17);
            this.chbSelected.TabIndex = 8;
            this.chbSelected.Text = "Import only selected";
            this.chbSelected.UseVisualStyleBackColor = true;
            // 
            // txtTotalImport
            // 
            this.txtTotalImport.Location = new System.Drawing.Point(175, 32);
            this.txtTotalImport.Name = "txtTotalImport";
            this.txtTotalImport.Size = new System.Drawing.Size(56, 20);
            this.txtTotalImport.TabIndex = 9;
            this.txtTotalImport.Text = "500";
            this.txtTotalImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalImport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalImport_KeyPress);
            // 
            // Update
            // 
            this.Update.AutoSize = true;
            this.Update.Location = new System.Drawing.Point(328, 34);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(60, 17);
            this.Update.TabIndex = 10;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            // 
            // Skip
            // 
            this.Skip.AutoSize = true;
            this.Skip.Location = new System.Drawing.Point(391, 34);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(46, 17);
            this.Skip.TabIndex = 11;
            this.Skip.Text = "Skip";
            this.Skip.UseVisualStyleBackColor = true;
            // 
            // Override
            // 
            this.Override.AutoSize = true;
            this.Override.Checked = true;
            this.Override.Location = new System.Drawing.Point(257, 34);
            this.Override.Name = "Override";
            this.Override.Size = new System.Drawing.Size(65, 17);
            this.Override.TabIndex = 11;
            this.Override.TabStop = true;
            this.Override.Text = "Override";
            this.Override.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Added:";
            // 
            // lbAdded
            // 
            this.lbAdded.AutoSize = true;
            this.lbAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdded.Location = new System.Drawing.Point(59, 96);
            this.lbAdded.Name = "lbAdded";
            this.lbAdded.Size = new System.Drawing.Size(10, 13);
            this.lbAdded.TabIndex = 12;
            this.lbAdded.Text = " ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbAdded);
            this.panel1.Controls.Add(this.txtConfigPath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Override);
            this.panel1.Controls.Add(this.ImportConsole);
            this.panel1.Controls.Add(this.Skip);
            this.panel1.Controls.Add(this.btnStartImport);
            this.panel1.Controls.Add(this.Update);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtTotalImport);
            this.panel1.Controls.Add(this.chbSelected);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 124);
            this.panel1.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(8, 78);
            this.progressBar1.MarqueeAnimationSpeed = 200;
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(425, 3);
            this.progressBar1.Step = 20;
            this.progressBar1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PartViewer);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(967, 520);
            this.panel2.TabIndex = 14;
            // 
            // PartViewer
            // 
            this.PartViewer.AutoGenerateColumns = false;
            this.PartViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn9,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewCheckBoxColumn9});
            this.PartViewer.DataSource = this.PartsDataSource;
            this.PartViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartViewer.Location = new System.Drawing.Point(3, 127);
            this.PartViewer.Name = "PartViewer";
            this.PartViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartViewer.Size = new System.Drawing.Size(961, 390);
            this.PartViewer.TabIndex = 0;
            // 
            // PartsDataSource
            // 
            this.PartsDataSource.Position = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 124);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtSearchPart);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(449, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(512, 124);
            this.panel4.TabIndex = 15;
            // 
            // txtSearchPart
            // 
            this.txtSearchPart.Location = new System.Drawing.Point(93, 7);
            this.txtSearchPart.Name = "txtSearchPart";
            this.txtSearchPart.Size = new System.Drawing.Size(251, 20);
            this.txtSearchPart.TabIndex = 6;
            this.txtSearchPart.Text = "part number";
            this.txtSearchPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchPart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPart_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Part number:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(350, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Part:";
            // 
            // PartMenu
            // 
            this.PartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveChanges,
            this.EditProps,
            this.Remove});
            this.PartMenu.Name = "PartMenu";
            this.PartMenu.Size = new System.Drawing.Size(151, 70);
            // 
            // SaveChanges
            // 
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(150, 22);
            this.SaveChanges.Text = "Save changes";
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // EditProps
            // 
            this.EditProps.Name = "EditProps";
            this.EditProps.Size = new System.Drawing.Size(150, 22);
            this.EditProps.Text = "Edit properties";
            this.EditProps.Click += new System.EventHandler(this.EditProps_Click);
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(150, 22);
            this.Remove.Text = "Remove";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // dataGridViewImageColumn9
            // 
            this.dataGridViewImageColumn9.DataPropertyName = "Image";
            this.dataGridViewImageColumn9.HeaderText = "Image";
            this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
            this.dataGridViewImageColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn17.HeaderText = "Name";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn18.HeaderText = "TypeName";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn9
            // 
            this.dataGridViewCheckBoxColumn9.DataPropertyName = "IsDesignable";
            this.dataGridViewCheckBoxColumn9.HeaderText = "IsDesignable";
            this.dataGridViewCheckBoxColumn9.Name = "dataGridViewCheckBoxColumn9";
            this.dataGridViewCheckBoxColumn9.ReadOnly = true;
            // 
            // ImportPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 530);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportPartForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part Import";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PartViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsDataSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.PartMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Label ImportConsole;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chbSelected;
        private System.Windows.Forms.TextBox txtTotalImport;
        private System.Windows.Forms.RadioButton Update;
        private System.Windows.Forms.RadioButton Skip;
        private System.Windows.Forms.RadioButton Override;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAdded;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView PartViewer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip PartMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveChanges;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem EditProps;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDesignableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
        private System.Windows.Forms.BindingSource PartsDataSource;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
    }
}