
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    /// <summary></summary>
    public class DepartmentVieweModel
    {
        public DepartmentVieweModel()
        {
            Mapper.CreateMap<Department, DepartmentVieweModel>();
        }

        /// <summary></summary>
        public ICollection<EmployeeViewModel> EmployeeAllocation { get; set; }

        /// <summary></summary>
        public int IdDepartment { get; set; }

        /// <summary></summary>
        public string Name { get; set; }

        /// <summary></summary>
        public string Description { get; set; }

        /// <summary></summary>
        public DepartmentVieweModel AncestorDepartment { get; set; }

        /// <summary></summary>
        public int CompanyId { get; set; }

        /// <summary></summary>
        //public virtual DepartmentVieweModel AncestorCompany { get; set; }

        public DepartmentVieweModel GetDepartmentVieweModel(Department department)
        {
            return Mapper.Map<Department, DepartmentVieweModel>(department);
        }
    }
}

