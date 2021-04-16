using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class Validation
  {
    public void ValidateColumnNames(Dictionary<string, int> actualColumnNames, PropertyInfo[] properties)
    {
      IEnumerable<string> validColumnNames = from item in properties select item.Name;

      var missingColumnNames = validColumnNames.Where(x => !actualColumnNames.ContainsKey(x));

      if (missingColumnNames.Count() > 1)
      {
        throw new MissingColumnException($"{missingColumnNames} contains the missing or incorrect column names from the source excel file. Check that!");
      }
    }

    public Dictionary<string, int> CollectColumnNamesFromExcel(ExcelWorksheet sheet)
    {
      var columnNameToIndex = new Dictionary<string, int>();
      for (int columnIndex = 1; columnIndex < sheet.Dimension.Columns + 1; columnIndex++)
      {
        columnNameToIndex.Add(sheet.Cells[1, columnIndex].Text, columnIndex);
      }
      return columnNameToIndex;
    }
  }
}
