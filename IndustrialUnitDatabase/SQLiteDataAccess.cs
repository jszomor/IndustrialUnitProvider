using Dapper;
using IndustrialUnit.Model;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

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

    public static int ActOnItem<T>(T unitType, string sqlCommand)
    {
      int newId = 0;
      RunDatabaseCommandsToModify(db =>
      {
        db.Execute(sqlCommand, unitType);
        newId = (int)db.LastInsertRowId;
      });

      return newId;
    }

    public static void Delete(string sqlCommand)
    {
      RunDatabaseCommandsToModify(db =>
      {
        db.Execute(sqlCommand);
      });
    }

    public static void AddCollection<T>(T unit, string tableName)
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
  }
}

