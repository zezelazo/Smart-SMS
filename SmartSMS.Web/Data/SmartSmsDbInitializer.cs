using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Data {
  public class SmartSmsDbInitializer {
    private readonly SmartSmsContext _ctx;

    private List<Level> _levels = new List<Level> {
                                                    new Level {
                                                                Name = "Primaria",
                                                                Grades = new List<Grade> {
                                                                                           new Grade {
                                                                                                       Name = "Primer Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Segundo Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Tercer Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Cuarto Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Quinto Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Sexto Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     }
                                                                                         }
                                                              },
                                                    new Level {
                                                                Name = "Secundaria",
                                                                Grades = new List<Grade> {
                                                                                           new Grade {
                                                                                                       Name = "Primer Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Segundo Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Tercer Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Cuarto Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     },
                                                                                           new Grade {
                                                                                                       Name = "Quinto Grado",
                                                                                                       Classes = new List<Class> {
                                                                                                                                   new Class {Name = "A"},
                                                                                                                                   new Class {Name = "B"}
                                                                                                                                 }
                                                                                                     }
                                                                                         }
                                                              }
                                                  };

    public SmartSmsDbInitializer(SmartSmsContext ctx) {
      _ctx = ctx;
    }

    public async Task Seed() {
      if (!_ctx.Levels.Any()) {    
        _ctx.AddRange(_levels);
        await _ctx.SaveChangesAsync();
      }
    }
  }
}
