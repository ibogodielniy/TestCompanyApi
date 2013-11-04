namespace TestCompanyApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Departments")]
    public class Department
    {
        public Department()
        {
            this.EmployeeAllocation = new HashSet<Employee>();
        }

        public ICollection<Employee> EmployeeAllocation { get; set; }

        public int IdDepartment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Department AncestorDepartment { get; set; }

        public int CompanyId { get; set; }

        public virtual Company AncestorCompany { get; set; }
    }
}
