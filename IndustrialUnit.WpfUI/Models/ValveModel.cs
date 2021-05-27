using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace IndustrialUnit.WpfUI.Models
{
  public class ValveModel
  {
    private static readonly string TableName = "Valve";

    public static ObservableCollection<Valve> MapValve(string sqlCommand)
    {
      ObservableCollection<Valve> valveCollection = new();
      var getFilteredItem = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      var dbRowNumber = getFilteredItem.Rows.Count;

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = getFilteredItem.Rows[i];
        valveCollection.Add(
          new Valve()
          {
            Id = Convert.ToInt32(item.ItemArray[0]),
            ItemType = Convert.ToString(item.ItemArray[1]),
            Operation = Convert.ToString(item.ItemArray[2]),
            Size = Convert.ToDecimal(item.ItemArray[3]),
            ConnectionType = Convert.ToString(item.ItemArray[4]),
            Supplier = Convert.ToString(item.ItemArray[5]),
            Manufacturer = Convert.ToString(item.ItemArray[6]),
            UnitPrice = Convert.ToDecimal(item.ItemArray[7]),
          });
      }
      return valveCollection;
    }

    public static ObservableCollection<Valve> GetAllValves() => MapValve($"SELECT * FROM {TableName}");

    public static (ObservableCollection<Valve>, string) GetFilteredValves(ObservableCollection<Valve> valves, string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
        return (valves, "Filter key is 'Item Name', \nit cannot be empty for searching!");

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      return (MapValve(sqlCommand), 
        $"Filter name: {selectedItem} \nPress Refresh to see the whole database again.");
    }

    public static string SubmitAdd(Valve valve)
    {
      if (!IsTextBoxEmpty(valve) || valve == null)
        return "No empty cell is allowed.";

      string sqlCommand = $"insert into {TableName} (ItemType, Operation, Size, ConnectionType, Supplier, Manufacturer, UnitPrice) " +
                "values (@ItemType, @Operation, @Size, @ConnectionType, @Supplier, @Manufacturer, @UnitPrice)";

      try
      {
        SQLiteDataAccess.ActOnItem(valve, sqlCommand);

        return "You have successfully added. \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitUpdate(Valve valve)
    {
      if (!IsTextBoxEmpty(valve) || valve == null)
        return "No empty cell is allowed.";

      string sqlCommand = $"update {TableName} set ItemType=@ItemType, Operation=@Operation, Size=@Size, ConnectionType=@ConnectionType, " +
                  $"Supplier=@Supplier, Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id=";

      try
      {
        SQLiteDataAccess.ActOnItem(valve, sqlCommand + valve.Id);
        return $"Id number: {valve.Id} successfully updated \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitDelete(Valve valve)
    {
      if (valve.Id <= 0 || valve == null || valve.Id == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={valve.Id}";

      try
      {      
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: {valve.Id} successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static bool IsTextBoxEmpty(Valve valve)
    {
      if (
          valve.Id == null ||
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
