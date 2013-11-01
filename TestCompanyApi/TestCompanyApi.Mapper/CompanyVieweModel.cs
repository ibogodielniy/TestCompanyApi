
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    /// <summary></summary>
    public class CompanyVieweModel
    {
        /// <summary></summary>
        public ICollection<DepartmentVieweModel> Departments { get; set; }

        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public string Name { get; set; }

        /// <summary></summary>
        public string Description { get; set; }
    }
}
