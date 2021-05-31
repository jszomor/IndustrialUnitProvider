﻿using IndustrialUnit.Model;
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
    private string _logMessage;

    public string LogMessage
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

    public ICommand SelectFileDialogBox { get; }
    public ICommand LoadFile { get; }

    private void OpenFile()
    {
      OpenFileDialog openFileDialog = new();
      if (openFileDialog.ShowDialog() == true)
      {
        SelectedFile = openFileDialog.FileName;
      }
    }

    private void LoadIntoDB()
    {
      string logMessage = null;
      if (SelectedFile == null)
        MessageBox.Show("No file selected.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
      else
      {
        var mapper = new UnitMapper();
        mapper.LoadUnitsFromSheet(SelectedFile, ref logMessage);
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
