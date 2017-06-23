using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartSMS.Web.Data
{
    public class LookUpsData
    {
      private readonly SmartSmsContext  _ctx;
      public LookUpsData(SmartSmsContext context)
      {
        _ctx=context;
        _ctx.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
      }

      public async Task<IEnumerable<KeyValuePair<int,string>>> GetLevels(){
        var items = await _ctx.Levels.OrderBy(s => s.Name)
                                      .Select(s => new {s.Id, s.Name})
                                      .ToDictionaryAsync(t => t.Id, t => t.Name);
        return items.ToList();
      }

       public async Task<IEnumerable<KeyValuePair<int,string>>> GetGradesByLevel(int levelId){
        var items = await _ctx.Grades.Where(s=>s.LevelId==levelId)
                                      .OrderBy(s => s.Name)
                                      .Select(s => new {s.Id, s.Name})
                                      .ToDictionaryAsync(t => t.Id, t => t.Name);
        return items.ToList();
      }
      public async Task<IEnumerable<KeyValuePair<int,string>>> GetClassesByGrade(int gradeId){
        var items = await _ctx.Classes.Where(s=>s.GradeId==gradeId)
                                      .OrderBy(s => s.Name)
                                      .Select(s => new {s.Id, s.Name})
                                      .ToDictionaryAsync(t => t.Id, t => t.Name);
        return items.ToList();
      } 
    }
}