﻿using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace IndustrialUnit.WpfUI.Models
{
  public class EquipmentModel
  {
    private static readonly string TableName = "Equipment";

    public static ObservableCollection<Equipment> MapEquipment(string sqlCommand)
    {
      ObservableCollection<Equipment> equipmentCollection = new();
      var getFilteredItem = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      var dbRowNumber = getFilteredItem.Rows.Count;

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = getFilteredItem.Rows[i];
        equipmentCollection.Add(
          new Equipment()
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
      return equipmentCollection;
    }

    public static ObservableCollection<Equipment> GetAllEquipments() => MapEquipment($"SELECT * FROM {TableName}");

    public static (ObservableCollection<Equipment>, string) GetFilteredEquipments(ObservableCollection<Equipment> equipments, string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
        return (equipments, "Filter key is 'Item Name', \nit cannot be empty for searching!");

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      return (MapEquipment(sqlCommand), 
        $"Filter name: {selectedItem} \nPress Refresh to see the whole database again.");
    }

    public static string SubmitAdd(Equipment item)
    {
      if (!IsTextBoxEmpty(item) || item == null )
        return "No empty cell is allowed.";

      string sqlCommand = $"insert into {TableName} (ItemType, Capacity, Pressure, PowerConsumption, Manufacturer, Model, UnitPrice) " +
                "values (@ItemType, @Capacity, @Pressure, @PowerConsumption, @Manufacturer, @Model, @UnitPrice)";

      try
      {
        SQLiteDataAccess.ActOnItem(item, sqlCommand);

        return "You have successfully added. \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitUpdate(Equipment equipment)
    {
      if (!IsTextBoxEmpty(equipment) || equipment == null)
        return "No empty cell is allowed.";

      string sqlCommand = "update Equipment set ItemType=@ItemType, Capacity=@Capacity, Pressure=@Pressure, PowerConsumption=@PowerConsumption, " +
                  $"Manufacturer=@Manufacturer, Model=@Model, UnitPrice=@UnitPrice where id=";

      try
      {
        SQLiteDataAccess.ActOnItem(equipment, sqlCommand + equipment.Id);
        return $"Id number: {equipment.Id} successfully updated \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitDelete(Equipment equipment)
    {
      if (equipment.Id <= 0 || equipment == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={equipment.Id}";

      try
      {      
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: {equipment.Id} successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static bool IsTextBoxEmpty(Equipment eq)
    {
      if (string.IsNullOrEmpty(eq.ItemType) ||
          string.IsNullOrEmpty(eq.Capacity.ToString()) ||
          string.IsNullOrEmpty(eq.Pressure.ToString()) ||
          string.IsNullOrEmpty(eq.PowerConsumption.ToString()) ||
          string.IsNullOrEmpty(eq.Manufacturer) ||
          string.IsNullOrEmpty(eq.Model) ||
          string.IsNullOrEmpty(eq.UnitPrice.ToString()))
      {
        return false;
      }
      return true;
    }
  }
}
