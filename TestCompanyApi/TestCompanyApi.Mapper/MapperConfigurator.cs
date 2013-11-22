

namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    using AutoMapper;

    public class MapperConfigurator
    {
        public static void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>(); 
            Mapper.CreateMap<Department, DepartmentVieweModel>().ForMember(d => d.ChilDepartments,o => o.MapFrom(q => Mapper.Map<ICollection<Department>, ICollection<DepartmentVieweModel>>(q.ChilDepartments)));
            ////.ForMember(d => d.EmployeeAllocation, o => o.MapFrom(q => Mapper.Map<ICollection<Employee>, ICollection<EmployeeViewModel>>(q.EmployeeAllocation)));
            Mapper.CreateMap<Company, CompanyViewModel>().ForMember(d => d.Departments, o => o.MapFrom(src => src.Departments));
        }
    }
}
