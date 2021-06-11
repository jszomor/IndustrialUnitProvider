using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class InstrumentListViewModel : BaseViewModel
  {
    private ObservableCollection<InstrumentViewModel> _instruments;
    public ObservableCollection<InstrumentViewModel> Instruments
    {
      get
      {
        return _instruments;
      }
      set
      {
        _instruments = value;
        OnPropertyChanged();
        SelectedInstrumentViewModel = new InstrumentViewModel();
      }
    }

    private InstrumentViewModel _selectedInstrumentViewModel;
    public InstrumentViewModel SelectedInstrumentViewModel
    {
      get
      {
        return _selectedInstrumentViewModel;
      }
      set
      {
        _selectedInstrumentViewModel = value;
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

    private void RunAddCommand() => MessageToScreen = InstrumentRepository.SubmitAdd(SelectedInstrumentViewModel.ToInstrument());
    private void RunDeleteCommand() => MessageToScreen = InstrumentRepository.SubmitDelete(SelectedInstrumentViewModel.ToInstrument());
    private void RunUpdateCommand() => MessageToScreen = InstrumentRepository.SubmitUpdate(SelectedInstrumentViewModel.ToInstrument());
    private void RunFilterCommand()
    {
      var (instruments, messageToScreen) = InstrumentRepository.GetFilteredInstruments(SelectedInstrumentViewModel.ItemType);

      if (instruments == null)
        MessageToScreen = messageToScreen;
      else
        UpdateInstrument(instruments);
      MessageToScreen = messageToScreen;
    }

    private void InitDatabase()
    {
      var (instruments, messageToScreen) = InstrumentRepository.GetAllInstruments();

      if (instruments == null)
        MessageToScreen = messageToScreen;
      else
      {
        UpdateInstrument(instruments);
        MessageToScreen = messageToScreen;
      }
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand RefreshCommand { get; }

    public InstrumentListViewModel()
    {
      AddCommand = new RelayCommand(RunAddCommand);
      DeleteCommand = new RelayCommand(RunDeleteCommand);
      UpdateCommand = new RelayCommand(RunUpdateCommand);
      FilterCommand = new RelayCommand(RunFilterCommand);
      RefreshCommand = new RelayCommand(InitDatabase);
      InitDatabase();
    }

    private void UpdateInstrument(IEnumerable<Instrument> instrument)
    {
      Instruments = new ObservableCollection<InstrumentViewModel>(instrument.Select(x => new InstrumentViewModel(x)));
    }
  }
}
