using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TestCompanyApi;

namespace TestCompanyApi
{

    public class Repository<TItem> : IRepository<TItem> where TItem : class
    {
        private ICompanyContext _context;

        public Repository(ICompanyContext context)
        {
            _context = context;
        }

        public virtual void Add(TItem entity)
        {
            _context.Add(entity);
        }

        public virtual void Delete(TItem entity)
        {
            _context.Remove(entity);
        }

        public virtual void Update(TItem entity)
        {
            _context.Update(entity);
        }

        public IEnumerable<TItem> Find(Expression<Func<TItem, bool>> predicate)
        {
            return _context.Find(predicate);
        }
    }
}
