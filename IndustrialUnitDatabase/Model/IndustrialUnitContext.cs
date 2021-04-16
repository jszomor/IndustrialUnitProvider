using IndustrialUnitProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUnitDatabase.Model
{
  public class IndustrialUnitContext : DbContext
  {
    public IndustrialUnitContext(DbContextOptions<IndustrialUnitContext> options) : base(options) { }
    public DbSet<Equipment> _equipments { get; set; }
    public DbSet<Valve> _valves { get; set; }
    public DbSet<Instrument> _instruments { get; set; }
    public DbSet<User> _users { get; set; }
    public DbSet<Order> _order { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IndustrialUnitDb;Integrated Security=True");
    }
  }
}
