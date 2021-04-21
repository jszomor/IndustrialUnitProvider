using Dapper;
using IndustrialUnitDatabase.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IndustrialUnitDatabase
{
  public static class SQLiteDataAccess
  {
    static string databasePath = $"Data Source={Helper.DatabasePath("IndustrialUnitDB.db")}";

    public static void LoadPeople()
    {
      using var con = new SQLiteConnection(databasePath);
      con.Open();

      string stm = "SELECT * FROM EQUIPMENT";

      using var cmd = new SQLiteCommand(stm, con);
      using SQLiteDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        Console.WriteLine($"{rdr.GetDecimal(2)}");
      }


      //using (IDbConnection cnn = new SQLiteConnection(databasePath))
      //{
      //  var output = cnn.Query("select * from Equipment", new DynamicParameters());
      //  //return output.ToList();
      //}
    }

    public static void InsertEquipment(Equipment equipment)
    {
      using (IDbConnection cnn = new SQLiteConnection(databasePath))
      {
        cnn.Execute("insert into Equipment (Id, ItemType, Capacity, Pressure, PowerConsumption, Manufacturer, Model, UnitPrice) " +
          "values (@Id, @ItemType, @Capacity, @Pressure, @PowerConsumption, @Manufacturer, @Model, @UnitPrice)", equipment);
      }
    }
  }
}

