using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TestCompanyApi.Services
{
    public class EmployeeService  
    {
        private IRepository<Employee> _repository;
        private DbContext _context;

        public EmployeeService(IRepository<Employee> repository, DbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _repository.FindAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            IEnumerable<Employee> employees = _repository.Find(e => e.id == id);
            var sameId = new Employee();

            if (employees != null)
            {
                foreach (var employee in employees.Where(employee => employee.id == id))
                    sameId = employee;
            }
            return sameId;
        }

        public List<Employee> GetEmployeesByLastName(string lastName)
        {
            IEnumerable<Employee> employees = _repository.Find(e => e.LastName == lastName);
            var sameLastName = new List<Employee>();

            if (employees != null)
            {
                sameLastName.AddRange(employees.Where(employee => employee.LastName == lastName));
            }
            return sameLastName;
        }

        public List<Employee> GetEmployeesByName(string name)
        {
            IEnumerable<Employee> employees = _repository.Find(e => e.Name == name);
            var sameName = new List<Employee>();

            if (employees != null)
            {
                sameName.AddRange(employees.Where(employee => employee.Name == name));
            }
            return sameName;
        }

        public void PutEmployee(int id, Employee correctedEmployee)
        {
            Employee emp = GetEmployeeById(id);
            if (emp != null)
                correctedEmployee.id = id;
                _repository.Update(correctedEmployee);
            _context.SaveChanges();
        }

        public void PostEmployee(Employee employee)
        {
            if (employee != null)
            _repository.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = new Employee {id = id};
            _repository.Delete(employee);
        }
    }
}
