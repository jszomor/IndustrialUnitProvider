using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
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
using System.Windows;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class FileViewModel : BaseViewModel
  {
    private List<string> _logMessage;

    public List<string> LogMessage
    {
      get
      {
        return _logMessage;
      }
      set
      {
        _logMessage = value;
        OnPropertyChanged();
      }
    }

    private string _selectedFile;
    public string SelectedFile
    {
      get
      {
        return _selectedFile;
      }
      set
      {
        _selectedFile = value;
        OnPropertyChanged();
      }
    }

    public string Path { get; set; }

    public ICommand SelectFileDialogBox { get; }
    public ICommand LoadFile { get; }

    private void OpenFile()
    {
      OpenFileDialog openFileDialog = new();
      if (openFileDialog.ShowDialog() == true)
      {
        SelectedFile = openFileDialog.SafeFileName;
        Path = openFileDialog.FileName;
      }
    }

    private void LoadIntoDB()
    {
      List<string> logMessage = new();
      if (Path == null)
        MessageBox.Show("No file selected.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
      else
      {
        var mapper = new UnitMapper();
        mapper.LoadUnitsFromSheet(Path, ref logMessage);
        LogMessage = logMessage;
      }
    }

    public FileViewModel()
    {
      SelectFileDialogBox = new RelayCommand(OpenFile);
      LoadFile = new RelayCommand(LoadIntoDB);
    }
  }
}
