using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public interface IUnitMapper
  {
    public List<T> AssignValue<T>(List<T> units, ExcelWorksheet sheet, List<string> logMessage) where T : class, new();
    public void LoadFromSheet<T>(string path, string sheetName, List<string> logMessage) where T : class, new();
    public Type ConvertToString(PropertyInfo item);
    public T ConvertTypesFromExcel<T>(Dictionary<string, int> columnNameToIndex, PropertyInfo[] properties, ExcelWorksheet sheet, int rowIndex, List<string> logMessage) where T : new();
    public string ReplaceDot(string cellText);
    public List<T> UnitResult<T>(List<T> units, string sheetName, List<string> logMessage);
  }
}