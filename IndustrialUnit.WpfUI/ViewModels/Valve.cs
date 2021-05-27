using System.ComponentModel.DataAnnotations;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class Valve : BaseViewModel
  {
    private int? _id;
    public int? Id
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

    private string _operation;
    public string Operation
    {
      get
      {
        return _operation;
      }
      set
      {
        _operation = value;
        OnPropertyChanged();
      }
    }

    private decimal? _size;
    public decimal? Size
    {
      get
      {
        return _size;
      }
      set
      {
        _size = value;
        OnPropertyChanged();
      }
    }

    private string _connectionType;
    public string ConnectionType
    {
      get
      {
        return _connectionType;
      }
      set
      {
        _connectionType = value;
        OnPropertyChanged();
      }
    }

    private string _supplier;
    public string Supplier
    {
      get
      {
        return _supplier;
      }
      set
      {
        _supplier = value;
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

    private decimal? _unitPrice;
    public decimal? UnitPrice
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
