using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class Level :ClientChangeTracker{
    public Level() {
      Grades = new HashSet<Grade>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Grade> Grades { get; set; }
  }
}
