namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public class DepartmentVieweModel
    {
        public DepartmentVieweModel()
        {
            Mapper.CreateMap<Department, DepartmentVieweModel>()
                .ForMember(
                    d => d.EmployeeAllocation,
                    o => o.MapFrom(q => Mapper.Map<ICollection<Employee>, ICollection<EmployeeViewModel>>(q.EmployeeAllocation)));
        }

        public ICollection<Employee> EmployeeAllocation { get; set; }

        public int IdDepartment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DepartmentVieweModel AncestorDepartment { get; set; }

        public int CompanyId { get; set; }

        public DepartmentVieweModel GetDepartmentVieweModel(Department department)
        {
            return Mapper.Map<Department, DepartmentVieweModel>(department);
        }
    }
}
