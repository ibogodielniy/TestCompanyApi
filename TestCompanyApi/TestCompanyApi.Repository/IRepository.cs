using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq.Expressions;

namespace TestCompanyApi
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
