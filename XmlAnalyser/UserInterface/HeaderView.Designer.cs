namespace XmlAnalyser.UserInterface
{
    partial class HeaderView
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
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.checkBoxFilterDuplicates = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterLeere = new System.Windows.Forms.CheckBox();
            this.checkBoxLeereZeichne = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonClear = new System.Windows.Forms.RadioButton();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.radioButtonSortenD = new System.Windows.Forms.RadioButton();
            this.radioButtonSortenA = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonFileOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFileOpen.Location = new System.Drawing.Point(3, 6);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(108, 72);
            this.buttonFileOpen.TabIndex = 0;
            this.buttonFileOpen.Text = "XML-Datei öffnen";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxFilterDuplicates
            // 
            this.checkBoxFilterDuplicates.AutoSize = true;
            this.checkBoxFilterDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterDuplicates.Location = new System.Drawing.Point(117, 3);
            this.checkBoxFilterDuplicates.Name = "checkBoxFilterDuplicates";
            this.checkBoxFilterDuplicates.Size = new System.Drawing.Size(206, 21);
            this.checkBoxFilterDuplicates.TabIndex = 1;
            this.checkBoxFilterDuplicates.Text = "Doppelte Einträge entfernen";
            this.checkBoxFilterDuplicates.UseVisualStyleBackColor = true;
            this.checkBoxFilterDuplicates.CheckedChanged += new System.EventHandler(this.checkBoxFilterDuplicates_CheckedChanged);
            // 
            // checkBoxFilterLeere
            // 
            this.checkBoxFilterLeere.AutoSize = true;
            this.checkBoxFilterLeere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterLeere.Location = new System.Drawing.Point(117, 23);
            this.checkBoxFilterLeere.Name = "checkBoxFilterLeere";
            this.checkBoxFilterLeere.Size = new System.Drawing.Size(186, 21);
            this.checkBoxFilterLeere.TabIndex = 2;
            this.checkBoxFilterLeere.Text = "Leere Einträge entfernen";
            this.checkBoxFilterLeere.UseVisualStyleBackColor = true;
            this.checkBoxFilterLeere.CheckedChanged += new System.EventHandler(this.checkBoxFilterLeere_CheckedChanged);
            // 
            // checkBoxLeereZeichne
            // 
            this.checkBoxLeereZeichne.AutoSize = true;
            this.checkBoxLeereZeichne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLeereZeichne.Location = new System.Drawing.Point(117, 42);
            this.checkBoxLeereZeichne.Name = "checkBoxLeereZeichne";
            this.checkBoxLeereZeichne.Size = new System.Drawing.Size(170, 21);
            this.checkBoxLeereZeichne.TabIndex = 3;
            this.checkBoxLeereZeichne.Text = "Leerzeichen entfernen";
            this.checkBoxLeereZeichne.UseVisualStyleBackColor = true;
            this.checkBoxLeereZeichne.CheckedChanged += new System.EventHandler(this.checkBoxLeereZeichne_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonClear);
            this.groupBox1.Controls.Add(this.comboBoxSort);
            this.groupBox1.Controls.Add(this.radioButtonSortenD);
            this.groupBox1.Controls.Add(this.radioButtonSortenA);
            this.groupBox1.Location = new System.Drawing.Point(329, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 75);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sortierung";
            // 
            // radioButtonClear
            // 
            this.radioButtonClear.AutoSize = true;
            this.radioButtonClear.Location = new System.Drawing.Point(147, 43);
            this.radioButtonClear.Name = "radioButtonClear";
            this.radioButtonClear.Size = new System.Drawing.Size(102, 17);
            this.radioButtonClear.TabIndex = 3;
            this.radioButtonClear.TabStop = true;
            this.radioButtonClear.Text = "Ohne Sortierung";
            this.radioButtonClear.UseVisualStyleBackColor = true;
            this.radioButtonClear.CheckedChanged += new System.EventHandler(this.radioButtonClear_CheckedChanged);
            this.radioButtonClear.Click += new System.EventHandler(this.radioButtonClear_Click);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Numerisch",
            "Alpha",
            "Datum"});
            this.comboBoxSort.Location = new System.Drawing.Point(6, 16);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(140, 21);
            this.comboBoxSort.TabIndex = 2;
            this.comboBoxSort.Text = "Alpha";
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // radioButtonSortenD
            // 
            this.radioButtonSortenD.AutoSize = true;
            this.radioButtonSortenD.Location = new System.Drawing.Point(78, 43);
            this.radioButtonSortenD.Name = "radioButtonSortenD";
            this.radioButtonSortenD.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSortenD.TabIndex = 1;
            this.radioButtonSortenD.TabStop = true;
            this.radioButtonSortenD.Text = "Abwärts";
            this.radioButtonSortenD.UseVisualStyleBackColor = true;
            this.radioButtonSortenD.CheckedChanged += new System.EventHandler(this.radioButtonSortenD_CheckedChanged);
            this.radioButtonSortenD.Click += new System.EventHandler(this.radioButtonSortenD_Click);
            // 
            // radioButtonSortenA
            // 
            this.radioButtonSortenA.AutoSize = true;
            this.radioButtonSortenA.Location = new System.Drawing.Point(6, 43);
            this.radioButtonSortenA.Name = "radioButtonSortenA";
            this.radioButtonSortenA.Size = new System.Drawing.Size(66, 17);
            this.radioButtonSortenA.TabIndex = 0;
            this.radioButtonSortenA.TabStop = true;
            this.radioButtonSortenA.Text = "Aufwärts";
            this.radioButtonSortenA.UseVisualStyleBackColor = true;
            this.radioButtonSortenA.CheckedChanged += new System.EventHandler(this.radioButtonSortenA_CheckedChanged);
            this.radioButtonSortenA.Click += new System.EventHandler(this.radioButtonSortenA_Click);
            // 
            // HeaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxLeereZeichne);
            this.Controls.Add(this.checkBoxFilterLeere);
            this.Controls.Add(this.checkBoxFilterDuplicates);
            this.Controls.Add(this.buttonFileOpen);
            this.Name = "HeaderView";
            this.Size = new System.Drawing.Size(630, 87);
            this.Load += new System.EventHandler(this.HeaderView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.CheckBox checkBoxFilterDuplicates;
        private System.Windows.Forms.CheckBox checkBoxFilterLeere;
        private System.Windows.Forms.CheckBox checkBoxLeereZeichne;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.RadioButton radioButtonSortenD;
        private System.Windows.Forms.RadioButton radioButtonSortenA;
        private System.Windows.Forms.RadioButton radioButtonClear;
    }
}
