namespace IndustrialUnit.WinUI
{
  partial class MainForm
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
      this.menuStrip2 = new System.Windows.Forms.MenuStrip();
      this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.equipmentToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.valveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.instrumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mainPanelForChildForm = new System.Windows.Forms.Panel();
      this.menuStrip2.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip2
      // 
      this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip2.Location = new System.Drawing.Point(0, 0);
      this.menuStrip2.Name = "menuStrip2";
      this.menuStrip2.Size = new System.Drawing.Size(984, 24);
      this.menuStrip2.TabIndex = 4;
      this.menuStrip2.Text = "menuStrip2";
      // 
      // homeToolStripMenuItem
      // 
      this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
      this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.homeToolStripMenuItem.Text = "Home";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCollectionToolStripMenuItem,
            this.saveCollectionToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
      // 
      // loadCollectionToolStripMenuItem
      // 
      this.loadCollectionToolStripMenuItem.Name = "loadCollectionToolStripMenuItem";
      this.loadCollectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.loadCollectionToolStripMenuItem.Text = "Load collection";
      this.loadCollectionToolStripMenuItem.Click += new System.EventHandler(this.loadCollectionToolStripMenuItem_Click);
      // 
      // saveCollectionToolStripMenuItem
      // 
      this.saveCollectionToolStripMenuItem.Name = "saveCollectionToolStripMenuItem";
      this.saveCollectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.saveCollectionToolStripMenuItem.Text = "Save collection";
      this.saveCollectionToolStripMenuItem.Click += new System.EventHandler(this.saveCollectionToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // unitToolStripMenuItem
      // 
      this.unitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem3,
            this.valveToolStripMenuItem1,
            this.instrumentToolStripMenuItem1});
      this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
      this.unitToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
      this.unitToolStripMenuItem.Text = "Item category";
      this.unitToolStripMenuItem.Click += new System.EventHandler(this.SelectUnitToolStripMenuItem2_Click);
      // 
      // equipmentToolStripMenuItem3
      // 
      this.equipmentToolStripMenuItem3.Name = "equipmentToolStripMenuItem3";
      this.equipmentToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
      this.equipmentToolStripMenuItem3.Text = "Equipment";
      this.equipmentToolStripMenuItem3.Click += new System.EventHandler(this.equipmentToolStripMenuItem3_Click);
      // 
      // valveToolStripMenuItem1
      // 
      this.valveToolStripMenuItem1.Name = "valveToolStripMenuItem1";
      this.valveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.valveToolStripMenuItem1.Text = "Valve";
      this.valveToolStripMenuItem1.Click += new System.EventHandler(this.valveToolStripMenuItem1_Click);
      // 
      // instrumentToolStripMenuItem1
      // 
      this.instrumentToolStripMenuItem1.Name = "instrumentToolStripMenuItem1";
      this.instrumentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.instrumentToolStripMenuItem1.Text = "Instrument";
      this.instrumentToolStripMenuItem1.Click += new System.EventHandler(this.instrumentToolStripMenuItem1_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
      // 
      // contentsToolStripMenuItem
      // 
      this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
      this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.contentsToolStripMenuItem.Text = "&Contents";
      // 
      // indexToolStripMenuItem
      // 
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.indexToolStripMenuItem.Text = "&Index";
      // 
      // searchToolStripMenuItem
      // 
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.searchToolStripMenuItem.Text = "&Search";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      // 
      // mainPanelForChildForm
      // 
      this.mainPanelForChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanelForChildForm.Location = new System.Drawing.Point(0, 24);
      this.mainPanelForChildForm.Name = "mainPanelForChildForm";
      this.mainPanelForChildForm.Size = new System.Drawing.Size(984, 537);
      this.mainPanelForChildForm.TabIndex = 5;
      this.mainPanelForChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.ChildPanel);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(984, 561);
      this.Controls.Add(this.mainPanelForChildForm);
      this.Controls.Add(this.menuStrip2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.MinimumSize = new System.Drawing.Size(1000, 600);
      this.Name = "MainForm";
      this.Text = "Industrial Unit Manager";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.menuStrip2.ResumeLayout(false);
      this.menuStrip2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem valveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem1;
        private System.Windows.Forms.Panel mainPanelForChildForm;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
    }
}

