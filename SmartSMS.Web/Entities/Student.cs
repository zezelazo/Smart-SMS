using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class Student:ClientChangeTracker {
    public Student() {
      Messages = new HashSet<StudentMessage>();
    }
    public int Id { get; set; }
    public Contact StudentInfo { get; set; }
    public int StudentInfoId { get; set; }
    public Class Class { get; set; }
    public int ClassId { get; set; }
    public Contact FatherInfo { get; set; }
    public Contact MotherInfo { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
    public ICollection<StudentMessage> Messages { get; set; }
  }
}
