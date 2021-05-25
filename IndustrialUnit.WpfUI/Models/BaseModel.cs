using IndustrialUnitDatabase;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace IndustrialUnit.WpfUI.Models
{
  public class BaseModel
  {

    public static string SubmitUpdate<T>(T item, Func<T, bool> action, int id)
    {
      if (action(item))
      {
        try
        {
          SQLiteDataAccess.UpdateEquipment(item, id);
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
        if (String.IsNullOrWhiteSpace(id.ToString()) || id > 0)
        {
          SQLiteDataAccess.Delete(tableName, id);
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
