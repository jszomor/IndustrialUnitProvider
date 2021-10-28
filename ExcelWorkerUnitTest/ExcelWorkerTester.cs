using FluentAssertions;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExcelWorkerUnitTest
{
  public class ExcelWorkerTester
  {
    [Fact]
    public void EquipmentValuesShouldBeLikeInTheExcel()
    {
      //var mapper = new UnitMapper();
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
  }
}