namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    public class CompanyViewModel
    {
        public ICollection<DepartmentVieweModel> Departments { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
