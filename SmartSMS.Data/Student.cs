using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class Student : Contact
  {
    public Class Class { get; set; }
    public int ClassId { get; set; }
    public Contact Father { get; set; }
    public Contact Mother { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
    public ICollection<StudentMessage> Messages { get; set; }
  }
}