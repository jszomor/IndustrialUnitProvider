using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace IndustrialUnitDatabase
{
  public static class SQLiteDataAccess
  {
    private static readonly string DatabaseName = "IndustrialUnitDB.db";
    private static readonly string Database = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DatabaseName);
    private static readonly string LoadConnectionString = $"Data Source={Database}";

    private static void RunDatabaseCommandsToModify(Action<SQLiteConnection> action)
    {
      if (!File.Exists(Database))
        throw new FileNotFoundException("Database not found!");
      using var connection = new SQLiteConnection(LoadConnectionString);
      connection.Open();
      action(connection);
    }

    private static T RunDatabaseCommandsToRead<T>(Func<SQLiteConnection, T> action)
    {
      if (!File.Exists(Database))
        throw new FileNotFoundException("Database not found!");
      using var connection = new SQLiteConnection(LoadConnectionString);
      connection.Open();
      return action(connection);
    }

    public static DataTable GetDb(string sqlCommand, string tableName)
    {
      try
      {
        return RunDatabaseCommandsToRead(db =>
        {
          SQLiteCommand command = new(sqlCommand, db);
          SQLiteDataAdapter dataAdapter = new(command);
          DataTable table = new(tableName);
          dataAdapter.Fill(table);
          return table;
        });
      }
      catch (FileNotFoundException)
      {
        return null;
        //throw new FileNotFoundException($"{message}");
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
      if (File.Exists(Database))
      {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString))
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

      if (!File.Exists(DatabaseName))
      {
        SQLiteConnection.CreateFile(@"IndustrialUnitDB.db");

        con = new SQLiteConnection("Data Source=IndustrialUnitDB.db;Version=3;");
        con.Open();

        foreach (var sqlCommand in tableArray)
        {
          cmd = new SQLiteCommand(sqlCommand, con);
          cmd.ExecuteNonQuery();
        }

        con.Close();

        logMessage.Add("Database created successfully.");
      }
      else
      {
        logMessage.Add("Database already exist. \nDelete or rename the previous one.");
      }
    }

    public static void WipeDatabase(ref List<string> logMessage)
    {
      if (File.Exists(Database))
      {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString))
        {

          string[] tableArray = new[] { "EQUIPMENT", "VALVE", "INSTRUMENT" };

          for (int i = 0; i < tableArray.Length; i++)
          {
            cnn.Execute($"DELETE FROM {tableArray[i]}");
            cnn.Execute($"UPDATE `sqlite_sequence` SET `seq` = 0 WHERE `name` = '{tableArray[i]}';");
          }
        }

        logMessage.Add("Database is successfully wiped.");
      }
      else
      {
        logMessage.Add("No database found to be wiped!");
      }
    }
  }
}

