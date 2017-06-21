using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class Class :ClientChangeTracker{
    public Class() {
      Students=new List<Student>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Grade Grade { get; set; }
    public int GradeId { get; set; }
    public ICollection<Student> Students { get; set; }
  }
}
