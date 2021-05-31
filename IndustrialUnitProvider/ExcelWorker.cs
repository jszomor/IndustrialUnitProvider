using IndustrialUnit.Model.Model;
using OfficeOpenXml;
using System;
using System.IO;

namespace IndustrialUnitProvider
{
  public static class ExcelWorker
  {
    public static ExcelWorksheet ReadExcel(string file, string sheetName, ref string logMessage)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

      var workbook = new ExcelPackage(File.OpenRead(file));

      if (workbook.Workbook.Worksheets[sheetName] == null)
      {
        logMessage += $"\nGiven type [{sheetName}] is not valid. \nPlese check the manual.";
      }
      else
      {
        logMessage += $"\n[{sheetName}] type is found.";
      }

      return workbook.Workbook.Worksheets[sheetName];
    }
  }
}
