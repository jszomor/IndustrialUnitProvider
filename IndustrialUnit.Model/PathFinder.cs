using System;
using System.IO;

namespace IndustrialUnitProvider
{
  public static class PathFinder
  {
    public static string ProjectPath(string file) => Path.Combine(Directory.GetCurrentDirectory(), file);

    public static string TestPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName), "TestData", file);

    public static string ExcelToJsonPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName), "IndustrialUnitDatabase", "ExcelToJson", file);

    public static string DatabasePath(string databaseName) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName), "IndustrialUnitDatabase", databaseName);
  }
}
