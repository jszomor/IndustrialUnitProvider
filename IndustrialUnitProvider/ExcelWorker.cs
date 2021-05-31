using OfficeOpenXml;
using System;
using System.IO;

namespace IndustrialUnitProvider
{
  public static class ExcelWorker
  {
    public static ExcelWorksheet ReadExcel(string file, string sheetName)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

      var workbook = new ExcelPackage(File.OpenRead(file));

      if (workbook.Workbook.Worksheets[sheetName] == null)
      {
        throw new InvalidOperationException($"Passed sheetname [{sheetName}] is not valid.");
      }

      return workbook.Workbook.Worksheets[sheetName];
    }
  }
}
