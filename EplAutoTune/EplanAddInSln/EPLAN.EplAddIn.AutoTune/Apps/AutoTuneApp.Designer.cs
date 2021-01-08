namespace EPLAN.EplAddIn.AutoTune.Apps
{
    partial class AutoTuneApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTuneApp));
            this.cbbDesProject = new System.Windows.Forms.ComboBox();
            this.txtGenLog = new System.Windows.Forms.TextBox();
            this.btnGenRules = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rdbSignleline = new System.Windows.Forms.RadioButton();
            this.rdbMultiline = new System.Windows.Forms.RadioButton();
            this.btnNewProject = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.btnExcelBrowse = new System.Windows.Forms.Button();
            this.GenConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GenConfigBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbDesProject
            // 
            this.cbbDesProject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GenConfigBindingSource, "DesProject", true));
            this.cbbDesProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDesProject.FormattingEnabled = true;
            this.cbbDesProject.Location = new System.Drawing.Point(110, 76);
            this.cbbDesProject.Name = "cbbDesProject";
            this.cbbDesProject.Size = new System.Drawing.Size(179, 21);
            this.cbbDesProject.TabIndex = 25;
            this.cbbDesProject.SelectedIndexChanged += new System.EventHandler(this.cbbDesProject_SelectedIndexChanged);
            // 
            // txtGenLog
            // 
            this.txtGenLog.BackColor = System.Drawing.Color.White;
            this.txtGenLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGenLog.ForeColor = System.Drawing.Color.Green;
            this.txtGenLog.Location = new System.Drawing.Point(6, 109);
            this.txtGenLog.Multiline = true;
            this.txtGenLog.Name = "txtGenLog";
            this.txtGenLog.ReadOnly = true;
            this.txtGenLog.Size = new System.Drawing.Size(449, 20);
            this.txtGenLog.TabIndex = 24;
            this.txtGenLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGenLog.TextChanged += new System.EventHandler(this.txtGenLog_TextChanged);
            // 
            // btnGenRules
            // 
            this.btnGenRules.AutoSize = true;
            this.btnGenRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenRules.Location = new System.Drawing.Point(348, 46);
            this.btnGenRules.Name = "btnGenRules";
            this.btnGenRules.Size = new System.Drawing.Size(100, 13);
            this.btnGenRules.TabIndex = 20;
            this.btnGenRules.Text = "Generating rules";
            this.btnGenRules.Click += new System.EventHandler(this.btnGenRules_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(191, 135);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 23);
            this.btnGenerate.TabIndex = 23;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rdbSignleline
            // 
            this.rdbSignleline.AutoSize = true;
            this.rdbSignleline.Location = new System.Drawing.Point(89, 46);
            this.rdbSignleline.Name = "rdbSignleline";
            this.rdbSignleline.Size = new System.Drawing.Size(73, 17);
            this.rdbSignleline.TabIndex = 19;
            this.rdbSignleline.Text = "Single line";
            this.rdbSignleline.UseVisualStyleBackColor = true;
            this.rdbSignleline.CheckedChanged += new System.EventHandler(this.rdbSignleline_CheckedChanged);
            // 
            // rdbMultiline
            // 
            this.rdbMultiline.AutoSize = true;
            this.rdbMultiline.Checked = true;
            this.rdbMultiline.Location = new System.Drawing.Point(7, 46);
            this.rdbMultiline.Name = "rdbMultiline";
            this.rdbMultiline.Size = new System.Drawing.Size(66, 17);
            this.rdbMultiline.TabIndex = 15;
            this.rdbMultiline.TabStop = true;
            this.rdbMultiline.Text = "Multi line";
            this.rdbMultiline.UseVisualStyleBackColor = true;
            this.rdbMultiline.CheckedChanged += new System.EventHandler(this.rdbMultiline_CheckedChanged);
            // 
            // btnNewProject
            // 
            this.btnNewProject.AutoSize = true;
            this.btnNewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNewProject.Location = new System.Drawing.Point(371, 79);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(75, 13);
            this.btnNewProject.TabIndex = 16;
            this.btnNewProject.Text = "New project";
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Configuration File:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Destination project:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.GenConfigBindingSource, "GenFile", true));
            this.txtConfigPath.Location = new System.Drawing.Point(103, 13);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.Size = new System.Drawing.Size(283, 20);
            this.txtConfigPath.TabIndex = 13;
            this.txtConfigPath.TextChanged += new System.EventHandler(this.txtConfigPath_TextChanged);
            // 
            // btnExcelBrowse
            // 
            this.btnExcelBrowse.Location = new System.Drawing.Point(392, 11);
            this.btnExcelBrowse.Name = "btnExcelBrowse";
            this.btnExcelBrowse.Size = new System.Drawing.Size(54, 23);
            this.btnExcelBrowse.TabIndex = 14;
            this.btnExcelBrowse.Text = "Browse";
            this.btnExcelBrowse.UseVisualStyleBackColor = true;
            this.btnExcelBrowse.Click += new System.EventHandler(this.btnExcelBrowse_Click);
            // 
            // GenConfigBindingSource
            // 
            this.GenConfigBindingSource.DataSource = typeof(EPLAN.EplAddIn.AutoTune.Apps.Modules.AppConfig);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbDesProject);
            this.groupBox1.Controls.Add(this.btnExcelBrowse);
            this.groupBox1.Controls.Add(this.txtGenLog);
            this.groupBox1.Controls.Add(this.txtConfigPath);
            this.groupBox1.Controls.Add(this.btnGenRules);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.btnNewProject);
            this.groupBox1.Controls.Add(this.rdbSignleline);
            this.groupBox1.Controls.Add(this.rdbMultiline);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 166);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // AutoTuneApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 171);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(487, 210);
            this.MaximumSize = new System.Drawing.Size(487, 210);
            this.Name = "AutoTuneApp";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto EPLAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoTuneApp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GenConfigBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource GenConfigBindingSource;
        private System.Windows.Forms.ComboBox cbbDesProject;
        private System.Windows.Forms.TextBox txtGenLog;
        private System.Windows.Forms.Label btnGenRules;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton rdbSignleline;
        private System.Windows.Forms.RadioButton rdbMultiline;
        private System.Windows.Forms.Label btnNewProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Button btnExcelBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}