using IndustrialUnit.Model.Model;
using OfficeOpenXml;
using System.Reflection;

namespace IndustrialUnitProvider
{
  public class UnitSave
  {
    public static ExcelPackage ExcelPackage { get; set; }
    public static ExcelPackage CreateTemplateFile()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      ExcelPackage = new ExcelPackage();
      ExcelWorker.CreateExcelPackage(ExcelPackage);

      CreateTemplateColumns<Equipment>(ExcelPackage, ValidSheetNames.Equipment.ToString());
      CreateTemplateColumns<Valve>(ExcelPackage, ValidSheetNames.Valve.ToString());
      CreateTemplateColumns<Instrument>(ExcelPackage, ValidSheetNames.Instrument.ToString());

      return ExcelPackage;
    }

    public ExcelPackage CopyDBtoExcel()
    {
      AssignDBTableToSheet<Equipment>(CreateTemplateFile(), ValidSheetNames.Equipment.ToString());
      AssignDBTableToSheet<Valve>(CreateTemplateFile(), ValidSheetNames.Valve.ToString());
      AssignDBTableToSheet<Instrument>(CreateTemplateFile(), ValidSheetNames.Instrument.ToString());

      return ExcelPackage;
    }

    public static ExcelPackage CreateTemplateColumns<T>(ExcelPackage excelPackage, string tableName)
    {
      ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add(tableName);

      PropertyInfo[] properties = typeof(T).GetProperties();

      int columnIndex = 1;

      foreach (var item in properties)
      {
        sheet.Cells[1, columnIndex].Value = item.Name;
        columnIndex++;
      }

      return excelPackage;
    }

    public void AssignDBTableToSheet<T>(ExcelPackage excelPackage, string tableName)
    {

    }
  }
}
