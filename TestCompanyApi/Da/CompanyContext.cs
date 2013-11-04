namespace TestCompanyApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class CompanyContext : DbContext, ICompanyContext
    {
        public CompanyContext() :
            base("MyConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CompanyContext>());
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Set<T>().Where(predicate);
        }

        public void Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
            this.Commit();
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            var key = this.GetPrimaryKey(entry);

            if (entry.State == EntityState.Detached)
            {
                var currentEntry = this.Set<T>().Find(key);
                if (currentEntry != null)
                {
                    var attachedEntry = this.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    this.Set<T>().Attach(entity);
                    entry.State = EntityState.Modified;
                }

                this.Commit();
            }
        }

        public void Remove<T>(int key) where T : class
        {
            var entity = Set<T>().Find(key);
            var entry = this.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
                this.Set<T>().Remove(entity);
                this.Commit();
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            var key = this.GetPrimaryKey(entry);
            if (this.Set<T>().Find(key) != null)
            {
                this.Set<T>().Remove(entity);
                this.Set<T>().Remove(this.Set<T>().Find(key));
                this.Commit();
            }
        }

        public void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(c => c.EmployeeAllocation).WithMany(p => p.DepartmentAllocation).Map(
               m =>
               {
                   m.MapLeftKey("IdEmployee");
                   m.MapRightKey("IdDepartmant");
                   m.ToTable("EmployeeAllocation");
               });

            modelBuilder.Entity<Company>().HasKey(company => company.Id);
            modelBuilder.Entity<Department>().HasKey(department => department.IdDepartment);
            modelBuilder.Entity<Employee>().HasKey(employee => employee.Id);
        }
        
        private int GetPrimaryKey<T>(DbEntityEntry<T> entry) where T : class
        {
            var key = 0;
            var myObject = entry.Entity;
            var property = myObject.GetType().GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            if (property != null)
            {
                key = (int)property.GetValue(myObject, null);
            }

            return key;
        }
    }
}
