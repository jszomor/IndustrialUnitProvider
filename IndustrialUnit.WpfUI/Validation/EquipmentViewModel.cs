using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.Validation
{
  public class EquipmentViewModel : ObservableObject
  {
    private string _itemType;
    private string _capacity;
    private string _pressure;
    private string _powerConsumption;
    private string _manufacturer;
    private string _model;
    private string _unitPrice;

    public string ItemType
    {
      get { return _itemType; }
      set
      {
        _itemType = value;
        OnPropertyChanged("ItemType");
      }
    }

    public string Capacity
    {
      get { return _capacity; }
      set
      {
        _capacity = value;
        OnPropertyChanged("Capacity");
      }
    }

    public string Pressure
    {
      get { return _pressure; }
      set
      {
        _pressure = value;
        OnPropertyChanged("Pressure");
      }
    }

    public string PowerConsumption
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

    public string UnitPrice
    {
      get { return _unitPrice; }
      set
      {
        _unitPrice = value;
        OnPropertyChanged("UnitPrice");
      }
    }
  }
}
