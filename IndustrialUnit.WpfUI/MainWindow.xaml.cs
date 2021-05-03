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
    }

    private void Equipment_menu_click(object sender, RoutedEventArgs e)
    {
      Main.Content = new EquipmentView();
    }
  }
}
