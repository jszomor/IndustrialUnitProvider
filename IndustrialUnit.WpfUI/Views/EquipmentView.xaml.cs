using IndustrialUnitDatabase;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using IndustrialUnit.WpfUI.Validation;
using IndustrialUnit.WpfUI.ViewModels;
using System.IO;
using IndustrialUnit.WpfUI.Models;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Media;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for EquipmentView.xaml
  /// </summary>
  public partial class EquipmentView : UserControl
  {
    public EquipmentView()
    {
      InitializeComponent();
      FillDataGrid();
      DataContext = new EquipmentViewModel();
    }

    public void FillDataGrid()
    {
      EquipmentTableGrid.ItemsSource = BaseModel.FillDataGrid("Equipment");
    }

    private void EQRefresh_Click(object sender, RoutedEventArgs e)
    {
      FillDataGrid();

      EqIdTextBox.Clear();
      EqItemTypeTextBox.Clear();
      EqCapacityTextBox.Clear();
      EqPressureTextBox.Clear();
      EqPowerConsumptionTextBox.Clear();
      EqManufacturerTextBox.Clear();
      EqModelTextBox.Clear();
      EqUnitPriceTextBox.Clear();

      DataContext = new EquipmentViewModel();
    }

    private void EquipmentTableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DataGrid dg = (DataGrid)sender;
      if (dg.SelectedItem is DataRowView rowSelected)
      {
        List<string> textBoxNames = new()
        {
          "Id", "ItemType", "Capacity", "Pressure", 
          "PowerConsumption", "Manufacturer", "Model", "UnitPrice"
        };

        EqIdTextBox.Text = rowSelected[textBoxNames[0]].ToString();
        EqItemTypeTextBox.Text = rowSelected[textBoxNames[1]].ToString();
        EqCapacityTextBox.Text = rowSelected[textBoxNames[2]].ToString();
        EqPressureTextBox.Text = rowSelected[textBoxNames[3]].ToString();
        EqPowerConsumptionTextBox.Text = rowSelected[textBoxNames[4]].ToString();
        EqManufacturerTextBox.Text = rowSelected[textBoxNames[5]].ToString();
        EqModelTextBox.Text = rowSelected[textBoxNames[6]].ToString();
        EqUnitPriceTextBox.Text = rowSelected[textBoxNames[7]].ToString();
      }
    }
  }
}
