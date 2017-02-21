namespace XmlAnalyser.UserInterface
{
    partial class MainView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.devHeaderview1 = new XmlAnalyser.Business.devexpresstools.DevHeaderview();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.structureInfoView1 = new XmlAnalyser.UserInterface.StructureInfoView();
            this.devDataInfo1 = new XmlAnalyser.Business.devexpresstools.DevDataInfo();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.devHeaderview1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 94);
            this.panel1.TabIndex = 0;
            // 
            // devHeaderview1
            // 
            this.devHeaderview1.BackColor = System.Drawing.Color.LightGray;
            this.devHeaderview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devHeaderview1.Location = new System.Drawing.Point(0, 0);
            this.devHeaderview1.Name = "devHeaderview1";
            this.devHeaderview1.Size = new System.Drawing.Size(934, 94);
            this.devHeaderview1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Panel1.Controls.Add(this.structureInfoView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.splitContainer1.Panel2.Controls.Add(this.devDataInfo1);
            this.splitContainer1.Size = new System.Drawing.Size(934, 373);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 1;
            // 
            // structureInfoView1
            // 
            this.structureInfoView1.BackColor = System.Drawing.Color.SlateBlue;
            this.structureInfoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structureInfoView1.Location = new System.Drawing.Point(0, 0);
            this.structureInfoView1.Name = "structureInfoView1";
            this.structureInfoView1.Size = new System.Drawing.Size(311, 373);
            this.structureInfoView1.TabIndex = 0;
            // 
            // devDataInfo1
            // 
            this.devDataInfo1.BackColor = System.Drawing.Color.LightGray;
            this.devDataInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devDataInfo1.Location = new System.Drawing.Point(0, 0);
            this.devDataInfo1.Name = "devDataInfo1";
            this.devDataInfo1.Size = new System.Drawing.Size(619, 373);
            this.devDataInfo1.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 467);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private StructureInfoView structureInfoView1;
        private Business.devexpresstools.DevHeaderview devHeaderview1;
        private Business.devexpresstools.DevDataInfo devDataInfo1;
    }
}