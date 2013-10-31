using System.Collections.Generic;
using System.Linq;

namespace TestCompanyApi.Services
{
    public class CompanyStructureService
    {
        private CompanyContext _context;
        private IRepository<Company> _companyRepository;
        private IRepository<Department> _departmentRepository;
        private IRepository<EmployeeAllocation> _employeeAllocationRepository;

        public CompanyStructureService()
        {
            IRepository<Company> compRepository = new Repository<Company>(new CompanyContext());
            IRepository<Department> depRepository = new Repository<Department>(new CompanyContext());
            IRepository<EmployeeAllocation> employeeAllocationRepository = new Repository<EmployeeAllocation>(new CompanyContext());

            _departmentRepository = depRepository;
            _companyRepository = compRepository;
            
        }
        
        #region GetById

        public Company GetCompanyById(int id)
        {
            IEnumerable<Company> companies = _companyRepository.Find(c => c.id == id);
            var sameId = new Company();

            if (companies != null)
            {
                foreach (var company in companies.Where(company => company.id == id))
                    sameId = company;
            }
            return sameId;
        }

        public Department GetDepartmentsById(int id)
        {
            IEnumerable<Department> departments = _departmentRepository.Find(d => d.id == id);
            var sameId = new Department();

            if (departments != null)
            {
                foreach (var department in departments.Where(department => department.id == id))
                    sameId = department;
            }
            return sameId;
        }

        #endregion

        #region Put

        public void PutCompany(int id, Company correctedCompany)
        {
            Company company = GetCompanyById(id);
            if (company != null)
                correctedCompany.id = id;
            _companyRepository.Update(correctedCompany);
            _context.SaveChanges();
        }

        public void PutDepartment(int id, Department correctedDepartment)
        {
            Department department = GetDepartmentsById(id);
            if (department != null) correctedDepartment.id = id;
            _departmentRepository.Update(correctedDepartment);
            _context.SaveChanges();
        }

        #endregion

        #region Post

        public void PostCompanie(Company company)
        {
            if (company != null)
                _companyRepository.Add(company);
            _context.SaveChanges();
        }

        public void PostDepartment(Department department)
        {
            if (department != null)
                _departmentRepository.Add(department);
            _context.SaveChanges();
        }

        #endregion

        #region Delete

        public void DeleteCompanie(int id)
        {
            var company = new Company { id = id };
            _companyRepository.Delete(company);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = new Department { id = id };
            _departmentRepository.Delete(department);
            _context.SaveChanges();
        }

        #endregion

        
    }
}
