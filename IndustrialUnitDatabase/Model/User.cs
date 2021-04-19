using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndustrialUnitDatabase.Model
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string AdminName { get; set; }
    public string AdminPassword { get; set; }
  }
}
