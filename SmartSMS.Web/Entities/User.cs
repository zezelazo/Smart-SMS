namespace SmartSMS.Web.Entities {
  public class User :ClientChangeTracker,IEntity{
    public int Id { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }

    //public Contact Contact { get; set; }
    //public DateTime LastLogin { get; set; }
    public bool Active { get; set; }
  }
}
