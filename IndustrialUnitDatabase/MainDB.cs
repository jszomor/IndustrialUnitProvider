using IndustrialUnitDatabase.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace IndustrialUnitDatabase
{
  class MainDB
  {
    static void Main()
    {
      Console.WriteLine("Select Tables from Industrial Unit Manager.");
      Console.WriteLine("Currently available tables: Equipment, Valve or Instrument. Please select.");
      string tableName = Console.ReadLine();
      var SQLiteDataAccess = new SQLiteDataAccess();
      SQLiteDataAccess.GetConnectionOnDataTable(tableName);
    }
  }
}
