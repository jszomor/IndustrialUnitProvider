namespace IndustrialUnitProvider
{
  public class Instrument
  {
    public int Id { get; set; }
    public string ItemType { get; set; }
    public string OperationPrinciple { get; set; }
    public string InstallationType { get; set; }
    public string MediumToMeasure { get; set; }
    public string Supplier { get; set; }
    public string Manufacturer { get; set; }
    public decimal UnitPrice { get; set; }
  }
}
