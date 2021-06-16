using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using FluentAssertions;
using System;
using System.IO;
using Xunit;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Linq;
using System.Collections;
using IndustrialUnitProvider;

namespace IndustrialUnitTest
{
  public class UnitTest
  {
    [Fact]
    public void EquipmentValuesShouldBeLikeInTheExcel()
    {
      var mapper = new UnitMapper();
      List<Equipment> equipments = new List<Equipment>();
      List<string> messages = null;
      string file = "3Rows.xlsx";
      string sheetName = "Equipment";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName, messages);

      mapper.AssignValue(equipments, sheet, messages);

      var expected = new List<Equipment>()
      {
        new Equipment
        {
          Id = 1,
          ItemType = "Blower",
          Capacity = 25,
          Pressure = 650,
          PowerConsumption = 55,
          Manufacturer = "Kubicek",
          Model = "80B",
          UnitPrice = 35000
        },
        new Equipment
        {
          Id = 2,
          ItemType = "Blower",
          Capacity = 30,
          Pressure = 600,
          PowerConsumption = 60,
          Manufacturer = "Kubicek",
          Model = "85B",
          UnitPrice = 40000
        }
      };

      equipments.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ValveValuesShouldBeLikeInTheExcel()
    {
      var mapper = new UnitMapper();
      List<Valve> valves = new List<Valve>();
      List<string> messages = null;
      string file = "3Rows.xlsx";
      string sheetName = "Valve";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName, messages);

      mapper.AssignValue(valves, sheet, messages);

      var expected = new List<Valve>()
      {
        new Valve
        {
          Id = 1,
          ItemType = "Butterfly valve",
          Operation = "Manual",
          Size = 50,
          ConnectionType = "Wafer",
          Supplier = "MVV",
          Manufacturer = "MVV 5.21",
          UnitPrice = 13
        },
        new Valve
        {
          Id = 2,
          ItemType = "Butterfly valve",
          Operation = "Manual",
          Size = 65,
          ConnectionType = "Wafer",
          Supplier = "MVV",
          Manufacturer = "VAG cerex",
          UnitPrice = 114
        }
      };

      valves.Should().BeEquivalentTo(expected);
    }

    //[Fact]
    //public void ShouldThrowInvalidOperationExceptionInCaseOfEmptyEquipmentSheet()
    //{
    //  var mapper = new UnitMapper();
    //  List<Equipment> equipments = new List<Equipment>();

    //  string file = "NoData.xlsx";
    //  string sheetName = "Equipment";

    //  var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName);

    //  Assert.Throws<InvalidOperationException>(() => mapper.AssignValue(equipments, sheet));
    //}

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
