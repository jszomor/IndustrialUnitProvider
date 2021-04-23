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

    private Form activeCenterForm = null;
    public void OpenCenterChildForm(Form childCenterForm)
    {
      if(activeCenterForm != null)
      {
        activeCenterForm.Close();
      }
      activeCenterForm = childCenterForm;
      childCenterForm.TopLevel = false;
      childCenterForm.FormBorderStyle = FormBorderStyle.None;
      childCenterForm.Dock = DockStyle.Top;
      centerChildPanel.Controls.Add(childCenterForm);
      childCenterForm.BringToFront();
      childCenterForm.Show();
    }

    private Form activeSideForm = null;
    public void OpenSideChildForm(Form childSideForm)
    {
      if (activeSideForm != null)
      {
        activeSideForm.Close();
      }
      activeSideForm = childSideForm;
      childSideForm.TopLevel = false;
      childSideForm.FormBorderStyle = FormBorderStyle.None;
      childSideForm.Dock = DockStyle.Top;
      sideChildPanel.Controls.Add(childSideForm);
      childSideForm.BringToFront();
      childSideForm.Show();
    }

    private void headerPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Admin_btn_Click(object sender, EventArgs e)
    {
      OpenCenterChildForm(new AdminPage());
    }

    private void Home_btn_Click(object sender, EventArgs e)
    {
      OpenCenterChildForm(new HomeForm());
    }

    private void Insert_btn_Click(object sender, EventArgs e)
    {

    }

    private void centerChildPanel_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
