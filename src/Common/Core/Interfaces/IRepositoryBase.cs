﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace amznStore.Common.Core.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
