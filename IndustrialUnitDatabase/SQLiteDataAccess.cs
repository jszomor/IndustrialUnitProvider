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
  public class SQLiteDataAccess
  {
    private string loadConnectionString = $"Data Source={Paths.DatabasePath("IndustrialUnitDB.db")}";

    public IDbConnection GetConnection(string tableName)
    {
      var con = new SQLiteConnection(loadConnectionString);
      con.Open();

      //WriteTableDataToConsole(tableName, con);

      return con;
    }

    private void WriteTableDataToConsole(string tableName, SQLiteConnection con)
    {

      string stm = $"SELECT * FROM {tableName}";

      using var cmd = new SQLiteCommand(stm, con);
      using SQLiteDataReader rdr = cmd.ExecuteReader();


      while (rdr.Read())
      {
        var sb = new StringBuilder();
        for (int i = 0; i < rdr.FieldCount; i++)
        {
          sb.Append(rdr[i]);
          sb.Append(",");
        }
        Console.WriteLine(sb);
      }
    }


    public void Insert<T>(T unit, string sheetName)
    {
      using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
      {
        switch(sheetName)
        {
          case "Equipment":
            cnn.Execute("insert into Equipment (ItemType, Capacity, Pressure, PowerConsumption, Manufacturer, Model, UnitPrice) " +
            "values (@ItemType, @Capacity, @Pressure, @PowerConsumption, @Manufacturer, @Model, @UnitPrice)", unit);
            break;

          case "Valve":
            cnn.Execute("insert into Valve (ItemType, Operation, Size, ConnectionType, Supplier, Manufacturer, UnitPrice) " +
            "values (@ItemType, @Operation, @Size, @ConnectionType, @Supplier, @Manufacturer, @UnitPrice)", unit);
            break;

          case "Instrument":
            cnn.Execute("insert into Instrument (ItemType, OperationPrinciple, InstallationType, MediumToMeasure, Supplier, Manufacturer, UnitPrice) " +
            "values (@ItemType, @OperationPrinciple, @InstallationType, @MediumToMeasure, @Supplier, @Manufacturer, @UnitPrice)", unit);
            break;
        }
      }
    }
  }
}

