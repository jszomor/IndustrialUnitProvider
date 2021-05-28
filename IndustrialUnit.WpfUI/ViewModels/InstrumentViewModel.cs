using IndustrialUnit.WpfUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class InstrumentViewModel : BaseViewModel
  {
    private ObservableCollection<Instrument> _instruments;
    public ObservableCollection<Instrument> Instruments
    {
      get
      {
        return _instruments;
      }
      set
      {
        _instruments = value;
        OnPropertyChanged();
        SelectedItem = new Instrument();
      }
    }

    private Instrument _selectedItem;
    public Instrument SelectedItem
    {
      get
      {
        return _selectedItem;
      }
      set
      {
        _selectedItem = value;
        OnPropertyChanged();
      }
    }

    private string _MessageToScreen;
    public string MessageToScreen
    {
      get
      {
        return _MessageToScreen;
      }
      set
      {
        _MessageToScreen = value;
        OnPropertyChanged();
      }
    }

    private void RunAddCommand() => MessageToScreen = InstrumentModel.SubmitAdd(SelectedItem);
    private void RunDeleteCommand() => MessageToScreen = InstrumentModel.SubmitDelete(SelectedItem);
    private void RunUpdateCommand() => MessageToScreen = InstrumentModel.SubmitUpdate(SelectedItem);
    private void RunFilterCommand() => (Instruments, MessageToScreen) = InstrumentModel.GetFilteredInstruments(Instruments, SelectedItem.ItemType);
    private void RunRefreshCommand()
    {
      (Instruments, MessageToScreen) = InstrumentModel.GetAllInstruments();
      MessageToScreen = "Refresh done.";
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public InstrumentViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(RunRefreshCommand);
      (Instruments, MessageToScreen) = InstrumentModel.GetAllInstruments();
    }
  }
}
