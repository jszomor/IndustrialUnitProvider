using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewProperties : BaseViewModel
  {

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
  }
}



