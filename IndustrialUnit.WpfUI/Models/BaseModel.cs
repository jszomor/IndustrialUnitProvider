﻿using IndustrialUnit.Model.Model;
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
    public static string SubmitAdd<T>(T item, string tableName, Func<T, bool> action)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Add(item, tableName);
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
        return "No empty cell is allowed.";
      }
    }

    public static string SubmitUpdate<T>(T item, string tableName, Func<T, bool> action, int id)
    {
      if (action(item))
      {
        try
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Update(item, tableName, id);
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
        return "No empty cell is allowed.";
      }
    }

    public static string SubmitDelete(string tableName, int id)
    {
      try
      {
        if(String.IsNullOrWhiteSpace(id.ToString()) || id > 0)
        {
          var sqlAccess = new SQLiteDataAccess();
          sqlAccess.Delete(tableName, id);
          return $"Id number: {id} successfully deleted. \nPress Refresh to see the result.";
        }
        else
        {
          return "Please select an item to delete.";
        }
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }
  }
}
