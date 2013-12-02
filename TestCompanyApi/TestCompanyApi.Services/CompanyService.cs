namespace TestCompanyApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        private readonly IRepository<Department> _departmentRepository;

        private readonly IRepository<EmployeeAllocation> _allocationRepository; 

        public CompanyService()
        {
            IRepository<Company> compRepository = new Repository<Company>(new CompanyContext());
            IRepository<Department> depRepository = new Repository<Department>(new CompanyContext());
            IRepository<EmployeeAllocation> allocRepository = new Repository<EmployeeAllocation>(new CompanyContext());

            this._departmentRepository = depRepository;
            this._companyRepository = compRepository;
            this._allocationRepository = allocRepository;
        }
        
        #region Find
        
        public Company FindCompanyById(int id)
        {
           return this._companyRepository.Find(c => c.Id == id).FirstOrDefault();
        }
       
        public Department FindDepartmentsById(int id)
        {
            return this._departmentRepository.Find(d => d.IdDepartment == id).FirstOrDefault();
        }

        public IEnumerable<EmployeeAllocation> GetEmployeeByDepartment(int id)
        {
            var dep = new Department() { IdDepartment = id };
            return this._allocationRepository.Find(d => d.Departments.Contains(dep)); 
                //Employees.Where(s => s.DepartmentAllocation.Contains(dep)));
        }

        public IEnumerable<Company> FindAllCompanies()
        {
            return this._companyRepository.Find(c => true);
        }

        public IEnumerable<Department> FindAllDepartments()
        {
            return this._departmentRepository.Find(d => true);
        }

        public IEnumerable<Department> FindAllCompanysDepartments(int id)
        {
            return this._departmentRepository.Find(d => d.CompanyId == id);
        }

        #endregion

        #region Edit
        
        public void EditCompany(int id, Company correctedCompany)
        {
            Company company = this.FindCompanyById(id);
            if (company != null)
            {
                correctedCompany.Id = id;
            }

            this._companyRepository.Update(correctedCompany);
        }

        public void EditDepartment(int id, Department correctedDepartment)
        {
            Department department = this.FindDepartmentsById(id);
            if (department != null)
            {
                correctedDepartment.IdDepartment = id;
            }

            this._departmentRepository.Update(correctedDepartment);
        }

        //public void PutEmployee(int id, Employee correctedEmployee)
        //{
        //    Employee emp = this.GetEmployeeById(id);
        //    if (emp != null)
        //    {
        //        correctedEmployee.Id = id;
        //    }

        //    this._repository.Update(correctedEmployee);
        //}

        #endregion

        #region Add
        
        public void AddCompany(Company company)
        {
            if (company != null)
            {
                this._companyRepository.Add(company);
            }
        }

        public void AddDepartment(Department department)
        {
            if (department != null)
            {
                this._departmentRepository.Add(department);
            }
        }

        #endregion

        #region Remove

        public void RemoveCompany(int id)
        {
            var company = new Company { Id = id };
            this._companyRepository.Delete(company);
        }

        public void RemoveDepartment(int id)
        {
            var department = new Department { IdDepartment = id };
            this._departmentRepository.Delete(department);
        }
        
        #endregion
        }
}
