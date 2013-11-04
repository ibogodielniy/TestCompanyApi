namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    using AutoMapper;

    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            Mapper.CreateMap<Company, CompanyViewModel>().ForMember(d => d.Departments, o => o.MapFrom(src => src.Departments));
        }

        public ICollection<Department> Departments { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CompanyViewModel GetCompanyViewModel(Company company)
        {
            return Mapper.Map<Company, CompanyViewModel>(company);
        }
    }
}
