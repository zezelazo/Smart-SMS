using System.Collections.Generic;

namespace SmartSMS.Data
{
    public class StudentMessage
    {
        public int StudentId{get;set;}
        public int MessageDefinitionId{get;set;}
        public Student Student{get;set;}
        public MessageDefinition MessageDefinition{get;set;} 
        public bool SendToFather{get;set;}
        public bool SendToMother{get;set;}
        public ICollection<Sms> Sms{get;set;}
    }
}