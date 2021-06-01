using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitSave
  {
    public static ExcelPackage IndustrialExcelPackage { get; set; }
    public static ExcelPackage CreateTemplateFile()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      IndustrialExcelPackage = new ExcelPackage();
      ExcelWorker.CreateExcelPackage(IndustrialExcelPackage);

      CreateTemplateColumns<Equipment>(IndustrialExcelPackage, ValidSheetNames.Equipment.ToString());
      CreateTemplateColumns<Valve>(IndustrialExcelPackage, ValidSheetNames.Valve.ToString());
      CreateTemplateColumns<Instrument>(IndustrialExcelPackage, ValidSheetNames.Instrument.ToString());

      return IndustrialExcelPackage;
    }

    public static ExcelPackage CopyDBtoExcel()
    {
      AssignDBTableToSheet(ValidSheetNames.Equipment.ToString());
      AssignDBTableToSheet(ValidSheetNames.Valve.ToString());
      AssignDBTableToSheet(ValidSheetNames.Instrument.ToString());

      return IndustrialExcelPackage;
    }

    public static ExcelPackage CreateTemplateColumns<T>(ExcelPackage excelPackage, string tableName)
    {
      ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add(tableName);

      PropertyInfo[] properties = typeof(T).GetProperties();

      int columnIndex = 1;

      foreach (var item in properties)
      {
        sheet.Cells[1, columnIndex].Value = item.Name;
        columnIndex++;
      }

      return excelPackage;
    }

    public static ExcelPackage AssignDBTableToSheet(string tableName)
    {
      string sqlCommand = $"SELECT * FROM {tableName}";

      var getItems = SQLiteDataAccess.GetDb(sqlCommand, tableName);
      var dbRowNumber = getItems.Rows.Count;
      var dbColumnNumber = getItems.Columns.Count;

      if (dbRowNumber == 0)
        return null;

      ExcelWorksheet sheet = IndustrialExcelPackage.Workbook.Worksheets[tableName];

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = getItems.Rows[i];

        for (int j = 0; j < dbColumnNumber; j++)
        {
          sheet.Cells[i+2, j+1].Value = item.ItemArray[j];
        }
      }

      return IndustrialExcelPackage;
    }
  }
}
