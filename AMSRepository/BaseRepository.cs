using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AMSRepository.Models;
namespace AMSRepository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        internal AMSEntities context;
        internal DbSet<TEntity> dbSet;
        public BaseRepository()
        {
            this.context = new AMSEntities();
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();          
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return dbSet.ToList<TEntity>();
        }

        public virtual TEntity GetByID(int id)
        {
            return dbSet.Find(id);
        }
    }

}
