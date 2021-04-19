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
      var mapper = new UnitMapper();

      string fileName = "IndustrialUnits.xlsx";

      try
      {
        mapper.LoadUnitsFromSheet(fileName);
      }
      catch (Exception e)
      {
        Debug.WriteLine(e);
        throw;
      }
    }
  }
}

