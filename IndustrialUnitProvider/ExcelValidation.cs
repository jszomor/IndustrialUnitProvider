using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IndustrialUnitProvider
{
  public class ExcelValidation
  {
    public static IEnumerable<string> MissingColumnNames { get; set; }

    public bool ValidateColumnNames(Dictionary<string, int> actualColumnNames, PropertyInfo[] properties, ExcelWorksheet sheet, ref List<string> logMessage)
    {
      IEnumerable<string> validColumnNames = from item in properties select item.Name;

      MissingColumnNames = validColumnNames.Where(x => !actualColumnNames.ContainsKey(x));

      if (MissingColumnNames.Count() > 0)
      {
        foreach (var item in MissingColumnNames)
        {
          logMessage.Add($"Invalid or missing column [{item}].");
        }
        logMessage.Add($"[{sheet.Name}] sheet is not added to the database.");
        return false;
      }
      else
      {
        logMessage.Add($"Columns check ok.");
        return true;
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
