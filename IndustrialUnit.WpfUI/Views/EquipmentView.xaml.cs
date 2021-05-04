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

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for EquipmentView.xaml
  /// </summary>
  public partial class EquipmentView : Page
  {
    public EquipmentView()
    {
      InitializeComponent();
      FillDataGrid();
      DataContext = new EquipmentViewModel();
    }

    public void FillDataGrid()
    {
      try
      {
        var sqlAccess = new SQLiteDataAccess();
        DataTable dt = sqlAccess.GetConnectionOnDataTable("Equipment");

        EquipmentTableGrid.ItemsSource = dt.DefaultView;
      }
      catch (FileNotFoundException message)
      {
        throw new FileNotFoundException($"{message}");
      }    
    }
  }
}
