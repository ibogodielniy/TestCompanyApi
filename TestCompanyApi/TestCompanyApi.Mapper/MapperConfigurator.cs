

namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    using AutoMapper;

    public class MapperConfigurator
    {
        public static void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
  
            Mapper.CreateMap<Department, DepartmentVieweModel>(); 

            Mapper.CreateMap<Company, CompanyViewModel>().ForMember(d => d.Departments, o => o.MapFrom(src => src.Departments));

            Mapper.CreateMap<EmployeeViewModel, Employee>(); 

            Mapper.CreateMap<DepartmentVieweModel, Department>();

            Mapper.CreateMap<CompanyViewModel, Company>();
        }
    }
}
