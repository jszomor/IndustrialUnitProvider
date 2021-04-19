using IndustrialUnitProvider;
using FluentAssertions;
using System;
using System.IO;
using Xunit;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Linq;
using System.Collections;

namespace IndustrialUnitTest
{
  public class UnitTest
  {
    [Fact]
    public void EquipmentValuesShouldBeLikeInTheExcel()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "3Rows.xlsx";
      string sheetName = "Equipment";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      mapper.AssignValue(items.Equipments, sheet);

      var expected = new List<EquipmentView>()
      {
        new EquipmentView
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
        new EquipmentView
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

      items.Equipments.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ValveValuesShouldBeLikeInTheExcel()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "3Rows.xlsx";
      string sheetName = "Valve";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      mapper.AssignValue(items.Valves, sheet);

      var expected = new List<ValveView>()
      {
        new ValveView
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
        new ValveView
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

      items.Valves.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionInCaseOfEmptyEquipmentSheet()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "NoData.xlsx";
      string sheetName = "Equipment";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<InvalidOperationException>(() => mapper.AssignValue(items.Equipments, sheet));
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionInCaseOfEmptyValveSheet()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "NoData.xlsx";
      string sheetName = "Valve";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<InvalidOperationException>(() => mapper.AssignValue(items.Valves, sheet));
    }

    [Fact]
    public void ShouldThrowKeyNotFoundExceptionInCaseOfMissingColumnInEquipmentSheet()
    {
      var mapper = new UnitMapper();
      var testItem = new ItemsView();

      string file = "MissingColumn.xlsx";
      string sheetName = "Equipment";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<MissingColumnException>(() => mapper.AssignValue(testItem.Equipments, sheet));
    }

    [Fact]
    public void ShouldThrowKeyNotFoundExceptionInCaseOfMissingColumnInValveSheet()
    {
      var mapper = new UnitMapper();
      var testItem = new ItemsView();

      string file = "MissingColumn.xlsx";
      string sheetName = "Valve";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<MissingColumnException>(() => mapper.AssignValue(testItem.Valves, sheet));
    }

    [Fact]
    public void ShouldThrowFormatExceptionInCaseOfInvalidFormatInEquipmentSheet()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "InvalidFormat.xlsx";
      string sheetName = "Equipment";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<FormatException>(() => mapper.AssignValue(items.Equipments, sheet));
    }

    [Fact]
    public void ShouldThrowFormatExceptionInCaseOfInvalidFormatInValveSheet()
    {
      var mapper = new UnitMapper();
      var items = new ItemsView();

      string file = "InvalidFormat.xlsx";
      string sheetName = "Valve";

      var sheet = Helper.ReadExcel(Helper.TestPath, file, sheetName);

      Assert.Throws<FormatException>(() => mapper.AssignValue(items.Valves, sheet));
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionInCaseOfInvalidEquipmentSheetName()
    {
      string file = "InvalidSheetName.xlsx";
      string sheetName = "Equipment";

      Assert.Throws<InvalidOperationException>(() => Helper.ReadExcel(Helper.TestPath, file, sheetName));
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionInCaseOfInvalidValveSheetName()
    {
      string file = "InvalidSheetName.xlsx";
      string sheetName = "Valve";

      Assert.Throws<InvalidOperationException>(() => Helper.ReadExcel(Helper.TestPath, file, sheetName));
    }
  }
}
