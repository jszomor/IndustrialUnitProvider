using IndustrialUnitDatabase;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IndustrialUnit.WpfUI.Models
{
  public class FileRepository
  {
    private static List<string> LogMessage;

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

    internal static List<string> LoadIntoDB(string path)
    {
      LogMessage = new();
      if (path == null)
      {
        LogMessage.Add("No file selected.");
        return LogMessage;
      }
      else
      {
        var mapper = new UnitMapper();
        mapper.LoadUnitsFromSheet(path, ref LogMessage);
        return LogMessage;
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
      SQLiteDataAccess.CreateDatabase(ref LogMessage);
      return LogMessage;
    }

    internal static List<string> WipeDatabaseModel()
    {
      LogMessage = new();

      MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to wipe out the whole database! \nData will not be recoverable.", 
        "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

      if (messageBoxResult == MessageBoxResult.Yes)
      {
        SQLiteDataAccess.WipeDatabase(ref LogMessage);
        return LogMessage;
      }
      else
      {
        LogMessage.Add("Delete process cancelled.");
        return LogMessage;
      }
    }
  }
}
