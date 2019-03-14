﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.Repositories
{
    internal class EfRepositoryMany<T> : IRepositoryMany<T> where T : class
    {
        private readonly TimeTrackerContext _context;
        private readonly DbSet<T> _dbSet;
        private bool _disposed;

        public EfRepositoryMany()
        {

        }

        public EfRepositoryMany(TimeTrackerContext context)
        {
            _context = context ?? throw new ArgumentNullException("Repository - Context");
            _dbSet = context.Set<T>();
        }

        public void InsertMany(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                _dbSet.AddRange(entities);
            }
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                _context.UpdateRange(entities);
            }
        }

        public void DeleteMany(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                _context.RemoveRange(entities);
            }
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
