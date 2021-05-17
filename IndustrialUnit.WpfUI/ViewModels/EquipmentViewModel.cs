using IndustrialUnit.WpfUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {
    private DataView _eqDataGrid;
    public DataView EqDataGrid { 
      get 
      {
        return _eqDataGrid;
      } 
      set 
      {
        _eqDataGrid = value; 
        OnPropertyChanged(nameof(EqDataGrid));
      }}


    private string _messageToView;
    public string MessageToView
    {
      get 
      { 
        return _messageToView; 
      }
      set 
      { 
        _messageToView = value;
        OnPropertyChanged(nameof(MessageToView)); 
      }
    }

    public int Id { get; set; }
    public string ItemType { get; set; }
    public decimal Capacity { get; set; }
    public decimal Pressure { get; set; }
    public decimal PowerConsumption { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public decimal UnitPrice { get; set; }

    public bool IsEquipmentEmpty(EquipmentViewModel eq)
    {
      if (string.IsNullOrEmpty(ItemType) ||
          string.IsNullOrEmpty(Capacity.ToString()) ||
          string.IsNullOrEmpty(Pressure.ToString()) ||
          string.IsNullOrEmpty(PowerConsumption.ToString()) ||
          string.IsNullOrEmpty(Manufacturer) ||
          string.IsNullOrEmpty(Model) ||
          string.IsNullOrEmpty(UnitPrice.ToString()))
      {
        return false;
      }
      return true;
    }

    readonly BaseModel baseModel = new();

    private void RunInsertCommand() => MessageToView = baseModel.SubmitInsert(this, "Equipment", IsEquipmentEmpty);
    private void RunDeleteCommand() => MessageToView = baseModel.SubmitDelete("Equipment", Id);
    private void RunUpdateCommand() => MessageToView = baseModel.SubmitUpdate(this, "Equipment", IsEquipmentEmpty, Id);
    private void RunSearchCommand()
    {
      (EqDataGrid, MessageToView) = baseModel.FillDataGridFiltered("Equipment", ItemType);
    }
    //private void RunFillGridCommand() => EqDataGrid = baseModel.FillDataGrid("Equipment");

    public ICommand InsertEquipmentCommand { get; }
    public ICommand DeleteEquipmentCommand { get; }
    public ICommand UpdateEquipmentCommand { get; }
    public ICommand SearchEquipmentCommand { get; }

    public  void EquipmentTableGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DataGrid dg = (DataGrid)sender;
      if (dg.SelectedItem is DataRowView rowSelected)
      {
        List<string> textBoxNames = new()
        {
          "Id",
          "ItemType",
          "Capacity",
          "Pressure",
          "PowerConsumption",
          "Manufacturer",
          "Model",
          "UnitPrice"
        };

        //EqIdTextBox.Text = rowSelected[textBoxNames[0]].ToString();
        //EqItemTypeTextBox.Text = rowSelected[textBoxNames[1]].ToString();
        //EqCapacityTextBox.Text = rowSelected[textBoxNames[2]].ToString();
        //EqPressureTextBox.Text = rowSelected[textBoxNames[3]].ToString();
        //EqPowerConsumptionTextBox.Text = rowSelected[textBoxNames[4]].ToString();
        //EqManufacturerTextBox.Text = rowSelected[textBoxNames[5]].ToString();
        //EqModelTextBox.Text = rowSelected[textBoxNames[6]].ToString();
        //EqUnitPriceTextBox.Text = rowSelected[textBoxNames[7]].ToString();

        //LogTextBlock.Text = $"Number {rowSelected[textBoxNames[0]]} is selected";
      }
    }

    public EquipmentViewModel()
    {
      DataGrid select = new();
      select.SelectionChanged += EquipmentTableGrid_SelectionChanged;

      InsertEquipmentCommand = new RelayCommand(RunInsertCommand);
      DeleteEquipmentCommand = new RelayCommand(RunDeleteCommand);
      UpdateEquipmentCommand = new RelayCommand(RunUpdateCommand);
      SearchEquipmentCommand = new RelayCommand(RunSearchCommand);
      EqDataGrid = baseModel.FillDataGrid("Equipment");
    }
  }
}
