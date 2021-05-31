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

    public void ValidateColumnNames(Dictionary<string, int> actualColumnNames, PropertyInfo[] properties, ExcelWorksheet sheet, ref string logMessage)
    {
      IEnumerable<string> validColumnNames = from item in properties select item.Name;

      MissingColumnNames = validColumnNames.Where(x => !actualColumnNames.ContainsKey(x));

      if (MissingColumnNames.Count() > 1)
      {
        logMessage += $"\nFrom the selected sheet: [{sheet.Name}] the following column(s) {MissingColumnNames} is missing or has incorrect name. \nPlease check the manual.";
      }
      else
      {
        logMessage += $"\nValid columns found in [{sheet.Name}] sheet.";
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
