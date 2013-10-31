
namespace TestCompanyApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The employee domain class
    /// </summary>
    [Table("Employees")]
    public class Employee 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        public Employee()
        {
            this.DepartmentAllocation = new HashSet<Department>();
        }

        /// <summary>
        /// Gets or sets collection of Allocated to employee departments.
        /// </summary>
        public ICollection<Department> DepartmentAllocation { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [Column("EmployeeName")]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Column("EmployeeLastName")]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        [Column("EmployeeDiscription")]
        [MaxLength(20)]
        public string Description { get; set; }
        
    }
}
