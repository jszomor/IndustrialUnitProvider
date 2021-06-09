using System.ComponentModel.DataAnnotations;

namespace IndustrialUnit.Model.Model
{
  public class Valve
  {
    [Key]
    public int? Id { get; set; }
    public string ItemType { get; set; }
    public string Operation { get; set; }
    public int? Size { get; set; }
    public string ConnectionType { get; set; }
    public string Supplier { get; set; }
    public string Manufacturer { get; set; }
    public decimal? UnitPrice { get; set; }
  }
}
