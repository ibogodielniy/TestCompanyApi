namespace TestCompanyApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeService
    {
        private IRepository<Employee> _repository;

        private IRepository<Department> _depRepository;


        public EmployeeService(IRepository<Employee> repository, IRepository<Department> depRepository)
        {
            this._repository = repository;
            this._depRepository = depRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this._repository.Find(e => true);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._repository.Find(e => e.Id == id).FirstOrDefault();
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

        public IEnumerable<Employee> GetEmployeesByDept(int depId)
        {
            return this._depRepository.Find(d => d.IdDepartment == depId).SelectMany(d => d.EmployeeAllocation);
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
