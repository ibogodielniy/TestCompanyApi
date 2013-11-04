namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public class DepartmentVieweModel
    {
        ////public virtual ICollection<EmployeeViewModel> EmployeeAllocation { get; set; }

        public int IdDepartment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        ////public Department AncestorDepartment { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Department> ChilDepartments { get; set; }

        public DepartmentVieweModel GetDepartmentVieweModel(Department department)
        {
            return Mapper.Map<Department, DepartmentVieweModel>(department);
        }
    }
}
