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
using System.Windows.Input;

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
    }

    public void FillDataGrid()
    {
      EquipmentTableGrid.ItemsSource = BaseModel.FillDataGrid("Equipment");
    }

    private void EQRefresh_Click(object sender, RoutedEventArgs e)
    {
      FillDataGrid();
    }
  }
}
