namespace TestCompanyApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeService
    {
        private IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this._repository.Find(e => true);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._repository.Find(e => e.Id == id).FirstOrDefault();
        }

        public List<Employee> GetEmployeesByLastName(string lastName)
        {
            IEnumerable<Employee> employees = this._repository.Find(e => e.LastName == lastName);
            var sameLastName = new List<Employee>();

            if (employees != null)
            {
                sameLastName.AddRange(employees.Where(employee => employee.LastName == lastName));
            }

            return sameLastName;
        }

        public List<Employee> GetEmployeesByName(string name)
        {
            IEnumerable<Employee> employees = this._repository.Find(e => e.Name == name);
            var sameName = new List<Employee>();

            if (employees != null)
            {
                sameName.AddRange(employees.Where(employee => employee.Name == name));
            }

            return sameName;
        }

        public void PutEmployee(int id, Employee correctedEmployee)
        {
            Employee emp = this.GetEmployeeById(id);
            if (emp != null)
            {
                correctedEmployee.Id = id;
            }

            this._repository.Update(correctedEmployee);
        }

        public void PostEmployee(Employee employee)
        {
            if (employee != null)
            {
                this._repository.Add(employee);
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = new Employee { Id = id };
            this._repository.Delete(employee);
        }
    }
}
