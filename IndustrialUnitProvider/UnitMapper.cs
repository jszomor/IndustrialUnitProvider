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
    public void LoadUnitsFromSheet(string file, List<string> logMessage)
    {
      List<Equipment> equipments = new();
      var sheetEquipment = ExcelWorker.ReadExcel(file, ValidSheetNames.Equipment.ToString(), logMessage);
      if(sheetEquipment != null)
      AssignValue(equipments, sheetEquipment, logMessage);

      List<Valve> valves = new();
      var sheetValve = ExcelWorker.ReadExcel(file, ValidSheetNames.Valve.ToString(), logMessage);
      if(sheetValve != null)
      AssignValue(valves, sheetValve, logMessage);

      List<Instrument> instruments = new();
      var sheetInstruments = ExcelWorker.ReadExcel(file, ValidSheetNames.Instrument.ToString(), logMessage);
      if(sheetInstruments != null)
      AssignValue(instruments, sheetInstruments, logMessage);

      logMessage.Add("\nDatabase updates is completed.");
    }

    public void AssignValue<T>(List<T> units, ExcelWorksheet sheet, List<string> logMessage) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new ExcelValidation();
      var columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);

      if (!validation.ValidateColumnNames(columnNameToIndex, properties, sheet, ref logMessage))  return;

      for (int rowIndex = 2; rowIndex < sheet.Dimension.Rows + 1; rowIndex++)
      {
        if (!string.IsNullOrEmpty(sheet.Cells[rowIndex, 2].Text)) //if an ItemType cell is empty in the source excel file item won't be added
        {
          T unit = new T();
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
