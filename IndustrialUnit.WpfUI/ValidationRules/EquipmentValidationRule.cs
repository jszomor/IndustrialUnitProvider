using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.ValidationRules
{
  public class EquipmentValidationRule : ObservableObject
  {
    private string _itemType;
    private string _capacity;    

    public string ItemType
    {
      get { return _itemType; }
      set
      {
        OnPropertyChanged(ref _itemType, value);
      }
    }

    public string Capacity
    {
      get { return _capacity; }
      set
      {
        OnPropertyChanged(ref _capacity, value);
      }
    }
  }
}
