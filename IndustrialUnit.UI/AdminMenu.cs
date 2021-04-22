using System;
using System.Windows.Forms;

namespace IndustrialUnit.UI
{
  public partial class AdminMenu : Form
  {
    public AdminMenu()
    {
      InitializeComponent();
    }

    private void LogoMethod(object sender, EventArgs e)
    {
      applicationName.Text = "Industrial Unit Manager";
    }

    private void Insert_btn_Click(object sender, EventArgs e)
    {
      //Insert_btn.FlatAppearance.BorderColor = Color.Black;
    }

    private void Home_btn_Click(object sender, EventArgs e)
    {

    }
  }
}
