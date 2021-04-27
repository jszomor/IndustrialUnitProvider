using IndustrialUnitDatabase;
using IndustrialUnitDatabase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
  }
}
