using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  /// <summary>
  /// A base for objects using property notification.
  /// </summary>
  public class BaseViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public void PreviewInputTextRule(object sender, TextCompositionEventArgs e)
    {
      var ue = e.Source as TextBox;

      Regex regex;
      if (ue.Text.Contains("."))
      {
        regex = new Regex("[^0-9]+");
      }
      else
      {
        regex = new Regex("[^0-9.]+");
      }

      e.Handled = regex.IsMatch(e.Text);


      //var regex = new Regex("^[.][0-9 ]+$|^[0-9 ]*[.]{0,1}[0-9 ]*$");
      //e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));      
    }
  }
}
