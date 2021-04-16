using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitMapper
  {
    public Items LoadUnitsFromSheet(Items items, string fileName)
    {
      var sheetEquipment = Helper.ReadExcel(Helper.ProjectPath, fileName, RequiredSheetNames.Equipment.ToString());
      AssignValue(items.Equipments, sheetEquipment);

      var sheetValve = Helper.ReadExcel(Helper.ProjectPath, fileName, RequiredSheetNames.Valve.ToString());
      AssignValue(items.Valves, sheetValve);

      var sheetInstruments = Helper.ReadExcel(Helper.ProjectPath, fileName, RequiredSheetNames.Instrument.ToString());
      AssignValue(items.Instruments, sheetInstruments);

      return items;
    }

    public List<T> AssignValue<T>(List<T> parameterCollection, ExcelWorksheet sheet) where T : class, new()
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
          parameterCollection.Add(unit);
        }
      }

      if (parameterCollection.Count < 1)
      {
        throw new InvalidOperationException("Source file is empty");
      }
      return parameterCollection;
    }
  }
}
