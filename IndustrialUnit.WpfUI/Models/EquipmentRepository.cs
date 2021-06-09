using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using IndustrialUnit.Model.Model;

namespace IndustrialUnit.WpfUI.Models
{
  public class EquipmentRepository
  {
    private static readonly string TableName = "Equipment";

    private static List<Equipment> MapEquipmentList(string sqlCommand)
    {
      var equipmentData = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      var dbRowNumber = equipmentData.Rows.Count;

      if (dbRowNumber == 0)
        return null;

      var list = new List<Equipment>();

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = equipmentData.Rows[i];

        list.Add(
            new Equipment
            {
              Id = Convert.ToInt32(item.ItemArray[0]),
              ItemType = Convert.ToString(item.ItemArray[1]),
              Capacity = Convert.ToDecimal(item.ItemArray[2]),
              Pressure = Convert.ToDecimal(item.ItemArray[3]),
              PowerConsumption = Convert.ToDecimal(item.ItemArray[4]),
              Manufacturer = Convert.ToString(item.ItemArray[5]),
              Model = Convert.ToString(item.ItemArray[6]),
              UnitPrice = Convert.ToDecimal(item.ItemArray[7]),
            });
      }

      return list;
    }

    internal static (List<Equipment>, string) GetAllEquipments()
    {
      string sqlCommand = $"SELECT * FROM {TableName}";

      if ((MapEquipmentList(sqlCommand) == null))
        return (null, "Database not found or empty.");

      return (MapEquipmentList(sqlCommand), "Database loaded successfully.");
    }

    internal static (List<Equipment>, string) GetFilteredEquipments(string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
        return (null, "Filter key is [Item Name], \nit cannot be empty for filtering!");

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      if ((MapEquipmentList(sqlCommand) == null))
        return (null, $"Filter name: [{selectedItem}] not found in database.");

      return (MapEquipmentList(sqlCommand),
          $"Filter name is: [{selectedItem}] \nPress Refresh to see the whole database again.");
    }

    internal static string SubmitAdd(Equipment item)
    {
      if (!IsEquipmentEmpty(item) || item == null)
        return "No empty cell is allowed for Insert.";

      string sqlCommand =
          $"insert into {TableName} (ItemType, Capacity, Pressure, PowerConsumption, Manufacturer, Model, UnitPrice) " +
          "values (@ItemType, @Capacity, @Pressure, @PowerConsumption, @Manufacturer, @Model, @UnitPrice)";

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

    internal static string SubmitUpdate(Equipment item)
    {
      if (!IsEquipmentEmpty(item) || item == null)
        return "No empty cell is allowed for Update.";

      string sqlCommand =
          $"update {TableName} set ItemType=@ItemType, Capacity=@Capacity, Pressure=@Pressure, PowerConsumption=@PowerConsumption, " +
          $"Manufacturer=@Manufacturer, Model=@Model, UnitPrice=@UnitPrice where id=";

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

    internal static string SubmitDelete(Equipment item)
    {
      if (item.Id <= 0 || item == null || item.Id == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={item.Id}";

      try
      {
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: [{item.Id}] successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    internal static bool IsEquipmentEmpty(Equipment item)
    {
      if (
          string.IsNullOrEmpty(item.ItemType) ||
          item.Capacity == null ||
          item.Pressure == null ||
          item.PowerConsumption == null ||
          string.IsNullOrEmpty(item.Manufacturer) ||
          string.IsNullOrEmpty(item.Model) ||
          item.UnitPrice == null)
      {
        return false;
      }
      return true;
    }
  }
}