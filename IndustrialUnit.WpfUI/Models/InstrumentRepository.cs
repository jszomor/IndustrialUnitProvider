using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace IndustrialUnit.WpfUI.Models
{
  public class InstrumentRepository
  {
    private static readonly string TableName = "Instrument";

    internal static List<Instrument> MapInstrument(string sqlCommand)
    {
      DataTable instrumentData = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      if (instrumentData == null)
      {
        return null;
      }

      int dbRowNumber = instrumentData.Rows.Count;

      List<Instrument> list = new();

      if (dbRowNumber == 0)
      {
        return list;
      }


      for (int i = 0; i < dbRowNumber; i++)
      {
        DataRow item = instrumentData.Rows[i];
        list.Add(
          new Instrument()
          {
            Id = Convert.ToInt32(item.ItemArray[0]),
            ItemType = Convert.ToString(item.ItemArray[1]),
            OperationPrinciple = Convert.ToString(item.ItemArray[2]),
            InstallationType = Convert.ToString(item.ItemArray[3]),
            MediumToMeasure = Convert.ToString(item.ItemArray[4]),
            Supplier = Convert.ToString(item.ItemArray[5]),
            Manufacturer = Convert.ToString(item.ItemArray[6]),
            UnitPrice = Convert.ToDecimal(item.ItemArray[7]),
          });
      }
      return list;
    }

    internal static (List<Instrument>, string) GetAllInstruments()
    {
      string sqlCommand = $"SELECT * FROM {TableName}";

      if (MapInstrument(sqlCommand) == null)
        return (null, "Database not found! \nCreate a new one in the file menu \nor contact the developer.");

      return (MapInstrument(sqlCommand), "Database loaded successfully.");
    }

    internal static (List<Instrument>, string) GetFilteredInstruments(string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
      {
        return (null, "Filter key is [Item Name], \nit cannot be empty for searching!");
      }

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      return MapInstrument(sqlCommand).Count == 0
          ? (null, $"Filter name: [{selectedItem}] not found.")
          : (MapInstrument(sqlCommand),
        $"Filter name: [{selectedItem}] \nPress Refresh to see the whole database again.");
    }

    internal static string SubmitAdd(Instrument item)
    {
      if (!IsTextBoxEmpty(item) || item == null)
      {
        return "No empty cell is allowed for insert.";
      }

      string sqlCommand = $"insert into {TableName} (ItemType, OperationPrinciple, InstallationType, MediumToMeasure, Supplier, Manufacturer, UnitPrice) " +
                "values (@ItemType, @OperationPrinciple, @InstallationType, @MediumToMeasure, @Supplier, @Manufacturer, @UnitPrice)";

      try
      {
        int newId = SQLiteDataAccess.ActOnItem(item, sqlCommand);

        return $"You have successfully added [{newId}] id. \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static string SubmitUpdate(Instrument Instrument)
    {
      if (!IsTextBoxEmpty(Instrument) || Instrument == null)
      {
        return "No empty cell is allowed for update.";
      }

      string sqlCommand = "update Instrument set ItemType=@ItemType, OperationPrinciple=@OperationPrinciple, InstallationType=@InstallationType, MediumToMeasure=@MediumToMeasure, " +
                  "Supplier=@Supplier, Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id=";

      try
      {
        SQLiteDataAccess.ActOnItem(Instrument, sqlCommand + Instrument.Id);
        return $"Id number: [{Instrument.Id}] successfully updated \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static string SubmitDelete(Instrument Instrument)
    {
      if (Instrument.Id <= 0 || Instrument == null || Instrument.Id == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={Instrument.Id}";

      try
      {
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: [{Instrument.Id}] successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static bool IsTextBoxEmpty(Instrument ins)
    {
      if (
          string.IsNullOrEmpty(ins.ItemType) ||
          string.IsNullOrEmpty(ins.OperationPrinciple) ||
          string.IsNullOrEmpty(ins.InstallationType) ||
          string.IsNullOrEmpty(ins.MediumToMeasure) ||
          string.IsNullOrEmpty(ins.Supplier) ||
          string.IsNullOrEmpty(ins.Manufacturer) ||
          ins.UnitPrice == null)
      {
        return false;
      }
      return true;
    }
  }
}
