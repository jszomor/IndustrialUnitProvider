using FluentAssertions;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnitProvider;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.Reflection;

namespace ExcelWorkerUnitTest
{
  public class ExcelWorkerTester
  {
    [Test]
    public void EquipmentValuesShouldBeLikeInTheExcel()
    {
      List<Equipment> equipments = new List<Equipment>();
      List<string> messages = new();
      string file = "3Rows.xlsx";
      string sheetName = "Equipment";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName, messages);

      IUnitMapper unitMapper = new UnitMapper();

      unitMapper.AssignValue(equipments, sheet, messages);

      var expected = new List<Equipment>()
      {
        new Equipment
        {
          Id = 1,
          ItemType = "Blower",
          Capacity = 25.5m,
          Pressure = 650m,
          PowerConsumption = 55m,
          Manufacturer = "Kubicek",
          Model = "80B",
          UnitPrice = 35000m
        },
        new Equipment
        {
          Id = 2,
          ItemType = "Blower",
          Capacity = 30m,
          Pressure = 600m,
          PowerConsumption = 60m,
          Manufacturer = "Kubicek",
          Model = "85B",
          UnitPrice = 40000m
        }
      };

      equipments.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ValveValuesShouldBeLikeInTheExcel()
    {
      List<Valve> valves = new List<Valve>();
      List<string> messages = new();
      string file = "3Rows.xlsx";
      string sheetName = "Valve";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), sheetName, messages);

      IUnitMapper unitMapper = new UnitMapper();
      unitMapper.AssignValue(valves, sheet, messages);

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
          Manufacturer = "MVV 5,21",
          UnitPrice = 13m
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
          UnitPrice = 114m
        }
      };

      valves.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ConvertTypesFromExcel_ShouldTrowFormatException()
    {
      AppLogger.LogMessage = new();

      var equipments = new List<Equipment>();
      PropertyInfo[] properties = typeof(Equipment).GetProperties();

      Dictionary<string, int> columnNameToIndex = new Dictionary<string, int>()
      {
        { "Id", 1 },
        { "ItemType", 2 },
        { "Capacity", 3 },
        { "Pressure", 4 },
        { "PowerConsumption", 5 },
        { "Manufacturer", 6 },
        { "Model", 7 },
        { "UnitPrice", 8 }
      };

      string file = "InvalidFormat.xlsx";

      var sheet = ExcelWorker.ReadExcel(PathHelper.TestPath(file), ValidSheetNames.Equipment.ToString(), AppLogger.LogMessage);

      IUnitMapper unitMapper = new UnitMapper();

      int rowNumber = 2;

      Assert.Throws<FormatException>(() => unitMapper.ConvertTypesFromExcel<Equipment>(columnNameToIndex, properties, sheet, rowNumber, AppLogger.LogMessage));
    }
  }
}
