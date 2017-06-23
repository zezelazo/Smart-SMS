using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSMS.Web.Data;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Controllers {
  [Route("api/[controller]")]
  public class MessageDefinitionsController : GenericController<MessageDefinition>
  {
    public MessageDefinitionsController(MessageDefinitionsRepository repo, ILogger<GenericController<MessageDefinition>> logger) : base(repo, logger) { }
  }
}