using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;


namespace TestCompanyApi
{
    public class CompanyContext: DbContext , ICompanyContext
    {
        public CompanyContext() :
            base("MyConnection")
        {
            Database.SetInitializer<CompanyContext>(null); //new CreateDatabaseIfNotExists<CompanyContext>()
        }
        
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

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Set<T>().Where(predicate);
        }

        public void Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
            Commit();
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            Commit();
        }

        public void Remove<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            Commit();
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
