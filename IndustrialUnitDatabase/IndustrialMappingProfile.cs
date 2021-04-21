using AutoMapper;
using IndustrialUnitDatabase.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IndustrialUnitDatabase
{
  public class IndustrialMappingProfile //: Profile
  {
    //public IndustrialMappingProfile()
    //{
    //  CreateMap<Equipment, EquipmentView>()
    //    .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
    //    .ReverseMap();

    //  CreateMap<Valve, ValveView>()
    //    .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
    //    .ReverseMap();

    //  CreateMap<Instrument, InstrumentView>()
    //    .ForMember(e => e.Id, ex => ex.MapFrom(e => e.Id))
    //    .ReverseMap();
    //}
    public class DbColumnAttribute : Attribute
    {
      /// <summary>  
      /// Set true if implicit conversion is required.  
      /// </summary>  
      public bool Convert { get; set; }
      /// <summary>  
      /// Set true if the property is primary key in the table  
      /// </summary>  
      public bool IsPrimary { get; set; }
      /// <summary>  
      /// denotes if the field is an identity type or not.  
      /// </summary>  
      public bool IsIdentity { get; set; }
    }

    public IList<T> Map<T>(SQLiteDataReader reader)
            where T : class, new()
    {
      IList<T> collection = new List<T>();
      while (reader.Read())
      {
        T obj = new T();
        foreach (PropertyInfo i in obj.GetType().GetProperties()
            .Where(p => p.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DbColumnAttribute)) != null).ToList())
        {
          try
          {
            var ca = i.GetCustomAttribute(typeof(DbColumnAttribute));

            if (ca != null)
            {
              if (((DbColumnAttribute)ca).Convert == true)
              {
                if (reader[i.Name] != DBNull.Value)
                  i.SetValue(obj, Convert.ChangeType(reader[i.Name], i.PropertyType));
              }
              else
              {
                if (reader[i.Name] != DBNull.Value)
                  i.SetValue(obj, reader[i.Name]);
              }
            }
          }
          catch (Exception ex)
          {
#if DEBUG
            Console.WriteLine(ex.Message);
            Console.ReadLine();
#endif

#if !DEBUG
                        throw ex;  
#endif
          }
        }

        collection.Add(obj);
      }

      return collection;
    }



  }
}
