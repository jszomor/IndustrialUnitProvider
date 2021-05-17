using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnit.WpfUI.Views;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace IndustrialUnit.WpfUI.Models
{
  public static class BaseModel
  {
    //public static string MessageToView { get; set; }

    public static void SubmitInsert<T>(T item, string tableName, Func<T, bool> action, string messageToView)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Insert(item, tableName);
          //MessageBox.Show($"You have successfully added. \nPress refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          messageToView = "You have successfully added. \nPress refresh to see the result.";
        }
        catch (FileNotFoundException message)
        {
          Debug.WriteLine("Database file not found!");
          throw new FileNotFoundException($"{message}");
        }
      }
      else
      {
        //MessageBox.Show($"No empty cell is allowed.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        messageToView = "No empty cell is allowed.";
      }
    }

    public static void SubmitUpdate<T>(T item, string tableName, Func<T, bool> action, int id, string messageToView)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Update(item, tableName, id);
          //MessageBox.Show($"{id} id number successfully updated \nPress refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          messageToView = $"{id} id number successfully updated \nPress refresh to see the result.";
        }
        catch (FileNotFoundException message)
        {
          Debug.WriteLine("Database file not found!");
          throw new FileNotFoundException($"{message}");
        }
      }
      else
      {
        //MessageBox.Show($"No empty cell is allowed.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        messageToView = "No empty cell is allowed.";
      }
    }

    public static void SubmitDelete(string tableName, int id, string messageToView)
    {
      try
      {
        if(String.IsNullOrWhiteSpace(id.ToString()) || id > 0)
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Delete(tableName, id);
          //MessageBox.Show($"Id: {id} successfully deleted. \nPress Refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          messageToView = $"Id: {id} successfully deleted. \nPress Refresh to see the result.";
        }
        else
        {
          //MessageBox.Show($"Please select an item to delete.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          messageToView = "Please select an item to delete.";
        }
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
        var sqlAccess = new SQLiteDataAccess();
        DataTable dt = sqlAccess.GetAll(tableName);
        return dt.DefaultView;
      }
      catch (FileNotFoundException message)
      {
        throw new FileNotFoundException($"{message}");
      }
    }

    public static DataView FillDataGridFiltered(string tableName, string itemType)
    {
      try
      {
        var sqlAccess = new SQLiteDataAccess();
        DataTable dt = sqlAccess.GetFilteredDB(tableName, itemType);
        return dt.DefaultView;
      }
      catch (FileNotFoundException message)
      {
        throw new FileNotFoundException($"{message}");
      }
    }
  }
}
