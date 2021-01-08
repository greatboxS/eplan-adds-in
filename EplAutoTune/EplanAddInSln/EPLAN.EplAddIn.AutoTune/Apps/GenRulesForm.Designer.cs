namespace EPLAN.EplAddIn.AutoTune.Apps
{
    partial class GenRulesForm
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
            this.GenRulesProp = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // GenRulesProp
            // 
            this.GenRulesProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenRulesProp.Location = new System.Drawing.Point(0, 0);
            this.GenRulesProp.Name = "GenRulesProp";
            this.GenRulesProp.Size = new System.Drawing.Size(277, 378);
            this.GenRulesProp.TabIndex = 0;
            // 
            // GenRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 378);
            this.Controls.Add(this.GenRulesProp);
            this.Name = "GenRulesForm";
            this.Text = "Rules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenRulesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid GenRulesProp;
    }
}