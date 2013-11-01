
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    /// <summary></summary>
    public class EmployeeViewModel
    {
        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public ICollection<DepartmentVieweModel> DepartmentAllocation { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>LastName</summary>
        public string LastName { get; set; }

        /// <summary>Description</summary>
        public string Description { get; set; }
    }
}
