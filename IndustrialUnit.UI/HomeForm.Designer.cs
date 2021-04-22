
namespace IndustrialUnit.UI
{
  partial class HomeForm
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
      this.HOME_lbl = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // HOME_lbl
      // 
      this.HOME_lbl.AutoSize = true;
      this.HOME_lbl.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HOME_lbl.Location = new System.Drawing.Point(356, 196);
      this.HOME_lbl.Name = "HOME_lbl";
      this.HOME_lbl.Size = new System.Drawing.Size(79, 26);
      this.HOME_lbl.TabIndex = 0;
      this.HOME_lbl.Text = "HOME";
      // 
      // HomeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkSeaGreen;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.HOME_lbl);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "HomeForm";
      this.Text = "HomeForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label HOME_lbl;
  }
}