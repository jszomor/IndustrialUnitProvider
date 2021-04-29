using System.ComponentModel.DataAnnotations;

namespace IndustrialUnit.Model.Model
{
  public class Equipment
  {
    [Key]
    public int Id { get; set; }

    public string ItemType { get; set; }

    public decimal Capacity { get; set; }

    public decimal Pressure { get; set; }

    public decimal PowerConsumption { get; set; }

    public string Manufacturer { get; set; }

    public string Model { get; set; }

    public decimal UnitPrice { get; set; }
  }
}
