using IndustrialUnit.WpfUI.Commands;
using System.Data;
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

    //private void RunInsertCommand() => EquipmentCommands.SubmitInsert(this, "Equipment");

    public DataTable EqDataGrid { get; set; }

    //public ICommand InsertEquipmentCommand { get; }

    public EquipmentViewModel()
    {      
      //InsertEquipmentCommand = new RelayCommand(RunInsertCommand);
    }
  }
}
