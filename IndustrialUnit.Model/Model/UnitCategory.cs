using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnit.Model.Model
{
  public class UnitCategory
  {
    Equipment Equipments { get; set; } = new Equipment();
    Valve Valves { get; set; } = new Valve();
    Instrument Instruments { get; set; } = new Instrument();
  }
}
