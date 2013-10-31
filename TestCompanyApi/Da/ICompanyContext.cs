using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestCompanyApi
{
    public interface ICompanyContext
    {
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Commit();
    }
}
