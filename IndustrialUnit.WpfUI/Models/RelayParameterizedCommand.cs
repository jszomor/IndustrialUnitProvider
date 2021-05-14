using IndustrialUnit.WpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.Models
{
  public class RelayParameterizedCommand<T> : ICommand
  {
    /// <summary>
    /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
    /// </summary>
    public event EventHandler CanExecuteChanged = (sender, e) => { };

    private Action<T>  mAction;

    public RelayParameterizedCommand(Action<T> action)
    {
      mAction = action;
    }

    public virtual bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      T a = (T)parameter;

      mAction(a);
    }

    //protected void OnCanExecuteChanged()
    //{
    //  CanExecuteChanged?.Invoke(this, new EventArgs());
    //}
  }
}
