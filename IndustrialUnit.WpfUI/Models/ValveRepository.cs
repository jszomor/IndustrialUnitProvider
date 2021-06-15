using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace IndustrialUnit.WpfUI.Models
{
  public class ValveRepository
  {
    private static readonly string TableName = "Valve";

    internal static List<Valve> MapValveList(string sqlCommand)
    {
      var valveData = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      if (valveData == null) return null;

      var dbRowNumber = valveData.Rows.Count;
      
      List<Valve> list = new();

      if (dbRowNumber == 0)
        return list;


      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = valveData.Rows[i];
        list.Add(
          new Valve()
          {
            Id = Convert.ToInt32(item.ItemArray[0]),
            ItemType = Convert.ToString(item.ItemArray[1]),
            Operation = Convert.ToString(item.ItemArray[2]),
            Size = Convert.ToInt32(item.ItemArray[3]),
            ConnectionType = Convert.ToString(item.ItemArray[4]),
            Supplier = Convert.ToString(item.ItemArray[5]),
            Manufacturer = Convert.ToString(item.ItemArray[6]),
            UnitPrice =  Convert.ToDecimal(item.ItemArray[7]),
          });
      }
      return list;
    }

    internal static (List<Valve>, string) GetAllValves()
    {
      string sqlCommand = $"SELECT * FROM {TableName}";

      if (MapValveList(sqlCommand) == null)
        return (null, "Database not found! \nCreate a new one in the file menu \nor contact the developer.");

      return (MapValveList(sqlCommand), "Database loaded successfully.");
    }

    internal static (List<Valve>, string) GetFilteredValves(string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
        return (null, "Filter key is [Item Name], \nit cannot be empty for filtering!");

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      if (MapValveList(sqlCommand).Count == 0)
        return (null, $"Filter name: [{selectedItem}] not found in database.");

      return (MapValveList(sqlCommand), 
        $"Filter name: [{selectedItem}] \nPress Refresh to see the whole database again.");
    }

    internal static string SubmitAdd(Valve item)
    {
      if (!IsValveEmpty(item) || item == null)
        return "No empty cell is allowed for insert.";

      string sqlCommand = $"insert into {TableName} (ItemType, Operation, Size, ConnectionType, Supplier, Manufacturer, UnitPrice) " +
                "values (@ItemType, @Operation, @Size, @ConnectionType, @Supplier, @Manufacturer, @UnitPrice)";

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

    internal static string SubmitUpdate(Valve item)
    {
      if (!IsValveEmpty(item) || item == null)
        return "No empty cell is allowed for update.";

      string sqlCommand = $"update {TableName} set ItemType=@ItemType, Operation=@Operation, Size=@Size, ConnectionType=@ConnectionType, " +
                  $"Supplier=@Supplier, Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id=";

      try
      {
        SQLiteDataAccess.ActOnItem(item, sqlCommand + item.Id);
        return $"Id number: [{item.Id}] successfully updated \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static string SubmitDelete(Valve valve)
    {
      if (valve.Id <= 0 || valve == null || valve.Id == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={valve.Id}";

      try
      {      
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: [{valve.Id}] successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static bool IsValveEmpty(Valve valve)
    {
      if (
          string.IsNullOrEmpty(valve.ItemType) ||
          string.IsNullOrEmpty(valve.Operation) ||
          valve.Size == null ||
          string.IsNullOrEmpty(valve.ConnectionType) ||
          string.IsNullOrEmpty(valve.Supplier) ||
          string.IsNullOrEmpty(valve.Manufacturer) ||
          valve.UnitPrice == null)
      {
        return false;
      }
      return true;
    }
  }
}
