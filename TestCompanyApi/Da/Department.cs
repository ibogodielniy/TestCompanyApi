using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TestCompanyApi
{
    [Table("Departments")]
    public class Department 
    {
        public ICollection<Employee> EmployeeAllocation { get; set; }

        public Department()
        {
            EmployeeAllocation = new HashSet<Employee>();
        }

        [Key]
        public int id{get; set;}

        public string Name{get;set;}

        public string Description{get;set;}

        public Department ParentDepartment{get;set;}
    }
}
