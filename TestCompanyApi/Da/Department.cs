
namespace TestCompanyApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The department.
    /// </summary>
    [Table("Departments")]
    public class Department
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        public Department()
        {
            this.EmployeeAllocation = new HashSet<Employee>();
        }

        /// <summary>
        /// Gets or sets the employee allocation.
        /// </summary>
        public ICollection<Employee> EmployeeAllocation { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent department.
        /// </summary>
        public Department ParentDepartment { get; set; }
    }
}
