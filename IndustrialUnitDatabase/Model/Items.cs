using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndustrialUnitDatabase.Model
{
  public class Items
  {
    [Key]
    public int Id { get; set; }
    public List<Equipment> Equipments { get; } = new List<Equipment>();
    public List<Valve> Valves { get; } = new List<Valve>();
    public List<Instrument> Instruments { get; } = new List<Instrument>();
  }
}
