using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Models;
using IndustrialUnit.WpfUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class ValveViewModel : BaseViewModel
  {

    private ObservableCollection<Valve> _valves;
    public ObservableCollection<Valve> Valves
    {
      get
      {
        return _valves;
      }
      set
      {
        _valves = value;
        //OnPropertyChanged(nameof(Valves));
      }
    }

    //public string ItemType { get; set; }
    //public string Operation { get; set; }
    //public decimal Size { get; set; }
    //public string ConnectionType { get; set; }
    //public string Supplier { get; set; }
    //public string Manufacturer { get; set; }
    //public decimal UnitPrice { get; set; }

    public ICommand LoadValveCommand { get; set; }

    public ValveViewModel()
    {
      LoadValveCommand = new LoadValveCommand(this);
    }
  }
}
