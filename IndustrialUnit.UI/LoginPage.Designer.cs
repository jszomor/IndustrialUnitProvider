
namespace IndustrialUnit.UI
{
  partial class LoginForm
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
      this.login_btn = new System.Windows.Forms.Button();
      this.logout_btn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // login_btn
      // 
      this.login_btn.Location = new System.Drawing.Point(369, 186);
      this.login_btn.Name = "login_btn";
      this.login_btn.Size = new System.Drawing.Size(75, 23);
      this.login_btn.TabIndex = 0;
      this.login_btn.Text = "Login";
      this.login_btn.UseVisualStyleBackColor = true;
      this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
      // 
      // logout_btn
      // 
      this.logout_btn.Location = new System.Drawing.Point(369, 246);
      this.logout_btn.Name = "logout_btn";
      this.logout_btn.Size = new System.Drawing.Size(75, 23);
      this.logout_btn.TabIndex = 1;
      this.logout_btn.Text = "Logout";
      this.logout_btn.UseVisualStyleBackColor = true;
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.logout_btn);
      this.Controls.Add(this.login_btn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "LoginForm";
      this.Text = "LoginPage";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button login_btn;
    private System.Windows.Forms.Button logout_btn;
  }
}