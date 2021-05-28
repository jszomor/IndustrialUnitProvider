using IndustrialUnit.WpfUI.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {
    private ObservableCollection<Equipment> _equipments;
    public ObservableCollection<Equipment> Equipments
    {
      get
      {
        return _equipments;
      }
      set
      {
        _equipments = value;
        OnPropertyChanged();
        SelectedEquipment = new Equipment();
      }
    }

    private Equipment _selectedEquipment;
    public Equipment SelectedEquipment
    {
      get
      {
        return _selectedEquipment;
      }
      set
      {
        _selectedEquipment = value;
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

    private void RunAddCommand() => MessageToScreen = EquipmentModel.SubmitAdd(SelectedEquipment);
    private void RunDeleteCommand() => MessageToScreen = EquipmentModel.SubmitDelete(SelectedEquipment);
    private void RunUpdateCommand() => MessageToScreen = EquipmentModel.SubmitUpdate(SelectedEquipment);
    private void RunFilterCommand() => (Equipments, MessageToScreen) = EquipmentModel.GetFilteredEquipments(Equipments, SelectedEquipment.ItemType);
    private void RunRefreshCommand()
    {
      (Equipments, MessageToScreen) = EquipmentModel.GetAllEquipments();
      MessageToScreen = "Refresh done.";
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public EquipmentViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(RunRefreshCommand);
      (Equipments, MessageToScreen) = EquipmentModel.GetAllEquipments();
    }
  }
}
