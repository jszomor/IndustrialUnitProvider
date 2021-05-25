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
      var main = new MainWindow();
      main.Show();
      base.OnStartup(e);
    }
  }
}
