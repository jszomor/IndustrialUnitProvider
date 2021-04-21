using IndustrialUnitDatabase.Model;
using IndustrialUnitProvider;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace IndustrialUnitDatabase
{
  class MainDB
  {
    static void Main()
    {
      string cs = @"URI=file:C:\Users\jszom\source\repos\IndustrialUnitProvider\IndustrialUnitDatabase\IndustrialUnitDB.db";

      

      var equipment = new Equipment
      {
        Id = 1,
        ItemType = "Blower",
        Capacity = 25,
        Pressure = 650,
        PowerConsumption = 55,
        Manufacturer = "Kubicek",
        Model = "80B",
        UnitPrice = 35000
      };

      //SQLiteDataAccess.InsertEquipment(equipment);


      SQLiteDataAccess.LoadPeople();
    }
  }
}
