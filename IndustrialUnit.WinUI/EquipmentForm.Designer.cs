
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
      this.unitPrice_textBox = new System.Windows.Forms.TextBox();
      this.unitPrice_lbl = new System.Windows.Forms.Label();
      this.model_textBox = new System.Windows.Forms.TextBox();
      this.model_lbl = new System.Windows.Forms.Label();
      this.manufacturer_textBox = new System.Windows.Forms.TextBox();
      this.manufacturer_lbl = new System.Windows.Forms.Label();
      this.powerCons_textBox = new System.Windows.Forms.TextBox();
      this.powerConsumption_lbl = new System.Windows.Forms.Label();
      this.presssure_textBox = new System.Windows.Forms.TextBox();
      this.pressure_lbl = new System.Windows.Forms.Label();
      this.capacity_textBox = new System.Windows.Forms.TextBox();
      this.capacity_lbl = new System.Windows.Forms.Label();
      this.equipment_lbl = new System.Windows.Forms.Label();
      this.itemType_textBox = new System.Windows.Forms.TextBox();
      this.itemType_lbl = new System.Windows.Forms.Label();
      this.add_btn = new System.Windows.Forms.Button();
      this.edit_btn = new System.Windows.Forms.Button();
      this.delete_btn = new System.Windows.Forms.Button();
      this.DataGroupBox = new System.Windows.Forms.GroupBox();
      this.CustomListGroupBox = new System.Windows.Forms.GroupBox();
      this.idNumber_textBox = new System.Windows.Forms.TextBox();
      this.addCustomList_btn = new System.Windows.Forms.Button();
      this.removeCustomList_btn = new System.Windows.Forms.Button();
      this.IDForCustomList_lbl = new System.Windows.Forms.Label();
      this.quantity_lbl = new System.Windows.Forms.Label();
      this.id_lbl = new System.Windows.Forms.Label();
      this.id_textBox = new System.Windows.Forms.TextBox();
      this.viewData_groupBox = new System.Windows.Forms.GroupBox();
      this.search_btn = new System.Windows.Forms.Button();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.panel1.SuspendLayout();
      this.DataGroupBox.SuspendLayout();
      this.CustomListGroupBox.SuspendLayout();
      this.viewData_groupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
      this.panel1.Controls.Add(this.viewData_groupBox);
      this.panel1.Controls.Add(this.CustomListGroupBox);
      this.panel1.Controls.Add(this.DataGroupBox);
      this.panel1.Controls.Add(this.equipment_lbl);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1120, 640);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // unitPrice_textBox
      // 
      this.unitPrice_textBox.Location = new System.Drawing.Point(137, 215);
      this.unitPrice_textBox.Name = "unitPrice_textBox";
      this.unitPrice_textBox.Size = new System.Drawing.Size(120, 20);
      this.unitPrice_textBox.TabIndex = 14;
      // 
      // unitPrice_lbl
      // 
      this.unitPrice_lbl.AutoSize = true;
      this.unitPrice_lbl.Location = new System.Drawing.Point(28, 218);
      this.unitPrice_lbl.Name = "unitPrice_lbl";
      this.unitPrice_lbl.Size = new System.Drawing.Size(55, 13);
      this.unitPrice_lbl.TabIndex = 13;
      this.unitPrice_lbl.Text = "Unit price:";
      // 
      // model_textBox
      // 
      this.model_textBox.Location = new System.Drawing.Point(137, 189);
      this.model_textBox.Name = "model_textBox";
      this.model_textBox.Size = new System.Drawing.Size(120, 20);
      this.model_textBox.TabIndex = 12;
      // 
      // model_lbl
      // 
      this.model_lbl.AutoSize = true;
      this.model_lbl.Location = new System.Drawing.Point(28, 192);
      this.model_lbl.Name = "model_lbl";
      this.model_lbl.Size = new System.Drawing.Size(39, 13);
      this.model_lbl.TabIndex = 11;
      this.model_lbl.Text = "Model:";
      // 
      // manufacturer_textBox
      // 
      this.manufacturer_textBox.Location = new System.Drawing.Point(137, 163);
      this.manufacturer_textBox.Name = "manufacturer_textBox";
      this.manufacturer_textBox.Size = new System.Drawing.Size(120, 20);
      this.manufacturer_textBox.TabIndex = 10;
      // 
      // manufacturer_lbl
      // 
      this.manufacturer_lbl.AutoSize = true;
      this.manufacturer_lbl.Location = new System.Drawing.Point(28, 166);
      this.manufacturer_lbl.Name = "manufacturer_lbl";
      this.manufacturer_lbl.Size = new System.Drawing.Size(73, 13);
      this.manufacturer_lbl.TabIndex = 9;
      this.manufacturer_lbl.Text = "Manufacturer:";
      // 
      // powerCons_textBox
      // 
      this.powerCons_textBox.Location = new System.Drawing.Point(137, 137);
      this.powerCons_textBox.Name = "powerCons_textBox";
      this.powerCons_textBox.Size = new System.Drawing.Size(120, 20);
      this.powerCons_textBox.TabIndex = 8;
      // 
      // powerConsumption_lbl
      // 
      this.powerConsumption_lbl.AutoSize = true;
      this.powerConsumption_lbl.Location = new System.Drawing.Point(28, 140);
      this.powerConsumption_lbl.Name = "powerConsumption_lbl";
      this.powerConsumption_lbl.Size = new System.Drawing.Size(103, 13);
      this.powerConsumption_lbl.TabIndex = 7;
      this.powerConsumption_lbl.Text = "Power consumption:";
      // 
      // presssure_textBox
      // 
      this.presssure_textBox.Location = new System.Drawing.Point(137, 111);
      this.presssure_textBox.Name = "presssure_textBox";
      this.presssure_textBox.Size = new System.Drawing.Size(120, 20);
      this.presssure_textBox.TabIndex = 6;
      // 
      // pressure_lbl
      // 
      this.pressure_lbl.AutoSize = true;
      this.pressure_lbl.Location = new System.Drawing.Point(28, 114);
      this.pressure_lbl.Name = "pressure_lbl";
      this.pressure_lbl.Size = new System.Drawing.Size(51, 13);
      this.pressure_lbl.TabIndex = 5;
      this.pressure_lbl.Text = "Pressure:";
      // 
      // capacity_textBox
      // 
      this.capacity_textBox.Location = new System.Drawing.Point(137, 85);
      this.capacity_textBox.Name = "capacity_textBox";
      this.capacity_textBox.Size = new System.Drawing.Size(120, 20);
      this.capacity_textBox.TabIndex = 4;
      // 
      // capacity_lbl
      // 
      this.capacity_lbl.AutoSize = true;
      this.capacity_lbl.Location = new System.Drawing.Point(28, 88);
      this.capacity_lbl.Name = "capacity_lbl";
      this.capacity_lbl.Size = new System.Drawing.Size(51, 13);
      this.capacity_lbl.TabIndex = 3;
      this.capacity_lbl.Text = "Capacity:";
      // 
      // equipment_lbl
      // 
      this.equipment_lbl.AutoSize = true;
      this.equipment_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.equipment_lbl.Location = new System.Drawing.Point(393, 15);
      this.equipment_lbl.Name = "equipment_lbl";
      this.equipment_lbl.Size = new System.Drawing.Size(123, 25);
      this.equipment_lbl.TabIndex = 2;
      this.equipment_lbl.Text = "Equipment";
      // 
      // itemType_textBox
      // 
      this.itemType_textBox.Location = new System.Drawing.Point(137, 59);
      this.itemType_textBox.Name = "itemType_textBox";
      this.itemType_textBox.Size = new System.Drawing.Size(120, 20);
      this.itemType_textBox.TabIndex = 1;
      // 
      // itemType_lbl
      // 
      this.itemType_lbl.AutoSize = true;
      this.itemType_lbl.Location = new System.Drawing.Point(28, 62);
      this.itemType_lbl.Name = "itemType_lbl";
      this.itemType_lbl.Size = new System.Drawing.Size(53, 13);
      this.itemType_lbl.TabIndex = 0;
      this.itemType_lbl.Text = "Item type:";
      this.itemType_lbl.Click += new System.EventHandler(this.itemType_lbl_Click);
      // 
      // add_btn
      // 
      this.add_btn.Location = new System.Drawing.Point(6, 257);
      this.add_btn.Name = "add_btn";
      this.add_btn.Size = new System.Drawing.Size(60, 23);
      this.add_btn.TabIndex = 15;
      this.add_btn.Text = "ADD";
      this.add_btn.UseVisualStyleBackColor = true;
      // 
      // edit_btn
      // 
      this.edit_btn.Location = new System.Drawing.Point(82, 257);
      this.edit_btn.Name = "edit_btn";
      this.edit_btn.Size = new System.Drawing.Size(60, 23);
      this.edit_btn.TabIndex = 16;
      this.edit_btn.Text = "EDIT";
      this.edit_btn.UseVisualStyleBackColor = true;
      this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
      // 
      // delete_btn
      // 
      this.delete_btn.Location = new System.Drawing.Point(157, 257);
      this.delete_btn.Name = "delete_btn";
      this.delete_btn.Size = new System.Drawing.Size(60, 23);
      this.delete_btn.TabIndex = 17;
      this.delete_btn.Text = "DELETE";
      this.delete_btn.UseVisualStyleBackColor = true;
      this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
      // 
      // DataGroupBox
      // 
      this.DataGroupBox.Controls.Add(this.search_btn);
      this.DataGroupBox.Controls.Add(this.id_textBox);
      this.DataGroupBox.Controls.Add(this.id_lbl);
      this.DataGroupBox.Controls.Add(this.delete_btn);
      this.DataGroupBox.Controls.Add(this.edit_btn);
      this.DataGroupBox.Controls.Add(this.add_btn);
      this.DataGroupBox.Controls.Add(this.unitPrice_textBox);
      this.DataGroupBox.Controls.Add(this.unitPrice_lbl);
      this.DataGroupBox.Controls.Add(this.model_textBox);
      this.DataGroupBox.Controls.Add(this.model_lbl);
      this.DataGroupBox.Controls.Add(this.manufacturer_textBox);
      this.DataGroupBox.Controls.Add(this.manufacturer_lbl);
      this.DataGroupBox.Controls.Add(this.powerCons_textBox);
      this.DataGroupBox.Controls.Add(this.powerConsumption_lbl);
      this.DataGroupBox.Controls.Add(this.presssure_textBox);
      this.DataGroupBox.Controls.Add(this.pressure_lbl);
      this.DataGroupBox.Controls.Add(this.capacity_textBox);
      this.DataGroupBox.Controls.Add(this.capacity_lbl);
      this.DataGroupBox.Controls.Add(this.itemType_textBox);
      this.DataGroupBox.Controls.Add(this.itemType_lbl);
      this.DataGroupBox.Location = new System.Drawing.Point(12, 44);
      this.DataGroupBox.Name = "DataGroupBox";
      this.DataGroupBox.Size = new System.Drawing.Size(299, 300);
      this.DataGroupBox.TabIndex = 18;
      this.DataGroupBox.TabStop = false;
      this.DataGroupBox.Text = "Manipulate data";
      // 
      // CustomListGroupBox
      // 
      this.CustomListGroupBox.Controls.Add(this.numericUpDown1);
      this.CustomListGroupBox.Controls.Add(this.quantity_lbl);
      this.CustomListGroupBox.Controls.Add(this.IDForCustomList_lbl);
      this.CustomListGroupBox.Controls.Add(this.removeCustomList_btn);
      this.CustomListGroupBox.Controls.Add(this.addCustomList_btn);
      this.CustomListGroupBox.Controls.Add(this.idNumber_textBox);
      this.CustomListGroupBox.Location = new System.Drawing.Point(12, 365);
      this.CustomListGroupBox.Name = "CustomListGroupBox";
      this.CustomListGroupBox.Size = new System.Drawing.Size(299, 157);
      this.CustomListGroupBox.TabIndex = 19;
      this.CustomListGroupBox.TabStop = false;
      this.CustomListGroupBox.Text = "Create custom list";
      this.CustomListGroupBox.Enter += new System.EventHandler(this.CustomListGroupBox_Enter);
      // 
      // idNumber_textBox
      // 
      this.idNumber_textBox.Location = new System.Drawing.Point(137, 32);
      this.idNumber_textBox.Name = "idNumber_textBox";
      this.idNumber_textBox.Size = new System.Drawing.Size(66, 20);
      this.idNumber_textBox.TabIndex = 0;
      // 
      // addCustomList_btn
      // 
      this.addCustomList_btn.Location = new System.Drawing.Point(44, 104);
      this.addCustomList_btn.Name = "addCustomList_btn";
      this.addCustomList_btn.Size = new System.Drawing.Size(75, 23);
      this.addCustomList_btn.TabIndex = 2;
      this.addCustomList_btn.Text = "ADD";
      this.addCustomList_btn.UseVisualStyleBackColor = true;
      // 
      // removeCustomList_btn
      // 
      this.removeCustomList_btn.Location = new System.Drawing.Point(148, 103);
      this.removeCustomList_btn.Name = "removeCustomList_btn";
      this.removeCustomList_btn.Size = new System.Drawing.Size(75, 23);
      this.removeCustomList_btn.TabIndex = 3;
      this.removeCustomList_btn.Text = "REMOVE";
      this.removeCustomList_btn.UseVisualStyleBackColor = true;
      // 
      // IDForCustomList_lbl
      // 
      this.IDForCustomList_lbl.AutoSize = true;
      this.IDForCustomList_lbl.Location = new System.Drawing.Point(28, 39);
      this.IDForCustomList_lbl.Name = "IDForCustomList_lbl";
      this.IDForCustomList_lbl.Size = new System.Drawing.Size(59, 13);
      this.IDForCustomList_lbl.TabIndex = 4;
      this.IDForCustomList_lbl.Text = "ID number:";
      // 
      // quantity_lbl
      // 
      this.quantity_lbl.AutoSize = true;
      this.quantity_lbl.Location = new System.Drawing.Point(31, 65);
      this.quantity_lbl.Name = "quantity_lbl";
      this.quantity_lbl.Size = new System.Drawing.Size(46, 13);
      this.quantity_lbl.TabIndex = 5;
      this.quantity_lbl.Text = "Quantity";
      // 
      // id_lbl
      // 
      this.id_lbl.AutoSize = true;
      this.id_lbl.Location = new System.Drawing.Point(31, 41);
      this.id_lbl.Name = "id_lbl";
      this.id_lbl.Size = new System.Drawing.Size(21, 13);
      this.id_lbl.TabIndex = 18;
      this.id_lbl.Text = "ID:";
      // 
      // id_textBox
      // 
      this.id_textBox.Location = new System.Drawing.Point(137, 33);
      this.id_textBox.Name = "id_textBox";
      this.id_textBox.Size = new System.Drawing.Size(120, 20);
      this.id_textBox.TabIndex = 19;
      // 
      // viewData_groupBox
      // 
      this.viewData_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.viewData_groupBox.Controls.Add(this.dataGridView1);
      this.viewData_groupBox.Location = new System.Drawing.Point(326, 44);
      this.viewData_groupBox.Name = "viewData_groupBox";
      this.viewData_groupBox.Size = new System.Drawing.Size(772, 572);
      this.viewData_groupBox.TabIndex = 20;
      this.viewData_groupBox.TabStop = false;
      this.viewData_groupBox.Text = "View data";
      // 
      // search_btn
      // 
      this.search_btn.Location = new System.Drawing.Point(233, 257);
      this.search_btn.Name = "search_btn";
      this.search_btn.Size = new System.Drawing.Size(60, 23);
      this.search_btn.TabIndex = 20;
      this.search_btn.Text = "SEARCH";
      this.search_btn.UseVisualStyleBackColor = true;
      this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(137, 65);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(66, 20);
      this.numericUpDown1.TabIndex = 0;
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(7, 20);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(759, 546);
      this.dataGridView1.TabIndex = 0;
      // 
      // EquipmentForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1120, 640);
      this.Controls.Add(this.panel1);
      this.Name = "EquipmentForm";
      this.Text = "EquipmentForm";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.DataGroupBox.ResumeLayout(false);
      this.DataGroupBox.PerformLayout();
      this.CustomListGroupBox.ResumeLayout(false);
      this.CustomListGroupBox.PerformLayout();
      this.viewData_groupBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label itemType_lbl;
    private System.Windows.Forms.TextBox itemType_textBox;
    private System.Windows.Forms.Label equipment_lbl;
    private System.Windows.Forms.TextBox unitPrice_textBox;
    private System.Windows.Forms.Label unitPrice_lbl;
    private System.Windows.Forms.TextBox model_textBox;
    private System.Windows.Forms.Label model_lbl;
    private System.Windows.Forms.TextBox manufacturer_textBox;
    private System.Windows.Forms.Label manufacturer_lbl;
    private System.Windows.Forms.TextBox powerCons_textBox;
    private System.Windows.Forms.Label powerConsumption_lbl;
    private System.Windows.Forms.TextBox presssure_textBox;
    private System.Windows.Forms.Label pressure_lbl;
    private System.Windows.Forms.TextBox capacity_textBox;
    private System.Windows.Forms.Label capacity_lbl;
    private System.Windows.Forms.Button delete_btn;
    private System.Windows.Forms.Button edit_btn;
    private System.Windows.Forms.Button add_btn;
    private System.Windows.Forms.GroupBox CustomListGroupBox;
    private System.Windows.Forms.Label quantity_lbl;
    private System.Windows.Forms.Label IDForCustomList_lbl;
    private System.Windows.Forms.Button removeCustomList_btn;
    private System.Windows.Forms.Button addCustomList_btn;
    private System.Windows.Forms.TextBox idNumber_textBox;
    private System.Windows.Forms.GroupBox DataGroupBox;
    private System.Windows.Forms.TextBox id_textBox;
    private System.Windows.Forms.Label id_lbl;
    private System.Windows.Forms.GroupBox viewData_groupBox;
    private System.Windows.Forms.Button search_btn;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.DataGridView dataGridView1;
  }
}