using IndustrialUnit.Model;
using IndustrialUnit.WpfUI.Models;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class FileViewModel
  {
    public ICommand LoadFileDialogBox { get; }

    private void OpenFile_Click()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == true)
      {
        var mapper = new UnitMapper();

        try
        {
          mapper.LoadUnitsFromSheet(openFileDialog.FileName);
        }
        catch (Exception e)
        {
          Debug.WriteLine(e);
          throw;
        }
      }
    }

    public FileViewModel()
    {
      LoadFileDialogBox = new RelayCommand(OpenFile_Click);
    }
  }
}
