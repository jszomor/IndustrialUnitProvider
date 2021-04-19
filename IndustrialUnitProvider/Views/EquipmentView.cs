using Newtonsoft.Json;

namespace IndustrialUnitProvider
{
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
