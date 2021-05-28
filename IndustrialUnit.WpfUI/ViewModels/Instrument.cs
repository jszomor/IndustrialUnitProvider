namespace IndustrialUnit.WpfUI.ViewModels
{
  public class Instrument : BaseViewModel
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

    private string _operationPrinciple;
    public string OperationPrinciple
    {
      get
      {
        return _operationPrinciple;
      }
      set
      {
        _operationPrinciple = value;
        OnPropertyChanged();
      }
    }

    private string _installationType;
    public string InstallationType
    {
      get
      {
        return _installationType;
      }
      set
      {
        _installationType = value;
        OnPropertyChanged();
      }
    }

    private string _mediumToMeasure;
    public string MediumToMeasure
    {
      get
      {
        return _mediumToMeasure;
      }
      set
      {
        _mediumToMeasure = value;
        OnPropertyChanged();
      }
    }

    public string _supplier;
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
