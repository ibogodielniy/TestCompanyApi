namespace TestCompanyApi.Services
{
    using System.Linq;

    public class CompanyRESTService
    {
        private readonly IRepository<Company> _companyRepository;

        private readonly IRepository<Department> _departmentRepository;

        public CompanyRESTService()
        {
            IRepository<Company> compRepository = new Repository<Company>(new CompanyContext());
            IRepository<Department> depRepository = new Repository<Department>(new CompanyContext());
            new Repository<EmployeeAllocation>(new CompanyContext());

            this._departmentRepository = depRepository;
            this._companyRepository = compRepository;
        }
        
        #region GetById
        
        public Company GetCompanyById(int id)
        {
           return this._companyRepository.Find(c => c.Id == id).FirstOrDefault();
        }
       
        public Department GetDepartmentsById(int id)
        {
            return this._departmentRepository.Find(d => d.IdDepartment == id).FirstOrDefault();
        }

        #endregion

        #region Put
        
        public void PutCompany(int id, Company correctedCompany)
        {
            Company company = this.GetCompanyById(id);
            if (company != null)
            {
                correctedCompany.Id = id;
            }

            this._companyRepository.Update(correctedCompany);
        }

        public void PutDepartment(int id, Department correctedDepartment)
        {
            Department department = this.GetDepartmentsById(id);
            if (department != null)
            {
                correctedDepartment.IdDepartment = id;
            }

            this._departmentRepository.Update(correctedDepartment);
        }

        #endregion

        #region Post
        
        public void PostCompany(Company company)
        {
            if (company != null)
            {
                this._companyRepository.Add(company);
            }
        }

        public void PostDepartment(Department department)
        {
            if (department != null)
            {
                this._departmentRepository.Add(department);
            }
        }

        #endregion

        #region Delete

        public void DeleteCompany(int id)
        {
            var company = new Company { Id = id };
            this._companyRepository.Delete(company);
        }

        public void DeleteDepartment(int id)
        {
            var department = new Department { IdDepartment = id };
            this._departmentRepository.Delete(department);
        }
        
        #endregion
        }
}
