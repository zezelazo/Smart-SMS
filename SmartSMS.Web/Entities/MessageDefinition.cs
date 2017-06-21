using System;
using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class MessageDefinition :ClientChangeTracker{
    public MessageDefinition() {
      Students = new HashSet<StudentMessage>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public ICollection<StudentMessage> Students { get; set; }    
    public DateTime? SendedOn { get; set; }
  }
}
