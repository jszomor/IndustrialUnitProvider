using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace IndustrialUnitDatabase
{
  public class SQLiteDataAccess
  {
    public static List<T> LoadPeople<T>()
    {
      using(IDbConnection cnn = new SQLiteConnection(""))
      {
        cnn.Execute("");
      }

      return null;
    }
  }
}
