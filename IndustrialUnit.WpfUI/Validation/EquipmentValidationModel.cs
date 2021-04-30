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
  public class EquipmentValidationModel : ObservableObject
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
        OnPropertyChanged(ref _itemType, value);
        ValidateItemTypeText();
      }
    }
    private void ValidateItemTypeText()
    {
      ClearErrors(nameof(ItemType));

      if (!string.IsNullOrWhiteSpace(ItemType) && ItemType?.Length < 3)
        AddError(nameof(ItemType), "Label must consist at least 3 char.");

      else if (string.IsNullOrWhiteSpace(ItemType))
        AddError(nameof(ItemType), "Label cannot be empty.");
    }

    public string Capacity
    {
      get { return _capacity; }
      set
      {
        OnPropertyChanged(ref _capacity, value);
        ValidateCapacityText();
      }
    }
    private void ValidateCapacityText()
    {
      ClearErrors(nameof(Capacity));

      if (Capacity.Any(char.IsLetter))
        AddError(nameof(Capacity), "Only number is allowed.");

      else if (!string.IsNullOrWhiteSpace(Capacity) && Capacity?.Length < 3)
        AddError(nameof(Capacity), "Label must consist at least 3 char.");

      else if (string.IsNullOrWhiteSpace(Capacity))
        AddError(nameof(Capacity), "Label cannot be empty.");
    }

    public string Pressure
    {
      get { return _pressure; }
      set
      {
        OnPropertyChanged(ref _pressure, value);
      }
    }

    public string PowerConsumption
    {
      get { return _powerConsumption; }
      set
      {
        OnPropertyChanged(ref _powerConsumption, value);
      }
    }

    public string Manufacturer
    {
      get { return _manufacturer; }
      set
      {
        OnPropertyChanged(ref _manufacturer, value);
      }
    }

    public string Model
    {
      get { return _model; }
      set
      {
        OnPropertyChanged(ref _model, value);
      }
    }

    public string UnitPrice
    {
      get { return _unitPrice; }
      set
      {
        OnPropertyChanged(ref _unitPrice, value);
      }
    }

  }
}
