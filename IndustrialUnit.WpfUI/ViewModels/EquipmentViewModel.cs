using IndustrialUnit.Model.Model;
using IndustrialUnit.WpfUI.Models;
using IndustrialUnitDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {
    private ObservableCollection<EquipmentViewProperties> _equipments;
    public ObservableCollection<EquipmentViewProperties> Equipments
    {
      get
      {
        return _equipments;
      }
      set
      {
        _equipments = value;
        OnPropertyChanged();
        SelectedEquipment = new EquipmentViewProperties();
      }
    }

    private EquipmentViewProperties _selectedEquipment;
    public EquipmentViewProperties SelectedEquipment
    {
      get
      {
        return _selectedEquipment;
      }
      set
      {
        _selectedEquipment = value;
        OnPropertyChanged();
      }
    }

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
        OnPropertyChanged();
      }
    }


    public static ObservableCollection<EquipmentViewProperties> GetEquipments()
    {
      ObservableCollection<EquipmentViewProperties> equipmentCollection = new();
      var getEquipment = SQLiteDataAccess.GetAll("Equipment");

      var rowNumber = getEquipment.Rows.Count;

      for (int i = 0; i < rowNumber; i++)
      {
        var item = getEquipment.Rows[i];
        equipmentCollection.Add(
          new EquipmentViewProperties()
          {
            Id = Convert.ToInt32(item.ItemArray[0]),
            ItemType = Convert.ToString(item.ItemArray[1]),
            Capacity = Convert.ToDecimal(item.ItemArray[2]),
            Pressure = Convert.ToDecimal(item.ItemArray[3]),
            PowerConsumption = Convert.ToDecimal(item.ItemArray[4]),
            Manufacturer = Convert.ToString(item.ItemArray[5]),
            Model = Convert.ToString(item.ItemArray[6]),
            UnitPrice = Convert.ToDecimal(item.ItemArray[7]),
          });
      }
      return equipmentCollection;
    }

    public ObservableCollection<EquipmentViewProperties> GetFilteredEquipments(ObservableCollection<EquipmentViewProperties> Equipments)
    {
      if (!String.IsNullOrWhiteSpace(SelectedEquipment.ItemType))
      {
        try
        {
          ObservableCollection<EquipmentViewProperties> equipmentCollection = new();
          var getFilteredEquipment = SQLiteDataAccess.GetFilteredDB("Equipment", SelectedEquipment.ItemType);
          string originalItemName = SelectedEquipment.ItemType;
          var rowNumber = getFilteredEquipment.Rows.Count;

          for (int i = 0; i < rowNumber; i++)
          {
            var item = getFilteredEquipment.Rows[i];
            equipmentCollection.Add(
              new EquipmentViewProperties()
              {
                Id = Convert.ToInt32(item.ItemArray[0]),
                ItemType = Convert.ToString(item.ItemArray[1]),
                Capacity = Convert.ToDecimal(item.ItemArray[2]),
                Pressure = Convert.ToDecimal(item.ItemArray[3]),
                PowerConsumption = Convert.ToDecimal(item.ItemArray[4]),
                Manufacturer = Convert.ToString(item.ItemArray[5]),
                Model = Convert.ToString(item.ItemArray[6]),
                UnitPrice = Convert.ToDecimal(item.ItemArray[7]),
              });
          }
          MessageToView = $"Filter name: {originalItemName} \nPress Refresh to see the whole database again.";
          return equipmentCollection;
        }
        catch (FileNotFoundException message)
        {
          throw new FileNotFoundException($"{message}");
        }
      }
      else
      {
        MessageToView = "Filter word is 'Item Name', \nit cannot be empty for searching!";
        return Equipments;
      }
    }

    public static bool IsEquipmentEmpty(EquipmentViewProperties eq)
    {
      if (string.IsNullOrEmpty(eq.ItemType) ||
          string.IsNullOrEmpty(eq.Capacity.ToString()) ||
          string.IsNullOrEmpty(eq.Pressure.ToString()) ||
          string.IsNullOrEmpty(eq.PowerConsumption.ToString()) ||
          string.IsNullOrEmpty(eq.Manufacturer) ||
          string.IsNullOrEmpty(eq.Model) ||
          string.IsNullOrEmpty(eq.UnitPrice.ToString()))
      {
        return false;
      }
      return true;
    }

    private void RunAddCommand() => MessageToView = BaseModel.SubmitAdd(SelectedEquipment, "Equipment", IsEquipmentEmpty);
    private void RunDeleteCommand() => MessageToView = BaseModel.SubmitDelete("Equipment", SelectedEquipment.Id);
    private void RunUpdateCommand() => MessageToView = BaseModel.SubmitUpdate(SelectedEquipment, "Equipment", IsEquipmentEmpty, SelectedEquipment.Id);
    private void RunFilterCommand() => Equipments = GetFilteredEquipments(Equipments);
    private void RunRefreshCommand()
    {
      Equipments = GetEquipments();
      MessageToView = "Refresh done.";
    }

    public ICommand AddEquipmentCommand { get; }
    public ICommand DeleteEquipmentCommand { get; }
    public ICommand UpdateEquipmentCommand { get; }
    public ICommand FilterEquipmentCommand { get; }
    public ICommand RefreshEquipmentCommand { get; }

    public EquipmentViewModel()
    {
      AddEquipmentCommand = new RelayCommand(RunAddCommand);
      DeleteEquipmentCommand = new RelayCommand(RunDeleteCommand);
      UpdateEquipmentCommand = new RelayCommand(RunUpdateCommand);
      FilterEquipmentCommand = new RelayCommand(RunFilterCommand);
      RefreshEquipmentCommand = new RelayCommand(RunRefreshCommand);
      Equipments = GetEquipments();
    }
  }
}
