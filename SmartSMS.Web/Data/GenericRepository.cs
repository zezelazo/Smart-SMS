using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Data
{
  public class GenericRepository<TEntity> where TEntity : class
  {
    internal DbContext _context;
    internal DbSet<TEntity> _dbSet;
    internal const int PAGE_SIZE = 50;

    public GenericRepository(DbContext context)
    {
      _context = context;
      _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
      _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> All()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> All(int page = 1,int pagesize =PAGE_SIZE )
    {
      if(page<1) throw new ArgumentOutOfRangeException("page");
      if(pagesize<1) throw new ArgumentOutOfRangeException("pagesize");
      return await _dbSet.Skip(page-1).Take(pagesize).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate)
    {
      IEnumerable<TEntity> results = await _dbSet.Where(predicate).ToListAsync();
      return results;
    }

    public async Task<TEntity> FindByKey(int id)
    {
      Expression<Func<TEntity, bool>> lambda = BuildLambdaForFindByKey<TEntity>(id);
      return await _dbSet.SingleOrDefaultAsync(lambda);
    }
 
    public async void InsertOrUpdate(TEntity entity)
    {
      _context.ChangeTracker.TrackGraph (entity, e=>ApplyStateUsingIsKeySet(e.Entry));
      await _context.SaveChangesAsync();
    }

    public async void Delete(int id)
    {
      var entity = await FindByKey(id);
      _context.Entry(entity).State=EntityState.Deleted;
    }

    internal Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(int id)
    {
      var item = Expression.Parameter(typeof(TEntity), "entity");
      var prop = Expression.Property(item, "Id");//typeof(TEntity).Name + "Id");
      var value = Expression.Constant(id);
      var equal = Expression.Equal(prop, value);
      var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
      return lambda;
    }

    private static void ApplyStateUsingIsKeySet(EntityEntry entry)
    {
      if (entry.IsKeySet)
      {
        if (((ClientChangeTracker)entry.Entity).IsDirty) entry.State = EntityState.Modified;
        else entry.State = EntityState.Unchanged;
      }
      else
      {
        entry.State = EntityState.Added;
      }
    }
  }
}
