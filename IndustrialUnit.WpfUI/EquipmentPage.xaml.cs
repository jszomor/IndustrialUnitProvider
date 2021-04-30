using IndustrialUnitDatabase;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using IndustrialUnit.WpfUI.Validation;

namespace IndustrialUnit.WpfUI
{
  /// <summary>
  /// Interaction logic for EquipmentPage.xaml
  /// </summary>
  public partial class EquipmentPage : Page
  {
    public EquipmentPage()
    {
      InitializeComponent();
      FillDataGrid();
    }

    private void FillDataGrid()
    {
      var sqlAccess = new SQLiteDataAccess();
      DataTable dt = sqlAccess.GetConnectionOnDataTable("Equipment");

      EquipmentTableGrid.ItemsSource = dt.DefaultView;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void EQInsert_Click(object sender, RoutedEventArgs e)
    {
      var eq = new Equipment();

      eq.ItemType = EqItemTypeLabel.Text;
      eq.Capacity = Helper.ConvertType<decimal>(EqCapacityLabel.Text, eq.Capacity.GetType());
      eq.Pressure = Helper.ConvertType<decimal>(EqPressureLabel.Text, eq.Pressure.GetType());
      eq.PowerConsumption = Helper.ConvertType<decimal>(EqPowerConsumptionLabel.Text, eq.PowerConsumption.GetType());
      eq.Manufacturer = EqManufacturerLabel.Text;
      eq.Model = EqModelLabel.Text;
      eq.UnitPrice = Helper.ConvertType<decimal>(EqUnitPriceLabel.Text, eq.UnitPrice.GetType());      

      var sqlAccess = new SQLiteDataAccess();
      sqlAccess.Insert(eq, "Equipment");
    }
  }
}
