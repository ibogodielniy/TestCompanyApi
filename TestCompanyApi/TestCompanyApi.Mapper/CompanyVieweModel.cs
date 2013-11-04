
namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    /// <summary></summary>
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            Mapper.CreateMap<Company, CompanyViewModel>();
        }

        /// <summary></summary>
        public ICollection<DepartmentVieweModel> Departments { get; set; }

        /// <summary></summary>
        public int Id { get; set; }

        /// <summary></summary>
        public string Name { get; set; }

        /// <summary></summary>
        public string Description { get; set; }

        public CompanyViewModel GetCompanyViewModel(Company company)
        {
            return Mapper.Map<Company, CompanyViewModel>(company);
        }
    }
}
