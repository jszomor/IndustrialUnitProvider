using System.ComponentModel;

namespace IndustrialUnit.WpfUI.ViewModels
{
  /// <summary>
  /// A base for objects using property notification.
  /// </summary>
  public class BaseViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void OnPropertyIntChanged(int propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName.ToString()));
    }
  }
}
