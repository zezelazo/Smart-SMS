using System;
using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class Grade
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Level Level { get; set; }
    public int LevelId { get; set; }
    public ICollection<Class> Classes { get; set; }
  }
}
