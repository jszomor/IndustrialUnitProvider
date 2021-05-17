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

    public DataTable GetAll(string tableName)
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

    public void Add<T>(T unit, string tableName)
    {
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
        {
          switch (tableName)
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

    public DataTable GetFilteredDB(string tableName, string itemType)
    {
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (var con = new SQLiteConnection(loadConnectionString))
        {
          con.Open();

          string stm = $"SELECT * FROM {tableName} where ItemType='{itemType}'";
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

    public void Delete(string tableName, int id)
    {
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
        {
          cnn.Execute($"delete from {tableName} where id={id}");
        }
      }
      else
      {
        throw new FileNotFoundException("Database file not found!");
      }
    }

    public void Update<T>(T unit, string tableName, int id)
    {
      if (File.Exists(Helper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
        {
          switch (tableName)
          {
            case "Equipment":
              cnn.Execute("update Equipment set ItemType=@ItemType, Capacity=@Capacity, Pressure=@Pressure, PowerConsumption=@PowerConsumption, " +
                          $"Manufacturer=@Manufacturer, Model=@Model, UnitPrice=@UnitPrice where id={id}", unit);
              break;

            case "Valve":
              cnn.Execute("update Valve set ItemType=@ItemType, Operation=@Operation, Size=@Size, ConnectionType=@ConnectionType, Supplier=@Supplier, " +
                $"Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id={id}", unit);
              break;

            case "Instrument":
              cnn.Execute("update Instrument set ItemType=@ItemType, OperationPrinciple=@OperationPrinciple, InstallationType=@InstallationType, MediumToMeasure=@MediumToMeasure, Supplier=@Supplier," +
                $"Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id={id}", unit);
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

