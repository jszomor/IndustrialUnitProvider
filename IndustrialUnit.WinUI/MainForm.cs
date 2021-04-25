using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialUnit.WinUI
{
  public partial class MainForm : Form
  {

    private Form activeForm { get; set; }

    public MainForm()
    {
      InitializeComponent();
    }

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
      this.mainPanelForChildForm.Controls.Add(childForm);
      this.mainPanelForChildForm.Tag = childForm;
      childForm.BringToFront();
      childForm.Show();
    }

    private void SelectUnitToolStripMenuItem2_Click(object sender, EventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void ChildPanel(object sender, PaintEventArgs e)
    {

    }

    private void fileToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void loadCollectionToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void equipmentToolStripMenuItem3_Click(object sender, EventArgs e)
    {
      OpenChildForm(new EquipmentForm());
    }

    private void valveToolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void instrumentToolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
  }
}
