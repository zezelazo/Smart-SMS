using System;
using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class User
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public Contact Contact { get; set; }
    public DateTime LastLogin { get; set; }
    public bool Active { get; set; }
  }  
}