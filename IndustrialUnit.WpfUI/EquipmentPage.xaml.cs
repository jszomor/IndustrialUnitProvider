using IndustrialUnitDatabase;
using IndustrialUnitDatabase.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var sqlAccess = new SQLiteDataAccess();
      IDbConnection conn = sqlAccess.GetConnection("Equipment");


    }
  }
}
