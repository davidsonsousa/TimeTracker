using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException("Repository - Context");
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetValidRecords().ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, int count = 0)
        {
            IQueryable<TEntity> recods = GetValidRecords();

            if (filter != null)
            {
                recods = recods.Where(filter);
            }

            if (count > 0)
            {
                recods = recods.Take(count);
            }

            return recods;
        }

        public IEnumerable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> records = GetValidRecords();

            if (filter != null)
            {
                records = records.Where(filter);
            }

            return records.ToList();
        }

        public TEntity GetById(int id)
        {
            return Get(q => q.Id == id).SingleOrDefault();
        }

        public TEntity GetById(Guid id)
        {
            return Get(q => q.VanityId == id).SingleOrDefault();
        }

        public void Insert(TEntity entity)
        {
            if (entity != null)
            {
                Context.Set<TEntity>().Add(entity);
            }
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                Context.Set<TEntity>().AddRange(entities);
            }
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                Context.UpdateRange(entities);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                Context.Remove(entity);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                Context.RemoveRange(entities);
            }
        }

        private void Attach(TEntity entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
        }

        private IQueryable<TEntity> GetValidRecords()
        {
            return Context.Set<TEntity>().Where(q => q.IsDeleted == false);
        }
    }
}
