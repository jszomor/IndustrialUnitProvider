using System;
using System.IO;
using System.Reflection;

namespace IndustrialUnit.Model
{
  public static class PathHelper
  {
    public static string TestPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName), "TestData", file);

    //public static string TestPath(string file)
    //{
    //  string p = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", file);
    //  return p;
    //}

  }
}
