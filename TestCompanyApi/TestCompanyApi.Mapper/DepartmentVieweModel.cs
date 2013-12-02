namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    public class DepartmentVieweModel
    {
        public int IdDepartment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CompanyId { get; set; }

        public int? AncestorDepartment_IdDepartment { get; set; }

        //public ICollection<DepartmentVieweModel> ChilDepartments { get; set; }
    }
}
