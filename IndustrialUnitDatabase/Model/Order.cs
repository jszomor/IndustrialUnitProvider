using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitDatabase.Model
{
  public class Order
  {
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public string ItemName { get; set; }
    public decimal UnitPrice { get; set; }
    public ICollection<Items> ItemCategory { get; set; }
  }
}
