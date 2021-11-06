using FluentAssertions;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnitProvider;
using System.Collections.Generic;
using NUnit.Framework;

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

      UnitMapper.AssignValue(equipments, sheet, messages);

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

      UnitMapper.AssignValue(valves, sheet, messages);

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
  }
}
