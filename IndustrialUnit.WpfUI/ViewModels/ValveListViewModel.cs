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
  public class ValveListViewModel : BaseViewModel
  {
    private ObservableCollection<ValveViewModel> _valves;
    public ObservableCollection<ValveViewModel> Valves
    {
      get
      {
        return _valves;
      }
      set
      {
        _valves = value;
        OnPropertyChanged();
        SelectedValve = new ValveViewModel();
      }
    }

    private ValveViewModel _selectedValve;
    public ValveViewModel SelectedValve
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

    private void RunAddCommand() => MessageToScreen = ValveRepository.SubmitAdd(SelectedValve);
    private void RunDeleteCommand() => MessageToScreen = ValveRepository.SubmitDelete(SelectedValve);
    private void RunUpdateCommand() => MessageToScreen = ValveRepository.SubmitUpdate(SelectedValve);
    private void RunFilterCommand() => (Valves, MessageToScreen) = ValveRepository.GetFilteredValves(Valves, SelectedValve.ItemType);
    private void RunRefreshCommand()
    {
      (Valves, MessageToScreen) = ValveRepository.GetAllValves();
      MessageToScreen = "Refresh done.";
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public ValveListViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(RunRefreshCommand);
      (Valves, MessageToScreen) = ValveRepository.GetAllValves();
    }
  }
}
