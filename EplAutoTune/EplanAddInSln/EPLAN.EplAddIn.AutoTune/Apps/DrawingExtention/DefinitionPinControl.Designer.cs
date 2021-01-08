namespace EPLAN.EplAddIn.AutoTune.Apps
{
    partial class DefinitionPinControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbPinItemPlace = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFontPicker = new System.Windows.Forms.Button();
            this.lbPinColor = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbxPinColor = new System.Windows.Forms.ComboBox();
            this.chbPinFill = new System.Windows.Forms.CheckBox();
            this.txtPinFont = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPinItemPlace
            // 
            this.lbPinItemPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbPinItemPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPinItemPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPinItemPlace.ForeColor = System.Drawing.Color.White;
            this.lbPinItemPlace.Location = new System.Drawing.Point(5, 5);
            this.lbPinItemPlace.Name = "lbPinItemPlace";
            this.lbPinItemPlace.Size = new System.Drawing.Size(174, 26);
            this.lbPinItemPlace.TabIndex = 1;
            this.lbPinItemPlace.Text = "##";
            this.lbPinItemPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnFontPicker);
            this.groupBox1.Controls.Add(this.lbPinColor);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbxPinColor);
            this.groupBox1.Controls.Add(this.chbPinFill);
            this.groupBox1.Controls.Add(this.txtPinFont);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 352);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "PositionY", true));
            this.textBox6.Location = new System.Drawing.Point(66, 186);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(41, 20);
            this.textBox6.TabIndex = 46;
            this.textBox6.Text = "0";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox8
            // 
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "PositionX", true));
            this.textBox8.Location = new System.Drawing.Point(3, 186);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(41, 20);
            this.textBox8.TabIndex = 45;
            this.textBox8.Text = "0";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(49, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 13);
            this.label21.TabIndex = 47;
            this.label21.Text = "x";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 155);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 26);
            this.label24.TabIndex = 48;
            this.label24.Text = "Position:\r\n(relate to outline)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Location side:";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "LocationSide", true));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Top",
            "Bottom"});
            this.comboBox2.Location = new System.Drawing.Point(3, 131);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(76, 21);
            this.comboBox2.TabIndex = 43;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "FunctionDescription", true));
            this.textBox2.Location = new System.Drawing.Point(3, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(167, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Function description:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Number", true));
            this.textBox1.Location = new System.Drawing.Point(3, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pin number: (separate by \' , \')";
            // 
            // btnFontPicker
            // 
            this.btnFontPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontPicker.Location = new System.Drawing.Point(148, 307);
            this.btnFontPicker.Name = "btnFontPicker";
            this.btnFontPicker.Size = new System.Drawing.Size(22, 23);
            this.btnFontPicker.TabIndex = 50;
            this.btnFontPicker.Text = "...";
            this.btnFontPicker.UseVisualStyleBackColor = true;
            this.btnFontPicker.Click += new System.EventHandler(this.btnFontPicker_Click);
            // 
            // lbPinColor
            // 
            this.lbPinColor.BackColor = System.Drawing.Color.Black;
            this.lbPinColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPinColor.Location = new System.Drawing.Point(57, 212);
            this.lbPinColor.Name = "lbPinColor";
            this.lbPinColor.Size = new System.Drawing.Size(22, 10);
            this.lbPinColor.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Color:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 289);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Font:";
            // 
            // cbxPinColor
            // 
            this.cbxPinColor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "ColorText", true));
            this.cbxPinColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPinColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPinColor.FormattingEnabled = true;
            this.cbxPinColor.Items.AddRange(new object[] {
            "black",
            "red",
            "yellow",
            "green",
            "cyan",
            "blue",
            "magenta",
            "white",
            "darkgray",
            "gray"});
            this.cbxPinColor.Location = new System.Drawing.Point(3, 225);
            this.cbxPinColor.Name = "cbxPinColor";
            this.cbxPinColor.Size = new System.Drawing.Size(76, 21);
            this.cbxPinColor.TabIndex = 55;
            // 
            // chbPinFill
            // 
            this.chbPinFill.AutoSize = true;
            this.chbPinFill.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BindingSource, "Fill", true));
            this.chbPinFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPinFill.Location = new System.Drawing.Point(6, 331);
            this.chbPinFill.Name = "chbPinFill";
            this.chbPinFill.Size = new System.Drawing.Size(70, 17);
            this.chbPinFill.TabIndex = 53;
            this.chbPinFill.Text = "Fill space";
            this.chbPinFill.UseVisualStyleBackColor = true;
            // 
            // txtPinFont
            // 
            this.txtPinFont.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Font", true));
            this.txtPinFont.Location = new System.Drawing.Point(6, 308);
            this.txtPinFont.Name = "txtPinFont";
            this.txtPinFont.Size = new System.Drawing.Size(136, 20);
            this.txtPinFont.TabIndex = 49;
            this.txtPinFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "PinDistance", true));
            this.textBox3.Location = new System.Drawing.Point(6, 266);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 20);
            this.textBox3.TabIndex = 52;
            this.textBox3.Text = "10";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 249);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 13);
            this.label22.TabIndex = 54;
            this.label22.Text = "Pin-Pin distance:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(70, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 24);
            this.btnRemove.TabIndex = 58;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(EPLAN.EplAddIn.AutoTune.Apps.DrawPinModel);
            // 
            // DefinitionPinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbPinItemPlace);
            this.Name = "DefinitionPinControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(184, 388);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbPinItemPlace;
        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnFontPicker;
        private System.Windows.Forms.Label lbPinColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbxPinColor;
        private System.Windows.Forms.CheckBox chbPinFill;
        private System.Windows.Forms.TextBox txtPinFont;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnRemove;
    }
}
