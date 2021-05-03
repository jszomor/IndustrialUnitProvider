using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class ValveViewModel : ViewModelBase
  {
    public string ItemType { get; set; }
    public string Operation { get; set; }
    public decimal Size { get; set; }
    public string ConnectionType { get; set; }
    public string Supplier { get; set; }
    public string Manufacturer { get; set; }
    public decimal UnitPrice { get; set; }
  }
}
