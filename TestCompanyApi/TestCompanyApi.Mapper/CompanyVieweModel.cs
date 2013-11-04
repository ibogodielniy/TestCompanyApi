namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    using AutoMapper;
    
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            Mapper.CreateMap<Company, CompanyViewModel>();
        }

        public ICollection<DepartmentVieweModel> Departments { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CompanyViewModel GetCompanyViewModel(Company company)
        {
            return Mapper.Map<Company, CompanyViewModel>(company);
        }
    }
}
