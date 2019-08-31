using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;

namespace TimeTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimeTrackerContext _ctx;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        public IBranchRepository Branches { get; private set; }
        public IHolidayRepository Holidays { get; private set; }
        public IRepository<Project> Projects { get { return GetRepository<Project>(); } }

        public UnitOfWork(TimeTrackerContext context, IBranchRepository branchRepository, IHolidayRepository holidayRepository)
        {
            _ctx = context;

            Branches = branchRepository;
            Holidays = holidayRepository;

            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseModel
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            // TODO: Make it flexible so it accepts other types of repository (example: ADO.NET, XML, JSON, etc.)
            var repository = new Repository<TEntity>(_ctx);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public IRepositoryMany<TEntity> GetRepositoryMany<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepositoryMany<TEntity>;
            }

            // TODO: Make it flexible so it accepts other types of repository (example: ADO.NET, XML, JSON, etc.)
            var repository = new RepositoryMany<TEntity>(_ctx);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Save()
        {
            try
            {
                _ctx.SaveChanges();
            }
            // TODO: Implement EF Core error handling
            //catch (DbEntityValidationException ex)
            //{
            //    // Retrieve the error messages as a list of strings.
            //    var errorMessages = ex.EntityValidationErrors
            //                            .SelectMany(x => x.ValidationErrors)
            //                            .Select(x => x.ErrorMessage);

            //    // Join the list to a single string.
            //    var fullErrorMessage = string.Join("; ", errorMessages);

            //    // Combine the original exception message with the new one.
            //    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            //    // Throw a new DbEntityValidationException with the improved exception message.
            //    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            //}
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.First().Reload();
            }
            catch
            {
                throw;
            }
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
