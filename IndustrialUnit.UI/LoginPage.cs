using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialUnit.UI
{
  public partial class LoginForm : Form
  {
    public LoginForm()
    {
      InitializeComponent();
    }

    private void login_btn_Click(object sender, EventArgs e)
    {
      this.Hide();
      AdminPage adminPage = new AdminPage();
      adminPage.Show();
      this.Close();
    }
  }
}
