using AutoMapper;
using IndustrialUnitDatabase.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitDatabase
{
  public class IndustrialMappingProfile: Profile
  {
    public IndustrialMappingProfile()
    {
      CreateMap<Equipment, EquipmentView>()
        .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
        .ReverseMap();

      CreateMap<Valve, ValveView>()
        .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
        .ReverseMap();

      CreateMap<Instrument, InstrumentView>()
        .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
        .ReverseMap();
    }
  }
}
