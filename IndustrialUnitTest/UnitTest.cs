using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using IndustrialUnitProvider;

namespace IndustrialUnitTest
{
  public class UnitTest
  {

    [Fact]
    public void LogMessageShouldContainInvalidFormatMessage()
    {
      var testLogMessage = new List<string>();

      var equipments = new List<Equipment>();

      string file = "InvalidFormat.xlsx";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), ValidSheetNames.Equipment.ToString(), testLogMessage);

      testLogMessage.Add($"Invalid parameter found. Sheet name:[{sheet.Name}] |" +
        $" Cell address:[{sheet.Cells[2, 3].Address}] | Row is not added.");

      UnitMapper.AssignValue(equipments, sheet, testLogMessage);

      Assert.Equal(testLogMessage, AppLogger.LogMessage);
    }

    //[Fact]
    //public void ShouldThrowInvalidOperationExceptionInCaseOfEmptyValveSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Valve> valves = new List<Valve>();

    //  string file = "NoData.xlsx";
    //  string sheetName = "Valve";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<InvalidOperationException>(() => mapper.AssignValue(valves, sheet));
    //}

    //[Fact]
    //public void ShouldThrowKeyNotFoundExceptionInCaseOfMissingColumnInEquipmentSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Equipment> equipments = new List<Equipment>();

    //  string file = "MissingColumn.xlsx";
    //  string sheetName = "Equipment";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<MissingColumnException>(() => mapper.AssignValue(equipments, sheet));
    //}

    //[Fact]
    //public void ShouldThrowKeyNotFoundExceptionInCaseOfMissingColumnInValveSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Valve> valves = new List<Valve>();

    //  string file = "MissingColumn.xlsx";
    //  string sheetName = "Valve";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<MissingColumnException>(() => mapper.AssignValue(valves, sheet));
    //}

    //[Fact]
    //public void ShouldThrowFormatExceptionInCaseOfInvalidFormatInEquipmentSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Equipment> equipments = new List<Equipment>();

    //  string file = "InvalidFormat.xlsx";
    //  string sheetName = "Equipment";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<FormatException>(() => mapper.AssignValue(equipments, sheet));
    //}

    //[Fact]
    //public void ShouldThrowFormatExceptionInCaseOfInvalidFormatInValveSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Valve> valves = new List<Valve>();

    //  string file = "InvalidFormat.xlsx";
    //  string sheetName = "Valve";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<FormatException>(() => mapper.AssignValue(valves, sheet));
    //}

    //[Fact]
    //public void ShouldThrowInvalidOperationExceptionInCaseOfInvalidEquipmentSheetName()
    //{
    //  string file = "InvalidSheetName.xlsx";
    //  string sheetName = "Equipment";

    //  Assert.Throws<InvalidOperationException>(() => ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName));
    //}

    //[Fact]
    //public void ShouldThrowInvalidOperationExceptionInCaseOfInvalidValveSheetName()
    //{
    //  string file = "InvalidSheetName.xlsx";
    //  string sheetName = "Valve";

    //  Assert.Throws<InvalidOperationException>(() => ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName));
    //}
  }
}
