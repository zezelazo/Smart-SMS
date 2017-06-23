using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Data {
  public class MessageDefinitionsRepository : GenericRepository<MessageDefinition>
  {
    public MessageDefinitionsRepository(DbContext context) : base(context)
    { }

    #region Overrides of GenericRepository<MessageDefinition>

    public override async Task<MessageDefinition> FindByKey(int id)
    {
      return await EntityFrameworkQueryableExtensions.Include<MessageDefinition, ICollection<StudentMessage>>(_dbSet, s => s.Students).ThenInclude(s => s.Smses)
                         .Include(s=>s.Students).ThenInclude(s=>s.Student).ThenInclude(s=>s.StudentInfo)
                         .SingleOrDefaultAsync(e => e.Id == id);                                        
    }

    #endregion
  }
}