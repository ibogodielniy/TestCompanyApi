
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    /// <summary></summary>
    public class EmployeeViewModel
    {
        private EmployeeViewModel()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
        }

        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        //public ICollection<DepartmentVieweModel> DepartmentAllocation { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>LastName</summary>
        public string LastName { get; set; }

        /// <summary>Description</summary>
        public string Description { get; set; }

        EmployeeViewModel GetEmployeeViewModel(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeViewModel>(employee);
        }
    }
}
