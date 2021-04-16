using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitProvider
{
  public class Equipment
  {
    public Equipment() { }

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
