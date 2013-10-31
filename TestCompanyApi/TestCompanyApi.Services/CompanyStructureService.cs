using System.Collections.Generic;
using System.Linq;

namespace TestCompanyApi.Services
{
    public class CompanyStructureService
    {
        private CompanyContext _context;
        private IRepository<Company> _compRepository;
        private IRepository<Department> _depRepository;

        public CompanyStructureService()
        {
            var context = new CompanyContext();
            IRepository<Company> compRepository = new Repository<Company>(_context);
            IRepository<Department> depRepository = new Repository<Department>(_context);

            _depRepository = depRepository;
            _compRepository = compRepository;
            _context = context;
        }

        #region Get

        public List<Company> GetAllCompanies()
        {
            return null;
        }

        public List<Department> GetAllDepartments()
        {
          return null;
        }

        #endregion

        #region GetById

        public Company GetCompanyById(int id)
        {
            IEnumerable<Company> companies = _compRepository.Find(c => c.id == id);
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
            IEnumerable<Department> departments = _depRepository.Find(d => d.id == id);
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
            _compRepository.Update(correctedCompany);
            _context.SaveChanges();
        }

        public void PutDepartment(int id, Department correctedDepartment)
        {
            Department department = GetDepartmentsById(id);
            if (department != null) correctedDepartment.id = id;
            _depRepository.Update(correctedDepartment);
            _context.SaveChanges();
        }

        #endregion

        #region Post

        public void PostCompanie(Company company)
        {
            if (company != null)
                _compRepository.Add(company);
            _context.SaveChanges();
        }

        public void PostDepartment(Department department)
        {
            if (department != null)
                _depRepository.Add(department);
            _context.SaveChanges();
        }

        #endregion

        #region Delete

        public void DeleteCompanie(int id)
        {
            var company = new Company { id = id };
            _compRepository.Delete(company);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = new Department { id = id };
            _depRepository.Delete(department);
            _context.SaveChanges();
        }

        #endregion
    }
}
