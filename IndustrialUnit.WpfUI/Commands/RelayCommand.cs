using IndustrialUnit.WpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.Commands
{
  public class RelayCommand : ICommand
  {
    /// <summary>
    /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
    /// </summary>
    public event EventHandler CanExecuteChanged = (sender, e) => { };

    private Action  mAction;

    public RelayCommand(Action action)
    {
      mAction = action;
    }

    public virtual bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      mAction();
    }
  }
}
