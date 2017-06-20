using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class MessageDefinition
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public ICollection<Student> Students { get; set; }
  }
}