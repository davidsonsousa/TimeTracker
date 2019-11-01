using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTracker.Infrastructure.Repositories
{
    internal interface IDataModificationRangeRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inserts multiple records
        /// </summary>
        /// <param name="entities"></param>
        Task InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates multiple records
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes multiple records
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}