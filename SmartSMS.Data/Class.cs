using System;
using System.Collections.Generic;

namespace SmartSMS.Data
{
  public class Class{
    public int Id { get; set; }
    public string Name { get; set; }
    public Grade Grade{get;set;}
    public int GradeId {get;set;}
    public ICollection<Student> Students {get;set;}
  }
}