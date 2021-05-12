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
  public static class BaseModel
  {
    public static void SubmitInsert<T>(T item, string tableName, Func<T, bool> action)
    {
      if (action(item))
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

    public static void SubmitDelete(string tableName, int id)
    {
      try
      {
        var sqlAccess = new SQLiteDataAccess();
        sqlAccess.Delete(tableName, id);
        MessageBox.Show($"You have successfully deleted.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
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
