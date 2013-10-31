
namespace TestCompanyApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The CompanyContext interface.
    /// </summary>
    public interface ICompanyContext
    {
        /// <summary>
        /// The find method.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// The add method.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        void Add<T>(T entity) where T : class;

        /// <summary>
        /// The update method.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// The remove method.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        void Remove<T>(T entity) where T : class;

        /// <summary>
        /// The commit method.
        /// </summary>
        void Commit();
    }
}
