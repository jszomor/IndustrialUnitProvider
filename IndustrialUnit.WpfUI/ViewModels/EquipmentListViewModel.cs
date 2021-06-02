using IndustrialUnit.WpfUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using IndustrialUnit.Model.Model;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentListViewModel : BaseViewModel
  {
    private ObservableCollection<EquipmentViewModel> _equipments;
    public ObservableCollection<EquipmentViewModel> Equipments
    {
      get
      {
        return _equipments;
      }
      set
      {
        _equipments = value;
        OnPropertyChanged();
        SelectedEquipmentViewModel = new EquipmentViewModel();
      }
    }

    private EquipmentViewModel _selectedEquipmentViewModel;
    public EquipmentViewModel SelectedEquipmentViewModel
    {
      get
      {
        return _selectedEquipmentViewModel;
      }
      set
      {
        _selectedEquipmentViewModel = value;
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

    private void RunAddCommand() => MessageToScreen = EquipmentRepository.SubmitAdd(SelectedEquipmentViewModel.ToEquipment());
    private void RunDeleteCommand() => MessageToScreen = EquipmentRepository.SubmitDelete(SelectedEquipmentViewModel.ToEquipment());
    private void RunUpdateCommand() => MessageToScreen = EquipmentRepository.SubmitUpdate(SelectedEquipmentViewModel.ToEquipment());
    private void RunFilterCommand()
    {
      var (equipments, messageToScreen) = EquipmentRepository.GetFilteredEquipments(SelectedEquipmentViewModel.ItemType);
      UpdateEquipmentList(equipments);
      MessageToScreen = messageToScreen;
    }

    private void RunRefreshCommand()
    {
      var (equipments, messageToScreen) = EquipmentRepository.GetAllEquipments();
      UpdateEquipmentList(equipments);
      if (equipments == null)
        MessageToScreen = messageToScreen;
      else
        MessageToScreen = "Refresh done.";
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public EquipmentListViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(RunRefreshCommand);
      var (equipments, messageToScreen) = EquipmentRepository.GetAllEquipments();
      UpdateEquipmentList(equipments);
      MessageToScreen = messageToScreen;
    }

    private void UpdateEquipmentList(IEnumerable<Equipment> equipments)
    {
      Equipments = new ObservableCollection<EquipmentViewModel>(equipments.Select(x => new EquipmentViewModel(x)));
    }
  }
}
