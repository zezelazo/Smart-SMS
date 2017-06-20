using System;
using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class Level
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Grade> Grades { get; set; }
  }
}