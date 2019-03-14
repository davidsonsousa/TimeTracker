using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;

namespace TimeTracker.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Attendance> Attendances { get; }
        IRepository<Calendar> Calendars { get; }
        IRepository<Holiday> Holidays { get; }
        IRepository<Project> Projects { get; }
        IRepository<Ticket> Tickets { get; }

        /// <summary>
        /// Get repository according to the type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseModel;

        /// <summary>
        /// Get repository according to the type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepositoryMany<TEntity> GetRepositoryMany<TEntity>() where TEntity : class;

        /// <summary>
        /// Saves all pending changes into the database
        /// </summary>
        void Save();
    }
}
