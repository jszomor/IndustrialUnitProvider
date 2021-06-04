using IndustrialUnit.WpfUI.Models;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System.Collections.Generic;
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

    private long? _processTime;
    public long? ProcessTime
    {
      get { return _processTime; }
      set { _processTime = value; OnPropertyChanged(); }
    }

    public string Path { get; set; }

    public ICommand SelectFileDialogBox { get; }
    public ICommand LoadFile { get; }
    public ICommand SaveFile { get; }
    public ICommand DownloadTemplate { get; }

    private void RunSelectCommand() => (SelectedFile, Path) = FileModel.OpenFile();
    private void RunLoadCommand() => LogMessage = FileModel.LoadIntoDB(Path);
    private void RunSaveFileCommand()
    {
      Task<long> ElapsedProcessTimeMilliseconds = FileModel.SaveFile();
      ProcessTime = ElapsedProcessTimeMilliseconds.Result;
    }

    private void RunDownLoadTemplateFileCommand() => ProcessTime = FileModel.DownLoadTemplateFile();

    public FileViewModel()
    {
      SelectFileDialogBox = new RelayCommand(RunSelectCommand);
      LoadFile = new RelayCommand(RunLoadCommand);
      SaveFile = new RelayCommand(RunSaveFileCommand);
      DownloadTemplate = new RelayCommand(RunDownLoadTemplateFileCommand);
    }
  }
}
