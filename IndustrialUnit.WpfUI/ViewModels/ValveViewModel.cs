using IndustrialUnit.WpfUI.Models;
using IndustrialUnitDatabase;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;
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
        OnPropertyChanged();
        SelectedValve = new Valve();
      }
    }

    private Valve _selectedValve;
    public Valve SelectedValve
    {
      get
      {
        return _selectedValve;
      }
      set
      {
        _selectedValve = value;
        OnPropertyChanged();
      }
    }

    private string _MessageToScreen;
    public string MessageToScreen
    {
      get
      {
        return _MessageToScreen;
      }
      set
      {
        _MessageToScreen = value;
        OnPropertyChanged();
      }
    }

    private void RunAddCommand() => MessageToScreen = ValveModel.SubmitAdd(SelectedValve);
    private void RunDeleteCommand() => MessageToScreen = ValveModel.SubmitDelete(SelectedValve);
    private void RunUpdateCommand() => MessageToScreen = ValveModel.SubmitUpdate(SelectedValve);
    private void RunFilterCommand() => (Valves, MessageToScreen) = ValveModel.GetFilteredValves(Valves, SelectedValve.ItemType);
    private void RunRefreshCommand()
    {
      (Valves, MessageToScreen) = ValveModel.GetAllValves();
      MessageToScreen = "Refresh done.";
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public ValveViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(RunRefreshCommand);
      (Valves, MessageToScreen) = ValveModel.GetAllValves();
    }
  }
}
