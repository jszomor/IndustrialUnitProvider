namespace IndustrialUnit.WpfUI.ViewModels
{
  public class Equipment : BaseViewModel
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


    private object _capacity;
    public object Capacity
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


    private object _pressure;
    public object Pressure
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


    private object _powerConsumption;
    public object PowerConsumption
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


    private object _unitPrice;
    public object UnitPrice
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



