using IndustrialUnit.WpfUI.Models;
using IndustrialUnit.WpfUI.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    public Frame Frame { get; set; } = new();
    public EquipmentView EquipmentView { get; set; } = new();
    public ValveView ValveView { get; set; } = new();

    public ICommand LoadEquipmentView { get; }
    public ICommand LoadValveView { get; }

    public void InitEquipmentView() => Frame.Content = EquipmentView;

    public void InitValveView() => Frame.Content = ValveView;

    public MainViewModel()
    {
      LoadEquipmentView = new RelayCommand(InitEquipmentView);
      LoadValveView = new RelayCommand(InitValveView);
    }  
	}
}
