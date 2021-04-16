using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IndustrialUnitProvider
{
  class Program
  {
    static void Main(string[] args)
    {
      var items = new Items();

      var mapper = new UnitMapper();

      string fileName = "IndustrialUnits.xlsx";

      try
      {
        mapper.LoadUnitsFromSheet(items, fileName);
      }
      catch (Exception e)
      {
        Debug.WriteLine(e);
        throw;
      }

      var itemsToJsonSerializer = new ItemsToJsonSerializer();
      itemsToJsonSerializer.BuildJson(items);
    }
  }
}

