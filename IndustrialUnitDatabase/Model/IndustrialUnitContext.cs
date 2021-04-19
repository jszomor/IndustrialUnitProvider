using IndustrialUnitProvider;
using Microsoft.EntityFrameworkCore;

namespace IndustrialUnitDatabase.Model
{
  public class IndustrialUnitContext : DbContext
  {
    //public IndustrialUnitContext(DbContextOptions<IndustrialUnitContext> options) : base(options) { }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Valve> Valves { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Order { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite($"Data Source={Helper.DataBasePath("IndustrialUnitDB.db")}");
    }
  }
}
