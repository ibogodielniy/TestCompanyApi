﻿namespace TestCompanyApi.Services
{
    using System.Linq;

    public class CompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        private readonly IRepository<Department> _departmentRepository;

        public CompanyService()
        {
            IRepository<Company> compRepository = new Repository<Company>(new CompanyContext());
            IRepository<Department> depRepository = new Repository<Department>(new CompanyContext());
            new Repository<EmployeeAllocation>(new CompanyContext());

            this._departmentRepository = depRepository;
            this._companyRepository = compRepository;
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