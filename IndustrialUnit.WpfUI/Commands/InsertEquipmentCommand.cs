using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnit.WpfUI.Commands
{
  public class InsertEquipmentCommand : CommandBase
  {
    public EquipmentViewModel _viewModel { get; set; }

    public InsertEquipmentCommand(EquipmentViewModel ViewModel)
    {
      _viewModel = ViewModel;
    }

    public override void Execute(object parameter)
    {
      var sqlAccess = new SQLiteDataAccess();
      sqlAccess.Insert(_viewModel, "Equipment");
    }
  }
}
