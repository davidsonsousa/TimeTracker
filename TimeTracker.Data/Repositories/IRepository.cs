using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TimeTracker.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets item based on condition and includes extra table
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, int count = 0);

        /// <summary>
        /// Gets items based on condition for read-only
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetById(int id);

        TEntity GetById(Guid id);

        /// <summary>
        /// Inserts a record
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Inserts multiple records
        /// </summary>
        /// <param name="entities"></param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates record
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates multiple records
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes record from database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes multiple records
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
