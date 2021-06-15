using IndustrialUnit.WpfUI.Models;
using IndustrialUnit.WpfUI.Views;
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

    private void RunSelectCommand() => (SelectedFile, Path) = FileRepository.OpenFile();
    private void RunLoadCommand()
    {
      Window window = new ProgressDialog(Path);
      //window.ShowDialog();
      //=> LogMessage = FileRepository.LoadIntoDB(Path);
    }
    private void RunDBCreator() => LogMessage = FileRepository.CreateDatabaseModel();
    private void RunWipeDB() => LogMessage = FileRepository.WipeDatabaseModel();

    public FileViewModel()
    {
      SelectFileDialogBox = new RelayCommand(RunSelectCommand);
      LoadFile = new RelayCommand(RunLoadCommand);
      SaveFile = new RelayCommand(FileRepository.SaveFile);
      DownloadTemplate = new RelayCommand(FileRepository.DownLoadTemplateFile);
      CreateEmptyDatabase = new RelayCommand(RunDBCreator);
      WipeDatabase = new RelayCommand(RunWipeDB);
    }
  }
}
