﻿
namespace TestCompanyApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The company structure service.
    /// </summary>
    public class CompanyRESTService
    {
        /// <summary>
        /// The context.
        /// </summary>
        private CompanyContext _context;

        /// <summary>
        /// The company repository.
        /// </summary>
        private IRepository<Company> _companyRepository;

        /// <summary>
        /// The department repository.
        /// </summary>
        private IRepository<Department> _departmentRepository;

        /// <summary>
        /// The employee allocation repository.
        /// </summary>
        private IRepository<EmployeeAllocation> _employeeAllocationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRESTService"/> class.
        /// </summary>
        public CompanyRESTService()
        {
            IRepository<Company> compRepository = new Repository<Company>(new CompanyContext());
            IRepository<Department> depRepository = new Repository<Department>(new CompanyContext());
            IRepository<EmployeeAllocation> employeeAllocationRepository = new Repository<EmployeeAllocation>(new CompanyContext());

            this._departmentRepository = depRepository;
            this._companyRepository = compRepository;
            
        }
        
        #region GetById

        /// <summary>
        /// The get company by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        public Company GetCompanyById(int id)
        {
           return this._companyRepository.Find(c => c.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The get departments by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Department"/>.
        /// </returns>
        public Department GetDepartmentsById(int id)
        {
            return this._departmentRepository.Find(d => d.IdDepartment == id).FirstOrDefault();
        }

        #endregion

        #region Put

        /// <summary>
        /// The put company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="correctedCompany">
        /// The corrected company.
        /// </param>
        public void PutCompany(int id, Company correctedCompany)
        {
            Company company = this.GetCompanyById(id);
            if (company != null)
            {
                correctedCompany.Id = id;
            }

            this._companyRepository.Update(correctedCompany);
            this._context.SaveChanges();
        }

        /// <summary>
        /// The put department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="correctedDepartment">
        /// The corrected department.
        /// </param>
        public void PutDepartment(int id, Department correctedDepartment)
        {
            Department department = this.GetDepartmentsById(id);
            if (department != null)
            {
                correctedDepartment.IdDepartment = id;
            }

            this._departmentRepository.Update(correctedDepartment);
            this._context.SaveChanges();
        }

        #endregion

        #region Post

        /// <summary>
        /// The post company.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        public void PostCompany(Company company)
        {
            if (company != null)
            {
                this._companyRepository.Add(company);
            }

            this._context.SaveChanges();
        }

        /// <summary>
        /// The post department.
        /// </summary>
        /// <param name="department">
        /// The department.
        /// </param>
        public void PostDepartment(Department department)
        {
            if (department != null)
            {
                this._departmentRepository.Add(department);
            }

            this._context.SaveChanges();
        }

        #endregion

        #region Delete

        /// <summary>
        /// The delete company.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteCompany(int id)
        {
            var company = new Company { Id = id };
            this._companyRepository.Delete(company);
            this._context.SaveChanges();
        }

        /// <summary>
        /// The delete department.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteDepartment(int id)
        {
            var department = new Department { IdDepartment = id };
            this._departmentRepository.Delete(department);
            this._context.SaveChanges();
        }
        
        #endregion
        }
}