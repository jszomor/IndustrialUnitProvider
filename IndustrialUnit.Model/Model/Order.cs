using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndustrialUnit.Model.Model
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public string ItemName { get; set; }
    public decimal UnitPrice { get; set; }
  }
}
