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
    public void LoadUnitsFromSheet(string file, ref string logMessage)
    {
      List<Equipment> equipments = new List<Equipment>();
      var sheetEquipment = ExcelWorker.ReadExcel(file, ValidSheetNames.Equipment.ToString(), ref logMessage);
      AssignValue(equipments, sheetEquipment, ref logMessage);

      List<Valve> valves = new List<Valve>();
      var sheetValve = ExcelWorker.ReadExcel(file, ValidSheetNames.Valve.ToString(), ref logMessage);
      AssignValue(valves, sheetValve, ref logMessage);

      List<Instrument> instruments = new List<Instrument>();
      var sheetInstruments = ExcelWorker.ReadExcel(file, ValidSheetNames.Instrument.ToString(), ref logMessage);
      AssignValue(instruments, sheetInstruments, ref logMessage);
    }

    public void AssignValue<T>(List<T> parameterCollection, ExcelWorksheet sheet, ref string logMessage) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new ExcelValidation();
      var columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);

      validation.ValidateColumnNames(columnNameToIndex, properties, sheet, ref logMessage);

      int nextId = 1;

      for (int rowIndex = 2; rowIndex < sheet.Dimension.Rows + 1; rowIndex++)
      {
        if (!string.IsNullOrEmpty(sheet.Cells[rowIndex, 1].Text)) //if an ItemType cell is empty in the source excel file item won't be added
        {
          T unit = new T();
          foreach (var item in properties)
          {
            if (columnNameToIndex.TryGetValue(item.Name, out int value))
            {
              item.SetValue(unit, Convert.ChangeType(sheet.Cells[rowIndex, value].Text, item.PropertyType));
            }
            else if (item.Name == "Id")
            {
              item.SetValue(unit, nextId);
              nextId++;
            }
          }

          SQLiteDataAccess.AddCollection(unit, sheet.Name);

          parameterCollection.Add(unit);
        }
      }

      if (parameterCollection.Count < 1)
      {
        logMessage += $"\n[{sheet.Name}] type is empty.";
      }
      else
      {
        logMessage += $"\n[{sheet.Name}] type is successfuly loaded into the database.";
      }

      var itemToJsonSerializer = new ItemsToJsonSerializer();
      itemToJsonSerializer.BuildJson(parameterCollection, sheet.Name);
    }
  }
}
