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
          "Use an excel file to load batch collection of data into the database. " +
          "\nExcel file must contain strictly named columns and sheets." +
          "\nPlease use the template file for this.";
        return _loadExcelFileDescription;
      }
    }

    private string _saveDatabaseDescription;
    public string SaveDatabaseDescription
    {
      get
      {
        _saveDatabaseDescription =
          "Save the total database into a single excel file in a selected folder.";
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
          "\nPlease use this to be able to load your collection into the database." +
          "\nDo not change the names of the columns and sheets.";
        return _downloadTemplateDescription;
      }
    }

    private string _createDatabaseDescription;
    public string CreateDatabaseDescription
    {
      get
      {
        _createDatabaseDescription =
          "Industrial Unit Manager uses local database file which is separated from the main program \nwithout this the software is useless." +
          "So as a good starting pont let's create an empty database file if you don't have to be able to store information." +
          "\nDdatabase file must be named right 'IndustrialUnitDB.db' which will be created next to this demo program by hit of the create button." +
          "\nIt is not possible to create new database if one is already exist. You must rename or delete the previous one.";
        return _createDatabaseDescription;
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
