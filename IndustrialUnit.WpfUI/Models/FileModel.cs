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
  public class FileModel
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

    internal static List<string> LoadIntoDB(string path)
    {
      List<string> logMessage = new();
      if (path == null)
      {
        logMessage.Add("No file selected.");
        return logMessage;
      }
      else
      {
        var mapper = new UnitMapper();
        mapper.LoadUnitsFromSheet(path, ref logMessage);
        return logMessage;
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
  }
}
