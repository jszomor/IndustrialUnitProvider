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

    private string _messageToView;
    public string MessageToView
    {
      get
      {
        return _messageToView;
      }
      set
      {
        _messageToView = value;
        OnPropertyChanged();
      }
    }

    private void RunAddCommand() => MessageToView = ValveModel.SubmitAdd(SelectedValve);
    private void RunDeleteCommand() => MessageToView = ValveModel.SubmitDelete(SelectedValve);
    private void RunUpdateCommand() => MessageToView = ValveModel.SubmitUpdate(SelectedValve);
    private void RunFilterCommand() => (Valves, MessageToView) = ValveModel.GetFilteredValves(Valves, SelectedValve.ItemType);
    private void RunRefreshCommand()
    {
      Valves = ValveModel.GetAllValves();
      MessageToView = "Refresh done.";
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
      Valves = ValveModel.GetAllValves();
    }
  }
}
