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


    private string _loadExcelFileDescription;
    public string LoadExcelFileDescription
    {
      get
      {
        _loadExcelFileDescription =
          "Use the appropriate excel file to load batch collection of data into the database. Excel file must" +
          "\ncontain strictly named columns and sheets. Please download the template file to fill your data." +
          "\nLog window will show valuable information about the procedure even if invalid data found in the file.";
        return _loadExcelFileDescription;
      }
    }

    private string _saveDatabaseDescription;
    public string SaveDatabaseDescription
    {
      get
      {
        _saveDatabaseDescription =
          "Save the total database into a single excel file to selected folder." +
          "\nYou can name the file as you wish.";
        return _saveDatabaseDescription;
      }
    }

    private string _downloadTemplateDescription;
    public string DownloadTemplateDescription
    {
      get
      {
        _downloadTemplateDescription =
          "This Software can read an excel file that has certain columns and sheets." +
          "\nPlease use the template file to to load your collection into the database." +
          "\nDo not change the names of the columns and sheets." +
          "\nYou can name the file as you wish.";
        return _downloadTemplateDescription;
      }
    }

    private string _createDatabaseDescription;
    public string CreateDatabaseDescription
    {
      get
      {
        _createDatabaseDescription =
          "Industrial Unit Manager uses separate local database file. Without this file the software is useless." +
          "\nSo as a good starting pont let's create an empty database file if you don't have one yet to be able" +
          "\nto store data. Database file must be named as follows 'IndustrialUnitDB.db' which will be created" +
          "\nin the installation folder by the press of the create button. Keep the database file in the folder where" +
          "\nit is generated. It is not possible to create new database if one is already exist with the same name.";
        return _createDatabaseDescription;
      }
    }

    private string _wipeDatabaseDescription;
    public string WipeDatabaseDescription
    {
      get
      {
        _wipeDatabaseDescription =
          "Delete all data from all category by one button. Database file will remain but it will be completely" +
          "\nempty. You will be asked to confirm your decision. The request is irrevocable and permanent." +
          "\nSuggestion is to rename the current one and store it as backup for later usage.";
        return _wipeDatabaseDescription;
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
    private void RunLoadCommand() => LogMessage = FileRepository.LoadIntoDB(Path);
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
