using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace IndustrialUnit.WpfUI.Commands
{
  public static class EquipmentCommands
  {
    private static bool IsEmpty(EquipmentViewModel item)
    {
      if (string.IsNullOrEmpty(item.ItemType) ||
          string.IsNullOrEmpty(item.Capacity.ToString()) ||
          string.IsNullOrEmpty(item.Pressure.ToString()) ||
          string.IsNullOrEmpty(item.PowerConsumption.ToString()) ||
          string.IsNullOrEmpty(item.Manufacturer) ||
          string.IsNullOrEmpty(item.Model) ||
          string.IsNullOrEmpty(item.UnitPrice.ToString()))
      {
        return false;
      }

      return true;
    }

    public static void SubmitInsert(EquipmentViewModel item, string tableName)
    {
      if (IsEmpty(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Insert(item, tableName);
          MessageBox.Show($"You have successfully added.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (FileNotFoundException message)
        {
          Debug.WriteLine("Database file not found!");
          new FileNotFoundException($"{message}");
        }
      }
      else
      {
        MessageBox.Show($"No empty cell is allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
