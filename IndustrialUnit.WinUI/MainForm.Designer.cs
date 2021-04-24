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
      this.UnitTypecomboBox = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.equipmentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.menuStrip2 = new System.Windows.Forms.MenuStrip();
      this.equipmentToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.valveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.equipmentToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.valveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.instrumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.menuStrip2.SuspendLayout();
      this.SuspendLayout();
      // 
      // UnitTypecomboBox
      // 
      this.UnitTypecomboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Equipment",
            "Valve",
            "Instrument"});
      this.UnitTypecomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
      this.UnitTypecomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.UnitTypecomboBox.FormattingEnabled = true;
      this.UnitTypecomboBox.Items.AddRange(new object[] {
            "Equipment",
            "Valve",
            "Instrument"});
      this.UnitTypecomboBox.Location = new System.Drawing.Point(0, 80);
      this.UnitTypecomboBox.Name = "UnitTypecomboBox";
      this.UnitTypecomboBox.Size = new System.Drawing.Size(121, 21);
      this.UnitTypecomboBox.TabIndex = 2;
      this.UnitTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.listBox1);
      this.groupBox1.Controls.Add(this.UnitTypecomboBox);
      this.groupBox1.Controls.Add(this.menuStrip1);
      this.groupBox1.Location = new System.Drawing.Point(40, 105);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(231, 282);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem,
            this.equipmentToolStripMenuItem1});
      this.menuStrip1.Location = new System.Drawing.Point(3, 16);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(225, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
      // 
      // equipmentToolStripMenuItem
      // 
      this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
      this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
      this.equipmentToolStripMenuItem.Text = "Equipment";
      // 
      // equipmentToolStripMenuItem1
      // 
      this.equipmentToolStripMenuItem1.Name = "equipmentToolStripMenuItem1";
      this.equipmentToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
      this.equipmentToolStripMenuItem1.Text = "Valve";
      this.equipmentToolStripMenuItem1.Click += new System.EventHandler(this.equipmentToolStripMenuItem1_Click);
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Items.AddRange(new object[] {
            "Equipment",
            "Valve",
            "Instrument"});
      this.listBox1.Location = new System.Drawing.Point(79, 141);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(120, 95);
      this.listBox1.TabIndex = 4;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // menuStrip2
      // 
      this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem2,
            this.valveToolStripMenuItem,
            this.instrumentToolStripMenuItem});
      this.menuStrip2.Location = new System.Drawing.Point(0, 0);
      this.menuStrip2.Name = "menuStrip2";
      this.menuStrip2.Size = new System.Drawing.Size(800, 24);
      this.menuStrip2.TabIndex = 4;
      this.menuStrip2.Text = "menuStrip2";
      // 
      // equipmentToolStripMenuItem2
      // 
      this.equipmentToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem3,
            this.valveToolStripMenuItem1,
            this.instrumentToolStripMenuItem1});
      this.equipmentToolStripMenuItem2.Name = "equipmentToolStripMenuItem2";
      this.equipmentToolStripMenuItem2.Size = new System.Drawing.Size(96, 20);
      this.equipmentToolStripMenuItem2.Text = "SelectUnitType";
      this.equipmentToolStripMenuItem2.Click += new System.EventHandler(this.equipmentToolStripMenuItem2_Click);
      // 
      // valveToolStripMenuItem
      // 
      this.valveToolStripMenuItem.Name = "valveToolStripMenuItem";
      this.valveToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
      this.valveToolStripMenuItem.Text = "Insert collection";
      this.valveToolStripMenuItem.Click += new System.EventHandler(this.valveToolStripMenuItem_Click);
      // 
      // instrumentToolStripMenuItem
      // 
      this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
      this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
      this.instrumentToolStripMenuItem.Text = "Create custom collection";
      this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
      // 
      // equipmentToolStripMenuItem3
      // 
      this.equipmentToolStripMenuItem3.Name = "equipmentToolStripMenuItem3";
      this.equipmentToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
      this.equipmentToolStripMenuItem3.Text = "Equipment";
      // 
      // valveToolStripMenuItem1
      // 
      this.valveToolStripMenuItem1.Name = "valveToolStripMenuItem1";
      this.valveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.valveToolStripMenuItem1.Text = "Valve";
      // 
      // instrumentToolStripMenuItem1
      // 
      this.instrumentToolStripMenuItem1.Name = "instrumentToolStripMenuItem1";
      this.instrumentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.instrumentToolStripMenuItem1.Text = "Instrument";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.menuStrip2);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.menuStrip2.ResumeLayout(false);
      this.menuStrip2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox UnitTypecomboBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.MenuStrip menuStrip2;
    private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem valveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem valveToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem1;
  }
}

