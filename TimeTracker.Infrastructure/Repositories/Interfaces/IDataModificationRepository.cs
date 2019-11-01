﻿using System.Threading.Tasks;

namespace TimeTracker.Infrastructure.Repositories
{
    internal interface IDataModificationRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inserts a record
        /// </summary>
        /// <param name="entity"></param>
        Task Insert(TEntity entity);

        /// <summary>
        /// Updates record
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes record from database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}