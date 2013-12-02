namespace TestCompanyApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> EmployeeAllocation { get; set; }

        public virtual ICollection<Department> ChilDepartments { get; set; }
        
        [Key]
        public int IdDepartment { get; set; }

        public virtual Department AncestorDepartment { get; set; }

        public int? AncestorDepartment_IdDepartment { get; set; }

        public int CompanyId { get; set; }

        public virtual Company AncestorCompany { get; set; }
    }
}
