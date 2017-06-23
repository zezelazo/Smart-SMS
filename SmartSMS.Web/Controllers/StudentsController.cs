using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SmartSMS.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using SmartSMS.Web.Data;

namespace SmartSMS.Web.Controllers
{

    [Route("api/[controller]")]
    public class StudentsController:GenericController<Student>
    {
        public StudentsController(StudentsRepository repo, ILogger<GenericController<Student>> logger) : base(repo, logger) {}
    }
}
