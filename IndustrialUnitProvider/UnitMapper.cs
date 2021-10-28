using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitMapper
  {
    public static List<T> LoadFromSheet<T>(string path, string sheetName, List<string> logMessage) where T : class, new()
    {
      List<T> units = new();
      var sheet = ExcelWorker.ReadExcel(path, sheetName, logMessage);
      if (sheet != null)
      return AssignValue(units, sheet, logMessage);
      else
        return null;
    }

    public static List<T> AssignValue<T>(List<T> units, ExcelWorksheet sheet, List<string> logMessage) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new ExcelValidation();
      var columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);

      if (!validation.ValidateColumnNames(columnNameToIndex, properties, sheet, ref logMessage)) return null;

      for (int rowIndex = 2; rowIndex < sheet.Dimension.Rows + 1; rowIndex++)
      {
        if (!string.IsNullOrEmpty(sheet.Cells[rowIndex, 2].Text)) //if an ItemType cell is empty in the source excel file item won't be added
        {
          T unit = new();
          foreach (var item in properties)
          {
            if (columnNameToIndex.TryGetValue(item.Name, out int value))
            {
              Type typeToConvert;
              string cellText = sheet.Cells[rowIndex, value].Text;

              if (item.PropertyType.FullName == "System.String")
              {
                typeToConvert = item.PropertyType;
              }
              else
              {
                typeToConvert = item.PropertyType.GenericTypeArguments[0];
              }

              if (cellText.Contains("."))
              {
                cellText = cellText.Replace(".", ",");
              }

              try
              {
                var convertedItem = Convert.ChangeType(cellText, typeToConvert);
                item.SetValue(unit, convertedItem);
              }
              catch
              {
                logMessage.Add($"Invalid parameter found. Sheet name:[{sheet.Name}] | Cell address:[{sheet.Cells[rowIndex, value].Address}] | Row is not added.");
                goto SkipRow;
              }
            }
          }

          units.Add(unit);
        }
        else
        {
          logMessage.Add($"Item name not found. Sheet name:[{sheet.Name}] | Cell address:[{sheet.Cells[rowIndex, 1].Address}] | Row is not added.");
          return null;
        }

      SkipRow:;
      }

      if (units.Count < 1)
      {
        logMessage.Add($"[{sheet.Name}] sheet is empty.");
        return null;
      }
      else
      {
        //SQLiteDataAccess.AddCollection(units, sheet.Name);
        logMessage.Add($"[{sheet.Name}] sheet is loaded into the database.");
        return units;
      }
    }
  }
}
