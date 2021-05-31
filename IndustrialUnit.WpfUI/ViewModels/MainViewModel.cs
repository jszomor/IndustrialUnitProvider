﻿using IndustrialUnit.WpfUI.Models;
using IndustrialUnit.WpfUI.Views;
using IndustrialUnitProvider;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class MainViewModel : BaseViewModel
  {

    public Frame Frame { get; set; } = new();
    public ICommand LoadFileDialogBox { get; }
    public ICommand LoadEquipmentView { get; }
    public ICommand LoadValveView { get; }
    public ICommand LoadInstrumentView { get; }
    public ICommand LoadFileView { get; }

    public void InitEquipmentView() => Frame.Content = new EquipmentView();
    public void InitValveView() => Frame.Content = new ValveView();
    public void InitInstrumentView() => Frame.Content = new InstrumentView();
    public void InitFileView() => Frame.Content = new FileView();


    public MainViewModel()
    {
      LoadEquipmentView = new RelayCommand(InitEquipmentView);
      LoadValveView = new RelayCommand(InitValveView);
      LoadInstrumentView = new RelayCommand(InitInstrumentView);
      LoadFileView = new RelayCommand(InitFileView);
    }  
	}
}
