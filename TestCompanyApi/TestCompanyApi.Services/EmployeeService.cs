
namespace TestCompanyApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The employee service.
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        /// The _repository.
        /// </summary>
        private IRepository<Employee> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public EmployeeService(IRepository<Employee> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// The get all employees.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Employee> GetAllEmployees()
        {
            return null;
        }

        /// <summary>
        /// The get employee by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Employee"/>.
        /// </returns>
        public Employee GetEmployeeById(int id)
        {
            return this._repository.Find(e => e.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The get employees by last name.
        /// </summary>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
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

        /// <summary>
        /// The get employees by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
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

        /// <summary>
        /// The put employee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="correctedEmployee">
        /// The corrected employee.
        /// </param>
        public void PutEmployee(int id, Employee correctedEmployee)
        {
            Employee emp = this.GetEmployeeById(id);
            if (emp != null)
            {
                correctedEmployee.Id = id;
            }

            this._repository.Update(correctedEmployee);
        }

        /// <summary>
        /// The post employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        public void PostEmployee(Employee employee)
        {
            if (employee != null)
            {
                this._repository.Add(employee);
            }
        }

        /// <summary>
        /// The delete employee.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteEmployee(int id)
        {
            var employee = new Employee { Id = id };
            this._repository.Delete(employee);
        }
    }
}
