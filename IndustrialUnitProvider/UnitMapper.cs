using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitMapper
  {
    public static void LoadFromSheet<T>(string path, string sheetName, List<string> logMessage) where T : class, new()
    {
      List<T> list = new();
      var sheet = ExcelWorker.ReadExcel(path, sheetName, logMessage);
      if(sheet != null)
        AssignValue(list, sheet, logMessage);
    }

    public static void AssignValue<T>(List<T> units, ExcelWorksheet sheet, List<string> logMessage) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new ExcelValidation();
      var columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);

      if (!validation.ValidateColumnNames(columnNameToIndex, properties, sheet, ref logMessage))  return;

      for (int rowIndex = 2; rowIndex < sheet.Dimension.Rows + 1; rowIndex++)
      {
        if (!string.IsNullOrEmpty(sheet.Cells[rowIndex, 2].Text)) //if an ItemType cell is empty in the source excel file item won't be added
        {
          T unit = new();
          foreach (var item in properties)
          {
            if (columnNameToIndex.TryGetValue(item.Name, out int value) && item.Name != "Id")
            {
              Type typeToConvert;
              string cellText = sheet.Cells[rowIndex, value].Text;
              try
              {
                if(item.PropertyType.FullName == "System.String")
                {
                  typeToConvert = item.PropertyType;
                }
                else
                {
                  typeToConvert = item.PropertyType.GenericTypeArguments[0];
                }

                if(cellText.Contains("."))
                {
                  cellText = cellText.Replace(".", ",");
                }

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
        }

        SkipRow:;
      }

      if (units.Count < 1)
      {
        logMessage.Add($"[{sheet.Name}] sheet is empty.");
      }
      else
      {
        SQLiteDataAccess.AddCollection(units, sheet.Name);
        logMessage.Add($"[{sheet.Name}] sheet is loaded into the database.");
      }
    }
  }
}
