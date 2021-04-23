
namespace IndustrialUnit.UI
{
  partial class MainGround
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
      this.applicationName = new System.Windows.Forms.Label();
      this.headerPanel = new System.Windows.Forms.Panel();
      this.sideChildPanel = new System.Windows.Forms.Panel();
      this.Admin_btn = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.Home_btn = new System.Windows.Forms.Button();
      this.ViewUnit_btn = new System.Windows.Forms.Button();
      this.centerChildPanel = new System.Windows.Forms.Panel();
      this.headerPanel.SuspendLayout();
      this.sideChildPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // applicationName
      // 
      this.applicationName.AutoSize = true;
      this.applicationName.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.applicationName.ForeColor = System.Drawing.Color.White;
      this.applicationName.Location = new System.Drawing.Point(3, 19);
      this.applicationName.Name = "applicationName";
      this.applicationName.Size = new System.Drawing.Size(168, 24);
      this.applicationName.TabIndex = 0;
      this.applicationName.Text = "applicationName";
      this.applicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // headerPanel
      // 
      this.headerPanel.BackColor = System.Drawing.Color.SteelBlue;
      this.headerPanel.Controls.Add(this.applicationName);
      this.headerPanel.Location = new System.Drawing.Point(0, 0);
      this.headerPanel.Name = "headerPanel";
      this.headerPanel.Size = new System.Drawing.Size(250, 60);
      this.headerPanel.TabIndex = 1;
      this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
      // 
      // sideChildPanel
      // 
      this.sideChildPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.sideChildPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.sideChildPanel.Controls.Add(this.Admin_btn);
      this.sideChildPanel.Controls.Add(this.button1);
      this.sideChildPanel.Controls.Add(this.Home_btn);
      this.sideChildPanel.Controls.Add(this.ViewUnit_btn);
      this.sideChildPanel.Location = new System.Drawing.Point(-1, 59);
      this.sideChildPanel.Name = "sideChildPanel";
      this.sideChildPanel.Size = new System.Drawing.Size(250, 541);
      this.sideChildPanel.TabIndex = 0;
      // 
      // Admin_btn
      // 
      this.Admin_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Admin_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.Admin_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.Admin_btn.FlatAppearance.BorderSize = 0;
      this.Admin_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Admin_btn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Admin_btn.ForeColor = System.Drawing.Color.White;
      this.Admin_btn.Location = new System.Drawing.Point(1, 483);
      this.Admin_btn.Name = "Admin_btn";
      this.Admin_btn.Size = new System.Drawing.Size(250, 46);
      this.Admin_btn.TabIndex = 26;
      this.Admin_btn.TabStop = false;
      this.Admin_btn.Text = "Admin";
      this.Admin_btn.UseVisualStyleBackColor = false;
      this.Admin_btn.Click += new System.EventHandler(this.Admin_btn_Click);
      // 
      // button1
      // 
      this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(1, 111);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(250, 46);
      this.button1.TabIndex = 27;
      this.button1.TabStop = false;
      this.button1.Text = "Create custom collection";
      this.button1.UseVisualStyleBackColor = false;
      // 
      // Home_btn
      // 
      this.Home_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Home_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.Home_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.Home_btn.FlatAppearance.BorderSize = 0;
      this.Home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Home_btn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Home_btn.ForeColor = System.Drawing.Color.White;
      this.Home_btn.Location = new System.Drawing.Point(1, 7);
      this.Home_btn.Name = "Home_btn";
      this.Home_btn.Size = new System.Drawing.Size(250, 46);
      this.Home_btn.TabIndex = 25;
      this.Home_btn.TabStop = false;
      this.Home_btn.Text = "Home";
      this.Home_btn.UseVisualStyleBackColor = false;
      this.Home_btn.Click += new System.EventHandler(this.Home_btn_Click);
      // 
      // ViewUnit_btn
      // 
      this.ViewUnit_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ViewUnit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ViewUnit_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.ViewUnit_btn.FlatAppearance.BorderSize = 0;
      this.ViewUnit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ViewUnit_btn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ViewUnit_btn.ForeColor = System.Drawing.Color.White;
      this.ViewUnit_btn.Location = new System.Drawing.Point(1, 59);
      this.ViewUnit_btn.Name = "ViewUnit_btn";
      this.ViewUnit_btn.Size = new System.Drawing.Size(250, 46);
      this.ViewUnit_btn.TabIndex = 22;
      this.ViewUnit_btn.TabStop = false;
      this.ViewUnit_btn.Text = "View Unit";
      this.ViewUnit_btn.UseVisualStyleBackColor = false;
      // 
      // centerChildPanel
      // 
      this.centerChildPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
      this.centerChildPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.centerChildPanel.BackColor = System.Drawing.Color.LightCoral;
      this.centerChildPanel.Location = new System.Drawing.Point(249, 0);
      this.centerChildPanel.Name = "centerChildPanel";
      this.centerChildPanel.Size = new System.Drawing.Size(751, 600);
      this.centerChildPanel.TabIndex = 3;
      this.centerChildPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.centerChildPanel_Paint);
      // 
      // MainGround
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gainsboro;
      this.ClientSize = new System.Drawing.Size(1000, 600);
      this.Controls.Add(this.centerChildPanel);
      this.Controls.Add(this.headerPanel);
      this.Controls.Add(this.sideChildPanel);
      this.ForeColor = System.Drawing.Color.Black;
      this.Name = "MainGround";
      this.Text = "MainGround";
      this.Load += new System.EventHandler(this.LogoMethod);
      this.headerPanel.ResumeLayout(false);
      this.headerPanel.PerformLayout();
      this.sideChildPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Label applicationName;
    private System.Windows.Forms.Panel headerPanel;
    private System.Windows.Forms.Panel sideChildPanel;
    private System.Windows.Forms.Button Admin_btn;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button Home_btn;
    private System.Windows.Forms.Button ViewUnit_btn;
    private System.Windows.Forms.Panel centerChildPanel;
  }
}

