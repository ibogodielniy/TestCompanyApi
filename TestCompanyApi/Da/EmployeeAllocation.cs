
namespace TestCompanyApi
{
    using System.Data.Entity;
    
    /// <summary>
    /// The employee allocation.
    /// </summary>
    public class EmployeeAllocation
    {
        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}
