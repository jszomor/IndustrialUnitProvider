using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnit.WpfUI.Views;
using IndustrialUnitDatabase;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.Commands
{
  public static class EquipmentCommands
  {
    private static bool IsEquipmentEmpty(EquipmentViewModel item)
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

    public static bool IsEmpty<T>(T item)
    {
      if(item is EquipmentViewModel)
      {
        EquipmentViewModel eqItem = item as EquipmentViewModel;
        return IsEquipmentEmpty(eqItem);
      }
      else
      {
        throw new InvalidOperationException($"Invalid modelView name: [{item}]");
      }
    }

    public static void SubmitInsert<T>(T item, string tableName)
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
          throw new FileNotFoundException($"{message}");
        }
      }
      else
      {
        MessageBox.Show($"No empty cell is allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    /// <summary>
    /// Pass database to datagrid
    /// </summary>
    /// <returns></returns>
    public static DataView FillDataGrid(string tableName)
    {
      try
      {
        var equipmentTableGrid = new DataGrid();
        var sqlAccess = new SQLiteDataAccess();
        DataTable dt = sqlAccess.GetConnectionOnDataTable(tableName);
        return dt.DefaultView;
      }
      catch (FileNotFoundException message)
      {
        throw new FileNotFoundException($"{message}");
      }
    }
  }
}
