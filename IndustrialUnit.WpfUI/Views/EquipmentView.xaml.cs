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
      DataContext = new EquipmentViewModel();
    }

    private void EQRefresh_Click(object sender, RoutedEventArgs e)
    {
      DataContext = new EquipmentViewModel();
    }

    private void EquipmentTableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      BaseModel baseModel = new();

        List<string> textBoxNames = new()
        {
          "Id",
          "ItemType",
          "Capacity",
          "Pressure",
          "PowerConsumption",
          "Manufacturer",
          "Model",
          "UnitPrice"
        };

      baseModel.DataGrid_SelectionChanged(DataContext, sender, textBoxNames);
    }
  }
}
