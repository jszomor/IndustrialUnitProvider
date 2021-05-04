using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace IndustrialUnit.WpfUI.Commands
{
  public class InsertEquipmentCommand : CommandBase
  {
    private EquipmentViewModel _viewModel { get; set; }

    public InsertEquipmentCommand(EquipmentViewModel ViewModel)
    {
      _viewModel = ViewModel;
    }

    private bool IsEmpty()
    {
        if (string.IsNullOrEmpty(_viewModel.ItemType) ||
            string.IsNullOrEmpty(_viewModel.Capacity.ToString()) ||
            string.IsNullOrEmpty(_viewModel.Pressure.ToString()) ||
            string.IsNullOrEmpty(_viewModel.PowerConsumption.ToString()) ||
            string.IsNullOrEmpty(_viewModel.Manufacturer) ||
            string.IsNullOrEmpty(_viewModel.Model) ||
            string.IsNullOrEmpty(_viewModel.UnitPrice.ToString()))
        {
          return false;
        }
      
      return true;
    }

    public override void Execute(object parameter)
    {
      if (IsEmpty())
      {
        var sqlAccess = new SQLiteDataAccess();
        sqlAccess.Insert(_viewModel, "Equipment");
        MessageBox.Show($"You have successfully added.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      else
      {
        MessageBox.Show($"No empty cell is allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
