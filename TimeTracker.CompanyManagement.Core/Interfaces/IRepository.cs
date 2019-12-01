using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTracker.CompanyManagement.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> ListAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
