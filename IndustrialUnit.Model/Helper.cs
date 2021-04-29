using System;
using System.IO;
using System.Reflection;

namespace IndustrialUnit.Model
{
  public static class Helper
  {
    public static string ProjectPath(string file) => Path.Combine(Directory.GetCurrentDirectory(), file);

    public static string TestPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName), "TestData", file);

    //public static string TestPath(string file)
    //{
    //  string p = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", file);
    //  return p;
    //}

    public static string ExcelToJsonPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName), "IndustrialUnitDatabase", "ExcelToJson", file);

    public static string DatabasePath(string databaseName) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName), "IndustrialUnitDatabase", databaseName);

    public static decimal ConvertStringToDecimal(string value)
    {
      bool success = decimal.TryParse(value, out decimal number);

      if (success)
      {
        return number;
      }
      else
      {
        throw new FormatException($"The value cannot converted into decimal type.");
      }
    }
  }
}
