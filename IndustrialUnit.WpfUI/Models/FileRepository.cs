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
    internal static List<string> LogMessage;

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
      LogMessage = new();
      if (path == null)
      {
        LogMessage.Add("No file selected.");
      }
      else
      {
        UnitMapper.LoadFromSheet<Equipment>(path, ValidSheetNames.Equipment.ToString(), LogMessage);
        UnitMapper.LoadFromSheet<Valve>(path, ValidSheetNames.Valve.ToString(), LogMessage);
        UnitMapper.LoadFromSheet<Instrument>(path, ValidSheetNames.Instrument.ToString(), LogMessage);
        LogMessage.Add("\nDatabase updates is completed.");
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
      LogMessage = new();
      SQLiteDataAccess.CreateDatabase(LogMessage);
      return LogMessage;
    }

    internal static List<string> WipeDatabaseModel()
    {
      LogMessage = new();

      MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to wipe out the whole database! \nData will not be recoverable.", 
        "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

      if (messageBoxResult == MessageBoxResult.Yes)
      {
        SQLiteDataAccess.WipeDatabase(LogMessage);
        return LogMessage;
      }
      else
      {
        LogMessage.Add("Wipe process cancelled.");
        return LogMessage;
      }
    }
  }
}
