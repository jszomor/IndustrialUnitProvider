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

    private void Insert_btn_Click(object sender, EventArgs e)
    {
      //Insert_btn.FlatAppearance.BorderColor = Color.Black;
    }
  }
}
