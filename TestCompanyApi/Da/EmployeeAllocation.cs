namespace TestCompanyApi
{
    using System.Data.Entity;
    
    public class EmployeeAllocation
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
