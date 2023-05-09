using EMS.data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Concrete.EFCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    { 
    public void Create(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }

    public List<TEntity> GetAll()
    {
        using (var context = new TContext())
        {
            return context.Set<TEntity>().ToList();
        }
    }

    public TEntity GetById(int id)
    {
        using (var context = new TContext())
        {
            var T = context.Set<TEntity>().Find(id);
            return T;
        }
    }

    public void Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
    
    }
}
