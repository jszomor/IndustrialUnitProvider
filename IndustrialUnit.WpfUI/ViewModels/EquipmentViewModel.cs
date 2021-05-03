using IndustrialUnit.WpfUI.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : ViewModelBase, IEnumerable
  {
    private string _itemType;
    private decimal _capacity;
    private decimal _pressure;
    private decimal _powerConsumption;
    private string _manufacturer;
    private string _model;
    private decimal _unitPrice;

    public string ItemType
    {
      get { return _itemType; }
      set
      {
        _itemType = value;
        OnPropertyChanged("ItemType");
      }
    }

    public decimal Capacity
    {
      get { return _capacity; }
      set
      {
        _capacity = value;
        OnPropertyChanged("Capacity");
      }
    }

    public decimal Pressure
    {
      get { return _pressure; }
      set
      {
        _pressure = value;
        OnPropertyChanged("Pressure");
      }
    }

    public decimal PowerConsumption
    {
      get { return _powerConsumption; }
      set
      {
        _powerConsumption = value;
        OnPropertyChanged("PowerConsumption");
      }
    }

    public string Manufacturer
    {
      get { return _manufacturer; }
      set
      {
        _manufacturer = value;
        OnPropertyChanged("Manufacturer");
      }
    }

    public string Model
    {
      get { return _model; }
      set
      {
        _model = value;
        OnPropertyChanged("Model");
      }
    }

    public decimal UnitPrice
    {
      get { return _unitPrice; }
      set
      {
        _unitPrice = value;
        OnPropertyChanged("UnitPrice");
      }
    }

    public ICommand InsertEquipmentCommand { get; }

    public EquipmentViewModel()
    {
      InsertEquipmentCommand = new InsertEquipmentCommand(this);
    }

    public IEnumerator GetEnumerator()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<EquipmentViewModel> equipmentViewModels { get; set; }
  }
}
