using IndustrialUnit.WpfUI.Models;
using IndustrialUnitDatabase;
using System;
using System.Collections.ObjectModel;
using System.IO;
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

    private void RunAddCommand() => MessageToView = EquipmentModel.SubmitAdd(SelectedEquipment);
    private void RunDeleteCommand() => MessageToView = EquipmentModel.SubmitDelete(SelectedEquipment);
    private void RunUpdateCommand() => MessageToView = EquipmentModel.SubmitUpdate(SelectedEquipment);
    private void RunFilterCommand() => (Equipments, MessageToView) = EquipmentModel.GetFilteredEquipments(Equipments, SelectedEquipment.ItemType);
    private void RunRefreshCommand()
    {
      Equipments = EquipmentModel.GetAllEquipments();
      MessageToView = "Refresh done.";
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
      Equipments = EquipmentModel.GetAllEquipments();
    }
  }
}
