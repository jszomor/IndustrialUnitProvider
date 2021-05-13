using IndustrialUnit.WpfUI.Commands;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IndustrialUnit.WpfUI.ViewModels
{
  public class EquipmentViewModel : BaseViewModel
  {
    private int _id;
    public int Id { get => _id; set { _id = value; OnPropertyIntChanged(_id); } }
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

    private void RunInsertCommand() => BaseModel.SubmitInsert(this, "Equipment", IsEquipmentEmpty);
    private void RunDeleteCommand() => BaseModel.SubmitDelete("Equipment", Id);
    private void RunUpdateCommand() => BaseModel.SubmitUpdate(this, "Equipment", IsEquipmentEmpty, Id);


    public ICommand InsertEquipmentCommand { get; }
    public ICommand DeleteEquipmentCommand { get; }
    public ICommand UpdateEquipmentCommand { get; }

    public EquipmentViewModel()
    {
      InsertEquipmentCommand = new RelayCommand(RunInsertCommand);
      DeleteEquipmentCommand = new RelayCommand(RunDeleteCommand);
      UpdateEquipmentCommand = new RelayCommand(RunUpdateCommand);
    }
  }
}
