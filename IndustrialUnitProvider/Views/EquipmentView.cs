using Newtonsoft.Json;
using System.Collections.Generic;

namespace IndustrialUnitProvider
{
  public class Equipments
  {
    public List<EquipmentView> EquipmentList { get; set; } = new List<EquipmentView>();
  }
  public class EquipmentView
  {
    public EquipmentView() { }

    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("ItemType")]
    public string ItemType { get; set; }

    [JsonProperty("Capacity")]
    public decimal Capacity { get; set; }

    [JsonProperty("Pressure")]
    public decimal Pressure { get; set; }

    [JsonProperty("PowerConsumption")]
    public decimal PowerConsumption { get; set; }

    [JsonProperty("Manufacturer")]
    public string Manufacturer { get; set; }

    [JsonProperty("Model")]
    public string Model { get; set; }

    [JsonProperty("UnitPrice")]
    public decimal UnitPrice { get; set; }
  }
}
