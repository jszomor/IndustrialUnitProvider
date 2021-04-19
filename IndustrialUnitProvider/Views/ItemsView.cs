using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitProvider
{
  public class ItemsView
  {
    public List<EquipmentView> Equipments { get; } = new List<EquipmentView>();
    public List<ValveView> Valves { get; } = new List<ValveView>();
    public List<InstrumentView> Instruments { get; } = new List<InstrumentView>();
  }
}
