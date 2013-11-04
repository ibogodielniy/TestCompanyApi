namespace TestCompanyApi
{
    using System.Data.Entity;
    
    public class EmployeeAllocation
    {
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
