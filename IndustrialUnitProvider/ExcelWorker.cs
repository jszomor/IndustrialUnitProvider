using IndustrialUnit.Model.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace IndustrialUnitProvider
{
  public static class ExcelWorker
  {
    public static ExcelWorksheet ReadExcel(string file, string sheetName, ref List<string> logMessage)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

      var workbook = new ExcelPackage(File.OpenRead(file));

      if (workbook.Workbook.Worksheets[sheetName] == null)
      {
        logMessage.Add($"[{sheetName}] sheet is not found.");
        return null;
      }
      else
      {
        logMessage.Add($"[{sheetName}] sheet is found.");
        return workbook.Workbook.Worksheets[sheetName];
      }
    }

    public static ExcelPackage SetupExcelPackage(ExcelPackage excelPackage)
    {
      excelPackage.Workbook.Properties.Author = "János Szomor";
      excelPackage.Workbook.Properties.Title = "Industrial Item Manager template";
      excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
      excelPackage.Workbook.Properties.Created = DateTime.Now;

      return excelPackage;
    }
  }
}
