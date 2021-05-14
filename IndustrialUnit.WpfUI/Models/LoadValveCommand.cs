using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.Models
{
  public class LoadValveCommand : ICommand
  {
    public event EventHandler CanExecuteChanged;

    protected void OnCanExecuteChanged()
    {
      CanExecuteChanged?.Invoke(this, new EventArgs());
    }

    private readonly ValveViewModel _ListValveModel;

    public LoadValveCommand(ValveViewModel listValveViewModel)
    {
      _ListValveModel = listValveViewModel;
    }

    public async void Execute(object parameter)
    {
      // Get todo list items from API.
      IEnumerable<Valve> valveItems = await GetValveItemsAsync();
      CanExecuteChanged?.Invoke(this, new EventArgs());
      // Set the todo list items on the view model.
      _ListValveModel.Valves = new ObservableCollection<Valve>(valveItems);
    }

    private async Task<IEnumerable<Valve>> GetValveItemsAsync()
    {
      return await Task.FromResult(new[]
      {
        new Valve()
        {
          ItemType = "Knife Gate Valve",
          Operation = "Manual"
        }
      });
    }

    public bool CanExecute(object parameter)
    {
      CanExecuteChanged?.Invoke(this, new EventArgs());
      return true;
    }
  }
}
