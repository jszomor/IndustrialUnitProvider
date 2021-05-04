using IndustrialUnit.WpfUI.ViewModels;
using IndustrialUnit.WpfUI.Views;
using System.Windows;

namespace IndustrialUnit.WpfUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      DataContext = new MainViewModel();
    }

    private void LoadEquipmentMenu_click(object sender, RoutedEventArgs e)
    {
      Main.Content = new EquipmentView();
    }

    private void LoadValveMenu_click(object sender, RoutedEventArgs e)
    {
      Main.Content = new ValveView();
    }
  }
}
