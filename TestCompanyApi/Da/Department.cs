namespace TestCompanyApi
{
    using System.Collections.Generic;

    public class Department
    {
        public Department()
        {
            this.EmployeeAllocation = new HashSet<Employee>();
        }

        public virtual ICollection<Employee> EmployeeAllocation { get; set; }

        public ICollection<Department> ChilDepartments { get; set; }

        public int IdDepartment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Department AncestorDepartment { get; set; }

        public int? AncestorDepartment_IdDepartment { get; set; }

        public int CompanyId { get; set; }

        public virtual Company AncestorCompany { get; set; }
    }
}
