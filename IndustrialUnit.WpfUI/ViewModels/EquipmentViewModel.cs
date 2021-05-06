using Caliburn.Micro;
using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Commands;
using IndustrialUnitDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {
    public string ItemType { get; set; }
    public decimal Capacity { get; set; }
    public decimal Pressure { get; set; }
    public decimal PowerConsumption { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public decimal UnitPrice { get; set; }

    private void RunInsertCommand() => EquipmentCommands.SubmitInsert(this, "Equipment");

    public ICommand InsertEquipmentCommand { get; }

    public EquipmentViewModel()
    {      
      InsertEquipmentCommand = new RelayCommand(RunInsertCommand);
    }
  }
}
