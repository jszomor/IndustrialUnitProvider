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

    private void RunAddCommand() => MessageToView = EquipmentModel.SubmitAdd(SelectedEquipment, EquipmentModel.IsTextBoxEmpty);
    private void RunDeleteCommand() => MessageToView = BaseModel.SubmitDelete("Equipment", SelectedEquipment.Id);
    private void RunUpdateCommand() => MessageToView = BaseModel.SubmitUpdate(SelectedEquipment, EquipmentModel.IsTextBoxEmpty, SelectedEquipment.Id);
    private void RunFilterCommand() => (Equipments, MessageToView) = EquipmentModel.GetFilteredEquipments(Equipments, SelectedEquipment.ItemType);
    private void RunRefreshCommand()
    {
      Equipments = EquipmentModel.GetAllEquipments();
      MessageToView = "Refresh done.";
    }

    public ICommand AddEquipmentCommand { get; }
    public ICommand DeleteEquipmentCommand { get; }
    public ICommand UpdateEquipmentCommand { get; }
    public ICommand FilterEquipmentCommand { get; }
    public ICommand RefreshEquipmentCommand { get; }

    public EquipmentViewModel()
    {
      AddEquipmentCommand = new RelayCommand(RunAddCommand);
      DeleteEquipmentCommand = new RelayCommand(RunDeleteCommand);
      UpdateEquipmentCommand = new RelayCommand(RunUpdateCommand);
      FilterEquipmentCommand = new RelayCommand(RunFilterCommand);
      RefreshEquipmentCommand = new RelayCommand(RunRefreshCommand);
      Equipments = EquipmentModel.GetAllEquipments();
    }
  }
}
