using System.Data.Entity;

namespace TestCompanyApi
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }

        public CompanyContext() :
            base("Data Source=(local);Initial Catalog=CompanyTestDB;User ID=sasa;Password=qwe123")
        {
            Database.SetInitializer<CompanyContext>(new CreateDatabaseIfNotExists<CompanyContext>());
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
    }
}
