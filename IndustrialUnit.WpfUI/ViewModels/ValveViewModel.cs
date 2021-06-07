using IndustrialUnit.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class ValveViewModel : BaseViewModel
  {

    public ValveViewModel()
    {
    }

    public ValveViewModel(Valve valve)
    {
      Id = valve.Id;
      ItemType = valve.ItemType;
      Operation = valve.Operation;
      Size = valve.Size;
      ConnectionType = valve.ConnectionType;
      Supplier = valve.Supplier;
      Manufacturer = valve.Manufacturer;
      UnitPrice = valve.UnitPrice;
    }

    public Valve ToValve()
    {
      var valve = new Valve()
      {
        Id = Id,
        ItemType = ItemType,
        Operation = Operation,
        Size = Size,
        ConnectionType = ConnectionType,
        Supplier = Supplier,
        Manufacturer = Manufacturer,
        UnitPrice = UnitPrice
      };

      return valve;
    }

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
