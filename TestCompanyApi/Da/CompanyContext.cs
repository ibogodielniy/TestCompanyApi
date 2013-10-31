
namespace TestCompanyApi
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The company context.
    /// </summary>
    public class CompanyContext : DbContext, ICompanyContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyContext"/> class.
        /// </summary>
        public CompanyContext() :
            base("MyConnection")
        {
            Database.SetInitializer<CompanyContext>(null); 
        }
        
        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Set<T>().Where(predicate);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
            this.Commit();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Update<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            this.Commit();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Remove<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            this.Commit();
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().
              HasMany(c => c.EmployeeAllocation).
              WithMany(p => p.DepartmentAllocation).
              Map(
               m =>
               {
                   m.MapLeftKey("IdEmployee");
                   m.MapRightKey("IdDepartmant");
                   m.ToTable("EmployeeAllocation");
               });
        }
    }
}
