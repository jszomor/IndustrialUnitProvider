using IndustrialUnitDatabase;
using IndustrialUnit.Model;
using IndustrialUnit.Model.Model;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using IndustrialUnit.WpfUI.Validation;
using IndustrialUnit.WpfUI.ViewModels;
using System.IO;
using IndustrialUnit.WpfUI.Models;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Media;
using IndustrialUnitProvider;
using System;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for EquipmentView.xaml
  /// </summary>
  public partial class EquipmentView : UserControl
  {
    public EquipmentView()
    {
      InitializeComponent();
    }
  }
}
