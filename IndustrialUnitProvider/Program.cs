using IndustrialUnit.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace IndustrialUnitProvider
{
  class Program
  {
    static void Main()
    {
      var mapper = new UnitMapper();

      string fileName = "IndustrialUnits.xlsx";

      try
      {
        mapper.LoadUnitsFromSheet(PathHelper.ProjectPath(fileName));
      }
      catch (Exception e)
      {
        Debug.WriteLine(e);
        throw;
      }
    }
  }
}

