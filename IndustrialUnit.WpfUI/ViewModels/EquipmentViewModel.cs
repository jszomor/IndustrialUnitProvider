using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {

    private ObservableCollection<EquipmentModel> _equipments;
    public ObservableCollection<EquipmentModel> Equipments
    {
      get
      {
        return _equipments;
      }
      set
      {
        _equipments = value;
        OnPropertyChanged();
      }
    }

    private EquipmentModel _selectedEquipment;
    public EquipmentModel SelectedEquipment {
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

    private DataView _eqDataGrid;
    public DataView EqDataGrid { 
      get 
      {
        return _eqDataGrid;
      } 
      set 
      {
        _eqDataGrid = value; 
        OnPropertyChanged();
      }}


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


    private int _id;
    public int Id 
    {
      get
      {
        return _id;
      }
      set
      {
        _id = value;
        OnPropertyChanged();
      } 
    }


    private string _itemType;
    public string ItemType 
    {
      get
      {
        return _itemType;
      }
      set 
      {
        _itemType = value;
        OnPropertyChanged();      
      }
    }


    private decimal _capacity;
    public decimal Capacity 
    {
      get
      {
        return _capacity;
      }
      set 
      {
        _capacity = value;
        OnPropertyChanged();
      } 
    }


    private decimal _pressure;
    public decimal Pressure
    {
      get
      {
        return _pressure;
      }
      set
      {
        _pressure = value;
        OnPropertyChanged();
      }
    }


    private decimal _powerConsumption;
    public decimal PowerConsumption 
    {
      get
      {
        return _powerConsumption;
      }
      set
      {
        _powerConsumption = value;
        OnPropertyChanged();
      } 
    }


    private string _manufacturer;
    public string Manufacturer 
    {
      get
      {
        return _manufacturer;
      }
      set
      {
        _manufacturer = value;
        OnPropertyChanged();
      } 
    }


    private string _model;
    public string Model 
    {
      get
      {
        return _model;
      }
      set
      {
        _model = value;
        OnPropertyChanged();
      }
    }


    private decimal _unitPrice;
    public decimal UnitPrice 
    {
      get
      {
        return _unitPrice;
      }
      set
      {
        _unitPrice = value;
        OnPropertyChanged();
      } 
    }

    public bool IsEquipmentEmpty(EquipmentViewModel eq)
    {
      if (string.IsNullOrEmpty(ItemType) ||
          string.IsNullOrEmpty(Capacity.ToString()) ||
          string.IsNullOrEmpty(Pressure.ToString()) ||
          string.IsNullOrEmpty(PowerConsumption.ToString()) ||
          string.IsNullOrEmpty(Manufacturer) ||
          string.IsNullOrEmpty(Model) ||
          string.IsNullOrEmpty(UnitPrice.ToString()))
      {
        return false;
      }
      return true;
    }

    private void RunAddCommand() => MessageToView = BaseModel.SubmitAdd(this, "Equipment", IsEquipmentEmpty);
    private void RunDeleteCommand() => MessageToView = BaseModel.SubmitDelete("Equipment", Id);
    private void RunUpdateCommand() => MessageToView = BaseModel.SubmitUpdate(this, "Equipment", IsEquipmentEmpty, Id);
    private void RunSearchCommand() => (EqDataGrid, MessageToView) = BaseModel.FillDataGridFiltered("Equipment", ItemType);

    public ICommand AddEquipmentCommand { get; }
    public ICommand DeleteEquipmentCommand { get; }
    public ICommand UpdateEquipmentCommand { get; }
    public ICommand SearchEquipmentCommand { get; }

    public EquipmentViewModel()
    {
      AddEquipmentCommand = new RelayCommand(RunAddCommand);
      DeleteEquipmentCommand = new RelayCommand(RunDeleteCommand);
      UpdateEquipmentCommand = new RelayCommand(RunUpdateCommand);
      SearchEquipmentCommand = new RelayCommand(RunSearchCommand);
      EqDataGrid = BaseModel.FillDataGrid("Equipment");
    }
  }
}
