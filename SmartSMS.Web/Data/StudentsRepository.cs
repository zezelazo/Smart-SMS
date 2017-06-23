using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Data {
  public class StudentsRepository : GenericRepository<Student>
  {
    public StudentsRepository(DbContext context) : base(context)
    { }

    #region Overrides of GenericRepository<Student>

    public override async Task<Student> FindByKey(int id)
    {
      return await EntityFrameworkQueryableExtensions.Include<Student, Contact>(_dbSet, s => s.StudentInfo)
                         .Include(s => s.FatherInfo)
                         .Include(s => s.MotherInfo)
                         .Include(s => s.Messages).ThenInclude(s => s.Smses)
                         .SingleOrDefaultAsync(e => e.Id == id);

    }

    #endregion
  }
}