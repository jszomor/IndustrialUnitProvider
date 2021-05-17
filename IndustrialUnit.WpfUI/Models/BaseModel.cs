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
  public class BaseModel
  {
    public string SubmitAdd<T>(T item, string tableName, Func<T, bool> action)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Add(item, tableName);
          //MessageBox.Show($"You have successfully added. \nPress refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          return "You have successfully added. \nPress refresh to see the result.";
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
        return "No empty cell is allowed.";
      }
    }

    public string SubmitUpdate<T>(T item, string tableName, Func<T, bool> action, int id)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Update(item, tableName, id);
          //MessageBox.Show($"{id} id number successfully updated \nPress refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          return $"Id number: {id} successfully updated \nPress refresh to see the result.";
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
        return "No empty cell is allowed.";
      }
    }

    public string SubmitDelete(string tableName, int id)
    {
      try
      {
        if(String.IsNullOrWhiteSpace(id.ToString()) || id > 0)
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Delete(tableName, id);
          //MessageBox.Show($"Id: {id} successfully deleted. \nPress Refresh to see the result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          return $"Id number: {id} successfully deleted. \nPress Refresh to see the result.";
        }
        else
        {
          //MessageBox.Show($"Please select an item to delete.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
          return "Please select an item to delete.";
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
    public DataView FillDataGrid(string tableName)
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

    public (DataView, string) FillDataGridFiltered(string tableName, string itemType)
    {

      if (!String.IsNullOrWhiteSpace(itemType))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          DataTable dt = sqlAccess.GetFilteredDB(tableName, itemType);
          return (dt.DefaultView, $"Filter item: {itemType}");
        }
        catch (FileNotFoundException message)
        {
          throw new FileNotFoundException($"{message}");
        }
      }
      else
      {
        return (null, "");
      }
    }

    public void DataGrid_SelectionChanged<T>(T item, object sender, List<string> textBoxNames) where T : class, new()
    {
      DataGrid dg = (DataGrid)sender;
      if (dg.SelectedItem is DataRowView rowSelected)
      {
        PropertyInfo[] properties = item.GetType().GetProperties();
        int i = 0;
        foreach (var prop in properties)
        {
          try
          {
            if (i >= textBoxNames.Count)
            {
              return;              
            }
            else if(prop.Name == textBoxNames[i])
            {
              prop.SetValue(item, Convert.ChangeType(rowSelected[textBoxNames[i]], prop.PropertyType));
              ++i;
            }            
          }
          catch(FormatException)
          {
            throw new FormatException();
          }
        }
      }
    }
  }
}
