
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;
    
    public class EmployeeViewModel
    {
        
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
