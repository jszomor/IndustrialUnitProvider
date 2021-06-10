using IndustrialUnit.WpfUI.Models;
using IndustrialUnitDatabase;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System.Collections.Generic;
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
    public ICommand SaveFile { get; }
    public ICommand DownloadTemplate { get; }
    public ICommand CreateEmptyDatabase { get; }
    public ICommand WipeDatabase { get; }

    private void RunSelectCommand() => (SelectedFile, Path) = FileModel.OpenFile();
    private void RunLoadCommand() => LogMessage = FileModel.LoadIntoDB(Path);
    private void RunDBCreator() => LogMessage = FileModel.CreateDatabaseModel();
    private void RunWipeDB() => LogMessage = FileModel.WipeDatabaseModel();

    public FileViewModel()
    {
      SelectFileDialogBox = new RelayCommand(RunSelectCommand);
      LoadFile = new RelayCommand(RunLoadCommand);
      SaveFile = new RelayCommand(FileModel.SaveFile);
      DownloadTemplate = new RelayCommand(FileModel.DownLoadTemplateFile);
      CreateEmptyDatabase = new RelayCommand(RunDBCreator);
      WipeDatabase = new RelayCommand(RunWipeDB);
    }
  }
}
