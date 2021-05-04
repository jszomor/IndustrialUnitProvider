using Dapper;
using IndustrialUnit.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace IndustrialUnitDatabase
{
  public class SQLiteDataAccess
  {
    private string loadConnectionString = $"Data Source={Helper.DatabasePath("IndustrialUnitDB.db")}";

    public DataTable GetConnectionOnDataTable(string tableName)
    {
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (var con = new SQLiteConnection(loadConnectionString))
        {
          con.Open();

          string stm = $"SELECT * FROM {tableName}";
          var cmd = new SQLiteCommand(stm, con);
          SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
          DataTable dt = new DataTable(tableName);
          sda.Fill(dt);
          return dt;
        }
      }
      else
      {
        throw new FileNotFoundException("Database not found!");
      }
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
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
        {
          switch (sheetName)
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
      else
      {
        throw new FileNotFoundException("Database file not found!");
      }
    }
  }
}

