using System;
using System.Collections.Generic;
using AutoMapper.Mappers;

namespace TestCompanyApi.Services
{
    using TestCompanyApi.Mapper;

    class EmployeeViewModel
    {
        public int Id { get; set; }

        public virtual ICollection<DepartmentVieweModel> DepartmentAllocation { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public EmployeeViewModel GetEmployeeViewModel(Employee employee)
        {
            return AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employee);
        }
    }
}
