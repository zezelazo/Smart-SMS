using System.Collections.Generic;

namespace SmartSMS.Web.Entities {
  public class Grade :ClientChangeTracker,IEntity{
    public Grade() {
      Classes = new HashSet<Class>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Level Level { get; set; }
    public int LevelId { get; set; }
    public ICollection<Class> Classes { get; set; }
  }
}
