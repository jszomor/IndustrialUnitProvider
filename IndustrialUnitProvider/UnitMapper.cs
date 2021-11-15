using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitMapper : IUnitMapper
  {
    public void LoadFromSheet<T>(string path, string sheetName, List<string> logMessage) where T : class, new()
    {
      List<T> units = new();
      ExcelWorksheet sheet = ExcelWorker.ReadExcel(path, sheetName, logMessage);

      if (sheet != null)
      {
        units = AssignValue(units, sheet, logMessage);
        SQLiteDataAccess.AddCollection(units, sheetName);
      }
      else
      {
        logMessage.Add($"Excel sheet is null. Sheet name: {sheetName}");
      }
    }

    public List<T> AssignValue<T>(List<T> units, ExcelWorksheet sheet, List<string> logMessage) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new ExcelValidation();
      Dictionary<string, int> columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);

      if (!validation.ValidateColumnNames(columnNameToIndex, properties, sheet, logMessage)) return null;

      for (int rowIndex = 2; rowIndex < sheet.Dimension.Rows + 1; rowIndex++)
      {
        if (!string.IsNullOrEmpty(sheet.Cells[rowIndex, 2].Text)) //if an ItemType cell is empty in the source excel file row will not be added
        {
          try
          {
            units.Add(ConvertTypesFromExcel<T>(columnNameToIndex, properties, sheet, rowIndex, logMessage));
          }
          catch (FormatException)
          {
            continue;
          }
        }
        else
        {
          logMessage.Add($"Item name not found. Sheet name:[{sheet.Name}] | Cell address:[{sheet.Cells[rowIndex, 1].Address}] | Row is not added.");
          return null;
        }
      }

      return UnitResult(units, sheet.Name, logMessage);
    }

    public List<T> UnitResult<T>(List<T> units, string sheetName, List<string> logMessage)
    {
      if (units.Count < 1)
      {
        logMessage.Add($"[{sheetName}] sheet is empty.");
        return null;
      }
      else
      {
        logMessage.Add($"[{sheetName}] sheet is loaded into the database.");
        return units;
      }
    }

    public T ConvertTypesFromExcel<T>(Dictionary<string, int> columnNameToIndex, PropertyInfo[] properties, ExcelWorksheet sheet, int rowIndex, List<string> logMessage) where T : new()
    {
      T unit = new();
      foreach (var item in properties)
      {
        if (columnNameToIndex.TryGetValue(item.Name, out int value))
        {
          string cellText = sheet.Cells[rowIndex, value].Text;

          cellText = ReplaceDot(cellText);

          try
          {
            var convertedItem = Convert.ChangeType(cellText, ConvertToString(item));
            item.SetValue(unit, convertedItem);
          }
          catch (FormatException e)
          {
            string message = $"Invalid parameter found. Sheet name:[{sheet.Name}] | Cell address:[{sheet.Cells[rowIndex, value].Address}] | Row is not added.";
            logMessage.Add(message);

            throw new FormatException(message, e);
          }
        }
      }

      return unit;
    }

    public string ReplaceDot(string cellText) => cellText.Contains(".") ? cellText.Replace(".", ",") : cellText;

    public Type ConvertToString(PropertyInfo item)
    => item.PropertyType.FullName == "System.String" ? item.PropertyType : item.PropertyType.GenericTypeArguments[0];
  }
}
