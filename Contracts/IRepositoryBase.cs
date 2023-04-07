﻿using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        #region Methods

        IQueryable<T> FindAll(bool trackChanges);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        #endregion Methods
    }
}