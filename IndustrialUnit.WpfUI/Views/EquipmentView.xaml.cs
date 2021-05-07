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
using IndustrialUnit.WpfUI.Commands;

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
      EquipmentTableGrid.ItemsSource = EquipmentCommands.FillDataGrid("Equipment");
    }

    private void EQInsert_Click(object sender, RoutedEventArgs e)
    {
      EquipmentCommands.SubmitInsert(DataContext, "Equipment");
      FillDataGrid();
    }
  }
}
