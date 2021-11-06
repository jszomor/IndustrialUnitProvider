using IndustrialUnit.Model.Model;
using IndustrialUnitDatabase;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace IndustrialUnit.WpfUI.Models
{
  public class FileRepository
  {
    internal static (string, string) OpenFile()
    {
      OpenFileDialog openFileDialog = new();
      //openFileDialog.InitialDirectory = "c:\\";
      openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls";
      openFileDialog.FilterIndex = 1;
      openFileDialog.RestoreDirectory = true;

      if (openFileDialog.ShowDialog() == true)
      {
        return (openFileDialog.SafeFileName, openFileDialog.FileName);
      }
      else
        return (null, null);
    }

    internal static void LoadIntoDB(string path)
    {
      AppLogger.LogMessage = new();
      if (path == null)
      {
        AppLogger.LogMessage.Add("No file selected.");
      }
      else
      {
        List<Equipment> equipments = UnitMapper.LoadFromSheet<Equipment>(path, ValidSheetNames.Equipment.ToString(), AppLogger.LogMessage);
        if (equipments != null)
        {
          SQLiteDataAccess.AddCollection(equipments, ValidSheetNames.Equipment.ToString());
        }

        List<Valve> valves = UnitMapper.LoadFromSheet<Valve>(path, ValidSheetNames.Valve.ToString(), AppLogger.LogMessage);
        if(valves != null)
        {
          SQLiteDataAccess.AddCollection(valves, ValidSheetNames.Valve.ToString());
        }

        List<Instrument> instruments = UnitMapper.LoadFromSheet<Instrument>(path, ValidSheetNames.Instrument.ToString(), AppLogger.LogMessage);
        if(instruments != null)
        {
          SQLiteDataAccess.AddCollection(instruments, ValidSheetNames.Instrument.ToString());
        }

        AppLogger.LogMessage.Add("\nDatabase updates is completed.");
      }
    }

    internal static void SaveFile()
    {
      var excelPackage = DataToExcel.CopyDBtoExcel();
      SaveFileDialog saveFileDialog = new();
      saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == true)
      {
        FileInfo fi = new FileInfo(saveFileDialog.FileName);
        excelPackage.SaveAs(fi);
      }
    }

    internal static void DownLoadTemplateFile()
    {
      var excelPackage = DataToExcel.CreateEmptyTemplate();
      SaveFileDialog saveFileDialog = new();
      saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == true)
      {
        FileInfo fi = new FileInfo(saveFileDialog.FileName);
        excelPackage.SaveAs(fi);
      }
    }

    internal static List<string> CreateDatabaseModel()
    {
      AppLogger.LogMessage = new();
      SQLiteDataAccess.CreateDatabase(AppLogger.LogMessage);
      return AppLogger.LogMessage;
    }

    internal static List<string> WipeDatabaseModel()
    {
      AppLogger.LogMessage = new();

      MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to wipe out the whole database! \nData will not be recoverable.", 
        "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

      if (messageBoxResult == MessageBoxResult.Yes)
      {
        SQLiteDataAccess.WipeDatabase(AppLogger.LogMessage);
        return AppLogger.LogMessage;
      }
      else
      {
        AppLogger.LogMessage.Add("Wipe process cancelled.");
        return AppLogger.LogMessage;
      }
    }
  }
}
