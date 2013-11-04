namespace TestCompanyApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
