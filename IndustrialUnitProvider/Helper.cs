using OfficeOpenXml;
using System;
using System.IO;

namespace IndustrialUnitProvider
{
  public static class Helper
  {
    public static ExcelWorksheet ReadExcel(Func<string, string> action, string file, string sheetName)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

      var workbook = new ExcelPackage(File.OpenRead(action(file)));

      if (workbook.Workbook.Worksheets[sheetName] == null)
      {
        throw new InvalidOperationException($"Passed sheetname [{sheetName}] is not valid.");
      }

      return workbook.Workbook.Worksheets[sheetName];
    }

    public static string ProjectPath(string file) => Path.Combine(Directory.GetCurrentDirectory(), file);

    public static string TestPath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName), "TestData", file);

    public static string DataBasePath(string file) => Path.Combine((Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName), "Database", file);
  }
}
