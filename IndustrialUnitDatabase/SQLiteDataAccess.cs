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
  public static class SQLiteDataAccess
  {
    private static readonly string loadConnectionString = $"Data Source={PathHelper.DatabasePath("IndustrialUnitDB.db")}";

    private static void RunDatabaseCommandsToModify(Action<SQLiteConnection> action)
    {
      if (!File.Exists(PathHelper.DatabasePath("IndustrialUnitDB.db")))
        throw new FileNotFoundException("Database not found!");
      using var connection = new SQLiteConnection(loadConnectionString);
      connection.Open();
      action(connection);
    }

    private static T RunDatabaseCommandsToRead<T>(Func<SQLiteConnection, T> action)
    {
      if (!File.Exists(PathHelper.DatabasePath("IndustrialUnitDB.db")))
        throw new FileNotFoundException("Database not found!");
      using var connection = new SQLiteConnection(loadConnectionString);
      connection.Open();
      return action(connection);
    }

    public static DataTable GetDb(string sqlCommand, string tableName)
    {
      try
      {
        return RunDatabaseCommandsToRead(db =>
        {
          var command = new SQLiteCommand(sqlCommand, db);
          SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
          DataTable table = new DataTable(tableName);
          dataAdapter.Fill(table);
          return table;
        });
      }
      catch (FileNotFoundException message)
      {
        throw new FileNotFoundException($"{message}");
      }
    }

    public static void AddItem<T>(T unitType, string sqlCommand)
    {
      RunDatabaseCommandsToModify(db =>
      {
        db.Execute(sqlCommand, unitType);
      });
    }

    public static void UpdateEquipment<T>(T unit, int id)
    {
      RunDatabaseCommandsToModify(db =>
      {
        db.Execute("update Equipment set ItemType=@ItemType, Capacity=@Capacity, Pressure=@Pressure, PowerConsumption=@PowerConsumption, " +
                  $"Manufacturer=@Manufacturer, Model=@Model, UnitPrice=@UnitPrice where id={id}", unit);
      });
    }

    public static void Delete(string tableName, int id)
    {
      RunDatabaseCommandsToModify(db =>
      {
        db.Execute($"delete from {tableName} where id={id}");
      });
    }

    public static void Add<T>(T unit, string tableName)
    {
      if (File.Exists(PathHelper.DatabasePath("IndustrialUnitDB.db")))
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

    public static void Update<T>(T unit, string tableName, int id)
    {
      if (File.Exists(PathHelper.DatabasePath("IndustrialUnitDB.db")))
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

