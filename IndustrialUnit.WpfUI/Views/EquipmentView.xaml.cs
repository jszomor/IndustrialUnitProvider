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
using IndustrialUnitProvider;
using System;

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
      EquipmentViewModel e = new EquipmentViewModel();

      EquipmentTableGrid.ItemsSource = e.GetEquipments();
      //DataContext = new EquipmentViewModel();
    }

    private void EQRefresh_Click(object sender, RoutedEventArgs e)
    {
      DataContext = new EquipmentViewModel();
    }

    private void EquipmentTableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Dictionary<string, int> textBoxNames = new()
        {
          { "Id", 0 },
          { "ItemType", 1 },
          { "Capacity", 2 },
          { "Pressure", 3 },
          { "PowerConsumption", 4 },
          { "Manufacturer", 5 },
          { "Model", 6 },
          { "UnitPrice", 7 }
        };

      //BaseModel.DataGrid_SelectionChanged(DataContext, sender, textBoxNames);
    }
  }
}
