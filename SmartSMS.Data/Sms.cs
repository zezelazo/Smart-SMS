using System;

namespace SmartSMS.Data
{
    public class Sms
    {
        public int Id{get;set;}
        public StudentMessage StudentMessage { get; set; }
        public int  StudentMessageId { get; set; }
        public string Phone {get;set;}
        public string Contact {get;set;}
        public string ContactType {get;set;}
        public string Message{get;set;}
        public bool NetworkSended{get;set;}
        public bool NetworkRecived{get;set;}
        public DateTime SendedOn{get;set;}
    }
}
