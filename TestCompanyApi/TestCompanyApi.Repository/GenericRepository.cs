using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TestCompanyApi
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = (EntityState)System.Data.EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            //var oldEntry = _context.Entry(entity);
            // var entry = _context.Entry(entity).CurrentValues.SetValues(entity);
            //_dbset.Attach(entity);
            //entry.State = (EntityState)System.Data.EntityState.Modified;

            _dbset.Find(entity);
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _dbset;
        }
    }
}
