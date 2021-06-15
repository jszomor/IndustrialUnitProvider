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
    public void LoadUnitsFromSheet(string file, ref List<string> logMessage)
    {
      List<Equipment> equipments = new List<Equipment>();
      var sheetEquipment = ExcelWorker.ReadExcel(file, ValidSheetNames.Equipment.ToString(), ref logMessage);
      if(sheetEquipment != null)
      AssignValue(equipments, sheetEquipment, ref logMessage);

      List<Valve> valves = new List<Valve>();
      var sheetValve = ExcelWorker.ReadExcel(file, ValidSheetNames.Valve.ToString(), ref logMessage);
      if(sheetValve != null)
      AssignValue(valves, sheetValve, ref logMessage);

      List<Instrument> instruments = new List<Instrument>();
      var sheetInstruments = ExcelWorker.ReadExcel(file, ValidSheetNames.Instrument.ToString(), ref logMessage);
      if(sheetInstruments != null)
      AssignValue(instruments, sheetInstruments, ref logMessage);
    }

    public void AssignValue<T>(List<T> parameterCollection, ExcelWorksheet sheet, ref List<string> logMessage) where T : class, new()
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
                    
          parameterCollection.Add(unit);
        }
        else
        {
          logMessage.Add($"Item name not found. Sheet name:[{sheet.Name}] | Cell address:[{sheet.Cells[rowIndex, 1].Address}] | Row is not added.");
        }

        SkipRow:;
      }

      if (parameterCollection.Count < 1)
      {
        logMessage.Add($"[{sheet.Name}] sheet is empty.");
      }
      else
      {
        SQLiteDataAccess.AddCollection(parameterCollection, sheet.Name);
        logMessage.Add($"[{sheet.Name}] sheet is loaded into the database.");
      }
    }
  }
}
