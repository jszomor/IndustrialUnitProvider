using Dapper;
using IndustrialUnit.Model;
using System;
using System.Collections.Generic;
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

    public static void CreateDatabase(ref List<string> logMessage)
    {
      SQLiteConnection con;
      SQLiteCommand cmd;

      string sqlEquipment = @"CREATE TABLE EQUIPMENT(
                              ID                INTEGER PRIMARY KEY AUTOINCREMENT,
                              ItemType          TEXT    NULL,
                              Capacity          DECIMAL NULL,
                              Pressure          DECIMAL NULL,
                              PowerConsumption  DECIMAL NULL,
                              Manufacturer      TEXT    NULL,
                              Model             TEXT    NULL,
                              UnitPrice         DECIMAL NULL                              
                            );";

      string sqlValve = @"CREATE TABLE VALVE(
                              ID                INTEGER PRIMARY KEY AUTOINCREMENT,
                              ItemType          TEXT    NULL,
                              Operation         TEXT    NULL,
                              Size              INTEGER NULL,
                              ConnectionType    TEXT    NULL,
                              Supplier          TEXT    NULL,
                              Manufacturer      TEXT    NULL,
                              UnitPrice         DECIMAL NULL                              
                            );";

      string sqlInstrument = @"CREATE TABLE INSTRUMENT(
                              ID                  INTEGER PRIMARY KEY AUTOINCREMENT,
                              ItemType            TEXT  NULL,
                              OperationPrinciple  TEXT  NULL,
                              InstallationType    TEXT  NULL,
                              MediumToMeasure     TEXT  NULL,
                              Supplier            TEXT  NULL,
                              Manufacturer        TEXT  NULL,
                              UnitPrice           DECIMAL NULL                              
                            );";

      string[] tableArray = new[] { sqlEquipment, sqlValve, sqlInstrument };

      if (!File.Exists("IndustrialUnitDB.db"))
      {
        SQLiteConnection.CreateFile("IndustrialUnitDB.db");

        con = new SQLiteConnection("Data Source=IndustrialUnitDB.db;Version=3;");
        con.Open();

        foreach (var sqlCommand in tableArray)
        {
          cmd = new SQLiteCommand(sqlCommand, con);
          cmd.ExecuteNonQuery();
        }

        con.Close();

        logMessage.Add("Database created successfully.");
        //return logMessage;
      }
      else
      {
        logMessage.Add("Database already exist. \nDelete or rename the previous one.");
        //return logMessage;
      }
    }

    public static void WipeDatabase(ref List<string> logMessage)
    {
      if (File.Exists(PathHelper.DatabasePath("IndustrialUnitDB.db")))
      {
        using (IDbConnection cnn = new SQLiteConnection(loadConnectionString))
        {
          string deleteEquipment = @"DELETE FROM EQUIPMENT";
          string deleteValve = @"DELETE FROM VALVE";
          string deleteInstrument = @"DELETE FROM INSTRUMENT";

          cnn.Execute(deleteEquipment);
          cnn.Execute(deleteValve);
          cnn.Execute(deleteInstrument);
        }

        logMessage.Add("Database is successfully wiped.");
        //return logMessage;
      }
      else
      {
        logMessage.Add("Warning! Database not found!");
        //return logMessage;
      }
    }
  }
}

