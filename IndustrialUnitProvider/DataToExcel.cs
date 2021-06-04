using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace IndustrialUnitProvider
{
  public class DataToExcel
  {

    public static ExcelPackage IndustrialExcelPackage { get; set; }

    public static async Task<ExcelPackage> CreateEmptyTemplate()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      IndustrialExcelPackage = new ExcelPackage();
      ExcelWorker.SetupExcelPackage(IndustrialExcelPackage);

      List<Task> tasks = new List<Task>
      {
        Task.Run(() => CreateExcelSheet<Equipment>(ValidSheetNames.Equipment.ToString())),
        Task.Run(() => CreateExcelSheet<Instrument>(ValidSheetNames.Instrument.ToString())),
        Task.Run(() => CreateExcelSheet<Valve>(ValidSheetNames.Valve.ToString()))
      };

      await Task.WhenAll(tasks);

      return IndustrialExcelPackage;
    }

    public static async Task<ExcelPackage> AddDatabaseDataToExcel()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      IndustrialExcelPackage = new ExcelPackage();
      ExcelWorker.SetupExcelPackage(IndustrialExcelPackage);

      List<Task> tasks = new List<Task>
      {
        Task.Run(() => AssignDatabaseTableDataToExcelSheet<Equipment>(ValidSheetNames.Equipment.ToString())),
        Task.Run(() => AssignDatabaseTableDataToExcelSheet<Valve>(ValidSheetNames.Valve.ToString())),
        Task.Run(() => AssignDatabaseTableDataToExcelSheet<Instrument>(ValidSheetNames.Instrument.ToString()))
      };

      await Task.WhenAll(tasks);

      return IndustrialExcelPackage;
    }

    public static ExcelPackage CreateExcelSheet<T>(string tableName)
    {
      ExcelWorksheet sheet = IndustrialExcelPackage.Workbook.Worksheets.Add(tableName);

      PropertyInfo[] properties = typeof(T).GetProperties();

      int columnIndex = 1;

      foreach (var item in properties)
      {
        sheet.Cells[1, columnIndex].Value = item.Name;
        columnIndex++;
      }

      return IndustrialExcelPackage;
    }

    public static ExcelPackage AssignDatabaseTableDataToExcelSheet<T>(string tableName)
    {
      string sqlCommand = $"SELECT * FROM {tableName}";

      var getItems = SQLiteDataAccess.GetDb(sqlCommand, tableName);
      var dbRowNumber = getItems.Rows.Count;
      var dbColumnNumber = getItems.Columns.Count;

      if (dbRowNumber == 0)
        return null;
      
      ExcelWorksheet sheet = CreateExcelSheet<T>(tableName).Workbook.Worksheets[tableName];

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = getItems.Rows[i];

        for (int j = 0; j < dbColumnNumber; j++)
        {
          sheet.Cells[i+2, j+1].Value = item.ItemArray[j];
        }
      }

      return IndustrialExcelPackage;
    }
  }
}
