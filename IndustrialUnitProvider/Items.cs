using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitProvider
{
  public class Items
  {
    public List<Equipment> Equipments { get; } = new List<Equipment>();
    public List<Valve> Valves { get; } = new List<Valve>();
    public List<Instrument> Instruments { get; } = new List<Instrument>();
  }
}
