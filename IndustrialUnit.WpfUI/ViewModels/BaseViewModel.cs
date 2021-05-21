using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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


    
  }
}
