using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnitDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialUnit.WpfUI.Models
{
  public class InstrumentModel
  {
    private static readonly string TableName = "Instrument";

    public static ObservableCollection<Instrument> MapInstrument(string sqlCommand)
    {
      ObservableCollection<Instrument> instrumentCollection = new();
      var getFilteredItem = SQLiteDataAccess.GetDb(sqlCommand, TableName);

      var dbRowNumber = getFilteredItem.Rows.Count;

      for (int i = 0; i < dbRowNumber; i++)
      {
        var item = getFilteredItem.Rows[i];
        instrumentCollection.Add(
          new Instrument()
          {
            Id = Convert.ToInt32(item.ItemArray[0]),
            ItemType = Convert.ToString(item.ItemArray[1]),
            OperationPrinciple = Convert.ToString(item.ItemArray[2]),
            InstallationType = Convert.ToString(item.ItemArray[3]),
            MediumToMeasure = Convert.ToString(item.ItemArray[4]),
            Supplier = Convert.ToString(item.ItemArray[5]),
            Manufacturer = Convert.ToString(item.ItemArray[6]),
            UnitPrice = item.ItemArray[7],
          });
      }
      return instrumentCollection;
    }

    public static ObservableCollection<Instrument> GetAllInstruments() => MapInstrument($"SELECT * FROM {TableName}");

    public static (ObservableCollection<Instrument>, string) GetFilteredInstruments(ObservableCollection<Instrument> Instruments, string selectedItem)
    {
      if (String.IsNullOrWhiteSpace(selectedItem))
        return (Instruments, "Filter key is 'Item Name', \nit cannot be empty for searching!");

      string sqlCommand = $"SELECT * FROM {TableName} where ItemType='{selectedItem}'";

      return (MapInstrument(sqlCommand),
        $"Filter name: {selectedItem} \nPress Refresh to see the whole database again.");
    }

    public static string SubmitAdd(Instrument item)
    {
      if (!IsTextBoxEmpty(item) || item == null)
        return "No empty cell is allowed.";

      string sqlCommand = $"insert into {TableName} (ItemType, OperationPrinciple, InstallationType, MediumToMeasure, Supplier, Manufacturer, UnitPrice) " +
                "values (@ItemType, @OperationPrinciple, @InstallationType, @MediumToMeasure, @Supplier, @Manufacturer, @UnitPrice)";

      try
      {
        SQLiteDataAccess.ActOnItem(item, sqlCommand);

        return "You have successfully added. \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitUpdate(Instrument Instrument)
    {
      if (!IsTextBoxEmpty(Instrument) || Instrument == null)
        return "No empty cell is allowed.";

      string sqlCommand = "update Instrument set ItemType=@ItemType, OperationPrinciple=@OperationPrinciple, InstallationType=@InstallationType, MediumToMeasure=@MediumToMeasure, " +
                  "Supplier=@Supplier, Manufacturer=@Manufacturer, UnitPrice=@UnitPrice where id=";

      try
      {
        SQLiteDataAccess.ActOnItem(Instrument, sqlCommand + Instrument.Id);
        return $"Id number: {Instrument.Id} successfully updated \nPress refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database file not found!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static string SubmitDelete(Instrument Instrument)
    {
      if (Instrument.Id <= 0 || Instrument == null || Instrument.Id == null)
        return "Please select an item to delete.";

      string sqlCommand = $"delete from {TableName} where id={Instrument.Id}";

      try
      {
        SQLiteDataAccess.Delete(sqlCommand);
        return $"Id number: {Instrument.Id} successfully deleted. \nPress Refresh to see the result.";
      }
      catch (FileNotFoundException message)
      {
        Debug.WriteLine("Database access failed!");
        throw new FileNotFoundException($"{message}");
      }
    }

    public static bool IsTextBoxEmpty(Instrument ins)
    {
      if (
          ins.Id == null ||
          string.IsNullOrEmpty(ins.ItemType) ||
          string.IsNullOrEmpty(ins.OperationPrinciple) ||
          string.IsNullOrEmpty(ins.InstallationType) ||
          string.IsNullOrEmpty(ins.MediumToMeasure) ||
          string.IsNullOrEmpty(ins.Supplier) ||
          string.IsNullOrEmpty(ins.Manufacturer) ||
          ins.UnitPrice == null)
      {
        return false;
      }
      return true;
    }
  }
}
