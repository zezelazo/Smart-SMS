using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class StudentMessage :ClientChangeTracker,IEntity{
    public StudentMessage() {
      Smses = new HashSet<Sms>();
    }
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int MessageDefinitionId { get; set; }
    public Student Student { get; set; }
    public MessageDefinition MessageDefinition { get; set; }
    public bool SendToFather { get; set; }
    public bool SendToMother { get; set; }
    public ICollection<Sms> Smses { get; set; }
  }
}
