
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;
    
    public class EmployeeViewModel
    {
        private EmployeeViewModel()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(
                d => d.DepartmentAllocation, 
                o => o.MapFrom(q => Mapper.Map<ICollection<Department>, ICollection<DepartmentVieweModel>>(q.DepartmentAllocation)));
        }

        public int Id { get; set; }

        public ICollection<Department> DepartmentAllocation { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        EmployeeViewModel GetEmployeeViewModel(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeViewModel>(employee);
        }
    }
}
