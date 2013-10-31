using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TestCompanyApi
{
    [Table("Employees")]
    public class Employee 
    {
        public ICollection<Department> DepartmentAllocation { get; set; }

        public Employee()
        {
            DepartmentAllocation = new HashSet<Department>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        [Column("EmployeeName")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column("EmployeeLastName")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Column("EmployeeDiscription")]
        [MaxLength(20)]
        public string Description { get; set; }
        
    }
}
