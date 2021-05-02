using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialUnit.WpfUI.Validation
{
  /// <summary>
  /// A base for objects using property notification.
  /// </summary>
  public class ObservableObject : INotifyPropertyChanged, INotifyDataErrorInfo
  {
    public event PropertyChangedEventHandler PropertyChanged;

    Dictionary<string, List<string>> _errorsOnView = new Dictionary<string, List<string>>();

    /// <summary>
    /// Notify a property change
    /// </summary>
    /// <param name="propertyName">Name of property to update</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Notify a property change that uses CallerMemberName attribute
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="backingField">Backing field of property</param>
    /// <param name="value">Value to give backing field</param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
    {
      if (EqualityComparer<T>.Default.Equals(backingField, value))
        return false;

      backingField = value;
      OnPropertyChanged(propertyName);
      return true;
    }

    public bool HasErrors => _errorsOnView.Any();

    public bool CanCreate => !HasErrors;

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
    {
      return _errorsOnView.ContainsKey(propertyName) ? _errorsOnView[propertyName] : null;
    }

    private void OnErrorsChanged(string propertyName)
    {
      ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public void AddError(string propertyName, string error)
    {
      if (!_errorsOnView.ContainsKey(propertyName))
        _errorsOnView[propertyName] = new List<string>();

      if (!_errorsOnView[propertyName].Contains(error))
      {
        _errorsOnView[propertyName].Add(error);
        OnErrorsChanged(propertyName);
      }
    }

    public void ClearErrors(string propertyName)
    {
      if (_errorsOnView.ContainsKey(propertyName))
      {
        _errorsOnView.Remove(propertyName);
        OnErrorsChanged(propertyName);
      }
    }

    //private void ValidateCapacityText()
    //{
    //  ClearErrors(nameof(Capacity));

    //  if (Capacity.Any(char.IsLetter))
    //    AddError(nameof(Capacity), "Only number is allowed.");

    //  else if (!string.IsNullOrWhiteSpace(Capacity) && Capacity?.Length < 3)
    //    AddError(nameof(Capacity), "Label must consist at least 3 char.");

    //  else if (string.IsNullOrWhiteSpace(Capacity))
    //    AddError(nameof(Capacity), "Label cannot be empty.");
    //}
  }
}
