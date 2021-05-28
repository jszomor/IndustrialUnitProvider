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

    private string _messageToView;
    public string MessageToView
    {
      get
      {
        return _messageToView;
      }
      set
      {
        _messageToView = value;
        OnPropertyChanged();
      }
    }

    private void RunAddCommand() => MessageToView = InstrumentModel.SubmitAdd(SelectedItem);
    private void RunDeleteCommand() => MessageToView = InstrumentModel.SubmitDelete(SelectedItem);
    private void RunUpdateCommand() => MessageToView = InstrumentModel.SubmitUpdate(SelectedItem);
    private void RunFilterCommand() => (Instruments, MessageToView) = InstrumentModel.GetFilteredInstruments(Instruments, SelectedItem.ItemType);
    private void RunRefreshCommand()
    {
      Instruments = InstrumentModel.GetAllInstruments();
      MessageToView = "Refresh done.";
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
      Instruments = InstrumentModel.GetAllInstruments();
    }
  }
}
