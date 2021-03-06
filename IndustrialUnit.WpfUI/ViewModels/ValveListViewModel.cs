using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Models;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        SelectedValveViewModel = new ValveViewModel();
      }
    }

    private ValveViewModel _selectedValveViewModel;
    public ValveViewModel SelectedValveViewModel
    {
      get
      {
        return _selectedValveViewModel;
      }
      set
      {
        _selectedValveViewModel = value;
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

    private void RunAddCommand() => MessageToScreen = ValveRepository.SubmitAdd(SelectedValveViewModel.ToValve());
    private void RunDeleteCommand() => MessageToScreen = ValveRepository.SubmitDelete(SelectedValveViewModel.ToValve());
    private void RunUpdateCommand() => MessageToScreen = ValveRepository.SubmitUpdate(SelectedValveViewModel.ToValve());
    private void RunFilterCommand()
    {
      var (valves, messageToScreen) = ValveRepository.GetFilteredValves(SelectedValveViewModel.ItemType);

      if (valves == null)
        MessageToScreen = messageToScreen;
      else
      {
        UpdateValveList(valves);
        MessageToScreen = "Refresh done.";
      }
    }

    private void InitDatabase()
    {
      var (valves, messageToScreen) = ValveRepository.GetAllValves();

      if (valves == null)
        MessageToScreen = messageToScreen;
      else
      {
        UpdateValveList(valves);
        MessageToScreen = messageToScreen;
      }
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
      RefreshCommand = new RelayCommand(InitDatabase);
      InitDatabase();
    }

    private void UpdateValveList(IEnumerable<Valve> valves)
    {
      Valves = new ObservableCollection<ValveViewModel>(valves.Select(x => new ValveViewModel(x)));
    }
  }
}
