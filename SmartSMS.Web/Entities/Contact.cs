namespace SmartSMS.Web.Entities {
  public class Contact:ClientChangeTracker,IEntity {
    public int Id { get; set; }
    public string LegalId { get; set; }
    public string Prefix { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
  }
}
