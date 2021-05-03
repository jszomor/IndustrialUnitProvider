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
    public IEnumerable<EquipmentViewModel> _viewModel { get; set; }

    public InsertEquipmentCommand(IEnumerable<EquipmentViewModel> ViewModel)
    {
      _viewModel = ViewModel;
    }

    private bool IsEmpty()
    {
      foreach (var item in _viewModel)
      {
        if (string.IsNullOrEmpty(item.ToString()))
        {
          return true;
        }
      }
      return true;
    }

    public override void Execute(object parameter)
    {
      if (!IsEmpty())
      {
        var sqlAccess = new SQLiteDataAccess();
        sqlAccess.Insert(_viewModel, "Equipment");
      }
      else
      {

      }
    }
  }
}
