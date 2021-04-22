using System;
using System.Windows.Forms;

namespace IndustrialUnit.UI
{
  public partial class MainGround : Form
  {
    public MainGround()
    {
      InitializeComponent();
    }

    private void LogoMethod(object sender, EventArgs e)
    {
      applicationName.Text = "Industrial Unit Manager";
    }

    private void Admin_btn_Click(object sender, EventArgs e)
    {
      OpenChildForm(new AdminMenu());
    }

    private void Home_btn_Click(object sender, EventArgs e)
    {
      OpenChildForm(new HomeForm());
    }


    private Form activeForm = null;
    private void OpenChildForm(Form childForm)
    {
      if(activeForm != null)
      {
        activeForm.Close();
      }
      activeForm = childForm;
      childForm.TopLevel = false;
      childForm.FormBorderStyle = FormBorderStyle.None;
      childForm.Dock = DockStyle.Fill;
      homeChildForm.Controls.Add(childForm);
      childForm.BringToFront();
      childForm.Show();
    }
  }
}
