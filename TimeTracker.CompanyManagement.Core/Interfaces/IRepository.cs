﻿using System.Collections.Generic;

namespace TimeTracker.CompanyManagement.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> List();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
