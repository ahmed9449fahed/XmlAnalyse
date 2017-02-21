namespace XmlAnalyser.Business.devexpresstools
{
    partial class DevHeaderview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevHeaderview));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxLeereZeichne = new DevExpress.XtraEditors.CheckEdit();
            this.checkBoxFilterLeere = new DevExpress.XtraEditors.CheckEdit();
            this.checkBoxFilterDuplicates = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioButtonClear = new System.Windows.Forms.RadioButton();
            this.radioButtonSortenD = new System.Windows.Forms.RadioButton();
            this.radioButtonSortenA = new System.Windows.Forms.RadioButton();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxLeereZeichne.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFilterLeere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFilterDuplicates.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSort);
            this.groupBox2.Controls.Add(this.radioButtonClear);
            this.groupBox2.Controls.Add(this.radioButtonSortenD);
            this.groupBox2.Controls.Add(this.radioButtonSortenA);
            this.groupBox2.Location = new System.Drawing.Point(286, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 75);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sortierung";
            // 
            // checkBoxLeereZeichne
            // 
            this.checkBoxLeereZeichne.Location = new System.Drawing.Point(117, 56);
            this.checkBoxLeereZeichne.Name = "checkBoxLeereZeichne";
            this.checkBoxLeereZeichne.Properties.Caption = "Leerzeichen entfernen";
            this.checkBoxLeereZeichne.Size = new System.Drawing.Size(163, 19);
            this.checkBoxLeereZeichne.TabIndex = 16;
            this.checkBoxLeereZeichne.CheckedChanged += new System.EventHandler(this.checkBoxLeereZeichne_CheckedChanged);
            // 
            // checkBoxFilterLeere
            // 
            this.checkBoxFilterLeere.Location = new System.Drawing.Point(117, 27);
            this.checkBoxFilterLeere.Name = "checkBoxFilterLeere";
            this.checkBoxFilterLeere.Properties.Caption = "Leere Einträge entfernen";
            this.checkBoxFilterLeere.Size = new System.Drawing.Size(163, 19);
            this.checkBoxFilterLeere.TabIndex = 15;
            this.checkBoxFilterLeere.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // checkBoxFilterDuplicates
            // 
            this.checkBoxFilterDuplicates.Location = new System.Drawing.Point(117, 2);
            this.checkBoxFilterDuplicates.Name = "checkBoxFilterDuplicates";
            this.checkBoxFilterDuplicates.Properties.Caption = "Doppelte Einträge entfernen";
            this.checkBoxFilterDuplicates.Size = new System.Drawing.Size(163, 19);
            this.checkBoxFilterDuplicates.TabIndex = 14;
            this.checkBoxFilterDuplicates.CheckedChanged += new System.EventHandler(this.checkBoxFilterDuplicates_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(3, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 72);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioButtonClear
            // 
            this.radioButtonClear.AutoSize = true;
            this.radioButtonClear.Location = new System.Drawing.Point(147, 44);
            this.radioButtonClear.Name = "radioButtonClear";
            this.radioButtonClear.Size = new System.Drawing.Size(102, 17);
            this.radioButtonClear.TabIndex = 6;
            this.radioButtonClear.TabStop = true;
            this.radioButtonClear.Text = "Ohne Sortierung";
            this.radioButtonClear.UseVisualStyleBackColor = true;
            this.radioButtonClear.CheckedChanged += new System.EventHandler(this.radioButtonClear_CheckedChanged);
            // 
            // radioButtonSortenD
            // 
            this.radioButtonSortenD.AutoSize = true;
            this.radioButtonSortenD.Location = new System.Drawing.Point(78, 44);
            this.radioButtonSortenD.Name = "radioButtonSortenD";
            this.radioButtonSortenD.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSortenD.TabIndex = 5;
            this.radioButtonSortenD.TabStop = true;
            this.radioButtonSortenD.Text = "Abwärts";
            this.radioButtonSortenD.UseVisualStyleBackColor = true;
            this.radioButtonSortenD.CheckedChanged += new System.EventHandler(this.radioButtonSortenD_CheckedChanged);
            // 
            // radioButtonSortenA
            // 
            this.radioButtonSortenA.AutoSize = true;
            this.radioButtonSortenA.Location = new System.Drawing.Point(6, 44);
            this.radioButtonSortenA.Name = "radioButtonSortenA";
            this.radioButtonSortenA.Size = new System.Drawing.Size(66, 17);
            this.radioButtonSortenA.TabIndex = 4;
            this.radioButtonSortenA.TabStop = true;
            this.radioButtonSortenA.Text = "Aufwärts";
            this.radioButtonSortenA.UseVisualStyleBackColor = true;
            this.radioButtonSortenA.CheckedChanged += new System.EventHandler(this.radioButtonSortenA_CheckedChanged);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Numerisch",
            "Alpha",
            "Datum"});
            this.comboBoxSort.Location = new System.Drawing.Point(6, 17);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(241, 21);
            this.comboBoxSort.TabIndex = 7;
            this.comboBoxSort.Text = "Alpha";
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DevHeaderview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxLeereZeichne);
            this.Controls.Add(this.checkBoxFilterLeere);
            this.Controls.Add(this.checkBoxFilterDuplicates);
            this.Controls.Add(this.simpleButton1);
            this.Name = "DevHeaderview";
            this.Size = new System.Drawing.Size(557, 83);
            this.Load += new System.EventHandler(this.DevHeaderview_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxLeereZeichne.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFilterLeere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFilterDuplicates.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckEdit checkBoxLeereZeichne;
        private DevExpress.XtraEditors.CheckEdit checkBoxFilterLeere;
        private DevExpress.XtraEditors.CheckEdit checkBoxFilterDuplicates;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.RadioButton radioButtonClear;
        private System.Windows.Forms.RadioButton radioButtonSortenD;
        private System.Windows.Forms.RadioButton radioButtonSortenA;
        private System.Windows.Forms.ComboBox comboBoxSort;
    }
}
