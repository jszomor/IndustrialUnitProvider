using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for ValveView.xaml
  /// </summary>
  public partial class ValveView : UserControl
  {
    public ICommand LoadCommand
    {
      get { return (ICommand)GetValue(LoadCommandProperty); }
      set { SetValue(LoadCommandProperty, value); }
    }

    public static readonly DependencyProperty LoadCommandProperty =
        DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(ValveView), new PropertyMetadata(null));

    public ICommand SelectedTodoItemsChangedCommand
    {
      get { return (ICommand)GetValue(SelectedTodoItemsChangedCommandProperty); }
      set { SetValue(SelectedTodoItemsChangedCommandProperty, value); }
    }

    public static readonly DependencyProperty SelectedTodoItemsChangedCommandProperty =
        DependencyProperty.Register("SelectedTodoItemsChangedCommand", typeof(ICommand), typeof(ValveView), new PropertyMetadata(null));

    public ValveView()
    {
      InitializeComponent();
    }

    private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      if (LoadCommand != null)
      {
        LoadCommand.Execute(null);
      }
    }
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (SelectedTodoItemsChangedCommand != null)
      {
        SelectedTodoItemsChangedCommand.Execute(lvValveItems.SelectedItems);
      }
    }

  }
}
