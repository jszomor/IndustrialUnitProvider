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

      try
      {
        FileStream openFile = File.OpenRead(file);
        var workbook = new ExcelPackage(openFile);
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
      catch (IOException)
      {
        logMessage.Add("File is already opened by another process! \nIt cannot be used.");
        return null;
        //throw new IOException("File is already opened by another process! \nIt cannot be used for load.");
      }
    }

    public static ExcelPackage CreateExcelPackage(ExcelPackage excelPackage)
    {
      excelPackage.Workbook.Properties.Author = "János Szomor";
      excelPackage.Workbook.Properties.Title = "Industrial Item Manager template";
      excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
      excelPackage.Workbook.Properties.Created = DateTime.Now;

      return excelPackage;
    }
  }
}
