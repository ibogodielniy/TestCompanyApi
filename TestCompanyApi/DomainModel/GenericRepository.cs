
namespace TestCompanyApi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TItem">
    /// </typeparam>
    public class Repository<TItem> : IRepository<TItem> where TItem : class
    {

        /// <summary>
        /// The _context.
        /// </summary>
        private ICompanyContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TItem}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public Repository(ICompanyContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Add(TItem entity)
        {
            this._context.Add(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(TItem entity)
        {
            this._context.Remove(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(TItem entity)
        {
            this._context.Update(entity);
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<TItem> Find(Expression<Func<TItem, bool>> predicate)
        {
            return this._context.Find(predicate);
        }
    }
}
