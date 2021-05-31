﻿using System;
using System.IO;

namespace IndustrialUnit.Model
{
  public static class PathHelper
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
  }
}
