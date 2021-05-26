using IndustrialUnit.Model;
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
    public void LoadUnitsFromSheet(string fileName)
    {
      List<Equipment> equipments = new List<Equipment>();
      var sheetEquipment = ExcelWorker.ReadExcel(PathHelper.ProjectPath, fileName, RequiredSheetNames.Equipment.ToString());
      AssignValue(equipments, sheetEquipment);

      List<Valve> valves = new List<Valve>();
      var sheetValve = ExcelWorker.ReadExcel(PathHelper.ProjectPath, fileName, RequiredSheetNames.Valve.ToString());
      AssignValue(valves, sheetValve);

      List<Instrument> instruments = new List<Instrument>();
      var sheetInstruments = ExcelWorker.ReadExcel(PathHelper.ProjectPath, fileName, RequiredSheetNames.Instrument.ToString());
      AssignValue(instruments, sheetInstruments);
    }

    public void AssignValue<T>(List<T> parameterCollection, ExcelWorksheet sheet) where T : class, new()
    {
      PropertyInfo[] properties = typeof(T).GetProperties();

      var validation = new Validation();
      var columnNameToIndex = validation.CollectColumnNamesFromExcel(sheet);
      try
      {
        validation.ValidateColumnNames(columnNameToIndex, properties);
      }
      catch (MissingColumnException)
      {
        throw new MissingColumnException($"Missing or incorrect column names in the source excel file. Check that!");
      }

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
              try
              {
                item.SetValue(unit, Convert.ChangeType(sheet.Cells[rowIndex, value].Text, item.PropertyType));
              }
              catch (FormatException)
              {
                throw new FormatException($"The value of the following cell [{sheet.Cells[rowIndex, value].Address}] in the source file cannot converted into [{item.PropertyType}] type.");
              }
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
        throw new InvalidOperationException("Source file is empty");
      }

      var itemToJsonSerializer = new ItemsToJsonSerializer();
      itemToJsonSerializer.BuildJson(parameterCollection, sheet.Name);
    }
  }
}
