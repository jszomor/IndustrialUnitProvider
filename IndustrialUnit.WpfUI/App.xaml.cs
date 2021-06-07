using IndustrialUnit.WpfUI.Views;
using System.Windows;

namespace IndustrialUnit.WpfUI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false; 
      //allow to have dot at numeric type https://stackoverflow.com/questions/11223236/binding-to-double-field-with-validation/14834306

      var main = new MainWindow();
      main.Show();
      base.OnStartup(e);
    }
  }
}
