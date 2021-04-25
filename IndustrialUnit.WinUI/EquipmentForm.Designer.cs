
namespace IndustrialUnit.WinUI
{
  partial class EquipmentForm
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.itemType_lbl = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.equipment_lbl = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.capacity_lbl = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.pressure_lbl = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.powerConsumption_lbl = new System.Windows.Forms.Label();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.manufacturer_lbl = new System.Windows.Forms.Label();
      this.textBox6 = new System.Windows.Forms.TextBox();
      this.model_lbl = new System.Windows.Forms.Label();
      this.textBox7 = new System.Windows.Forms.TextBox();
      this.unitPrice_lbl = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
      this.panel1.Controls.Add(this.textBox7);
      this.panel1.Controls.Add(this.unitPrice_lbl);
      this.panel1.Controls.Add(this.textBox6);
      this.panel1.Controls.Add(this.model_lbl);
      this.panel1.Controls.Add(this.textBox5);
      this.panel1.Controls.Add(this.manufacturer_lbl);
      this.panel1.Controls.Add(this.textBox4);
      this.panel1.Controls.Add(this.powerConsumption_lbl);
      this.panel1.Controls.Add(this.textBox3);
      this.panel1.Controls.Add(this.pressure_lbl);
      this.panel1.Controls.Add(this.textBox2);
      this.panel1.Controls.Add(this.capacity_lbl);
      this.panel1.Controls.Add(this.equipment_lbl);
      this.panel1.Controls.Add(this.textBox1);
      this.panel1.Controls.Add(this.itemType_lbl);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(650, 385);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // itemType_lbl
      // 
      this.itemType_lbl.AutoSize = true;
      this.itemType_lbl.Location = new System.Drawing.Point(23, 83);
      this.itemType_lbl.Name = "itemType_lbl";
      this.itemType_lbl.Size = new System.Drawing.Size(53, 13);
      this.itemType_lbl.TabIndex = 0;
      this.itemType_lbl.Text = "Item type:";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(132, 80);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 1;
      // 
      // equipment_lbl
      // 
      this.equipment_lbl.AutoSize = true;
      this.equipment_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.equipment_lbl.Location = new System.Drawing.Point(334, 21);
      this.equipment_lbl.Name = "equipment_lbl";
      this.equipment_lbl.Size = new System.Drawing.Size(123, 25);
      this.equipment_lbl.TabIndex = 2;
      this.equipment_lbl.Text = "Equipment";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(132, 106);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 20);
      this.textBox2.TabIndex = 4;
      // 
      // capacity_lbl
      // 
      this.capacity_lbl.AutoSize = true;
      this.capacity_lbl.Location = new System.Drawing.Point(23, 109);
      this.capacity_lbl.Name = "capacity_lbl";
      this.capacity_lbl.Size = new System.Drawing.Size(51, 13);
      this.capacity_lbl.TabIndex = 3;
      this.capacity_lbl.Text = "Capacity:";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(132, 132);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(100, 20);
      this.textBox3.TabIndex = 6;
      // 
      // pressure_lbl
      // 
      this.pressure_lbl.AutoSize = true;
      this.pressure_lbl.Location = new System.Drawing.Point(23, 135);
      this.pressure_lbl.Name = "pressure_lbl";
      this.pressure_lbl.Size = new System.Drawing.Size(51, 13);
      this.pressure_lbl.TabIndex = 5;
      this.pressure_lbl.Text = "Pressure:";
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(132, 158);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(100, 20);
      this.textBox4.TabIndex = 8;
      // 
      // powerConsumption_lbl
      // 
      this.powerConsumption_lbl.AutoSize = true;
      this.powerConsumption_lbl.Location = new System.Drawing.Point(23, 161);
      this.powerConsumption_lbl.Name = "powerConsumption_lbl";
      this.powerConsumption_lbl.Size = new System.Drawing.Size(103, 13);
      this.powerConsumption_lbl.TabIndex = 7;
      this.powerConsumption_lbl.Text = "Power consumption:";
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(132, 184);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(100, 20);
      this.textBox5.TabIndex = 10;
      // 
      // manufacturer_lbl
      // 
      this.manufacturer_lbl.AutoSize = true;
      this.manufacturer_lbl.Location = new System.Drawing.Point(23, 187);
      this.manufacturer_lbl.Name = "manufacturer_lbl";
      this.manufacturer_lbl.Size = new System.Drawing.Size(73, 13);
      this.manufacturer_lbl.TabIndex = 9;
      this.manufacturer_lbl.Text = "Manufacturer:";
      // 
      // textBox6
      // 
      this.textBox6.Location = new System.Drawing.Point(132, 210);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new System.Drawing.Size(100, 20);
      this.textBox6.TabIndex = 12;
      // 
      // model_lbl
      // 
      this.model_lbl.AutoSize = true;
      this.model_lbl.Location = new System.Drawing.Point(23, 213);
      this.model_lbl.Name = "model_lbl";
      this.model_lbl.Size = new System.Drawing.Size(39, 13);
      this.model_lbl.TabIndex = 11;
      this.model_lbl.Text = "Model:";
      // 
      // textBox7
      // 
      this.textBox7.Location = new System.Drawing.Point(132, 236);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new System.Drawing.Size(100, 20);
      this.textBox7.TabIndex = 14;
      // 
      // unitPrice_lbl
      // 
      this.unitPrice_lbl.AutoSize = true;
      this.unitPrice_lbl.Location = new System.Drawing.Point(23, 239);
      this.unitPrice_lbl.Name = "unitPrice_lbl";
      this.unitPrice_lbl.Size = new System.Drawing.Size(55, 13);
      this.unitPrice_lbl.TabIndex = 13;
      this.unitPrice_lbl.Text = "Unit price:";
      // 
      // EquipmentForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(650, 385);
      this.Controls.Add(this.panel1);
      this.Name = "EquipmentForm";
      this.Text = "EquipmentForm";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label itemType_lbl;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label equipment_lbl;
    private System.Windows.Forms.TextBox textBox7;
    private System.Windows.Forms.Label unitPrice_lbl;
    private System.Windows.Forms.TextBox textBox6;
    private System.Windows.Forms.Label model_lbl;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.Label manufacturer_lbl;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label powerConsumption_lbl;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label pressure_lbl;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label capacity_lbl;
  }
}