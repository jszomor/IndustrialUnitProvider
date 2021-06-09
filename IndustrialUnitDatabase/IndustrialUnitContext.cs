using IndustrialUnit.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace IndustrialUnitDatabase
{
  public class IndustrialUnitContext : DbContext
  {
    public IndustrialUnitContext(DbContextOptions<IndustrialUnitContext> options) : base(options) { }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Valve> Valve { get; set; }
    public DbSet<Instrument> Instrument { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string file = "IndustrialUnitDB.db";

      optionsBuilder.UseSqlite($"Data Source={Path.Combine(Environment.CurrentDirectory, file)}");
    }
  }
}
