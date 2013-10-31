
namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using TestCompanyApi.Services;

    /// <summary>
    /// The employee controller.
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// The _service.
        /// </summary>
        private EmployeeService _service;

        /// <summary>
        /// Prevents a default instance of the <see cref="EmployeeController"/> class from being created.
        /// </summary>
        private EmployeeController()
        {
            var service = new EmployeeService(new Repository<Employee>(new CompanyContext()));
            this._service = service;
        }

        // GET api/employee

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Employee> Get()
        {
            return this._service.GetAllEmployees();
        }

        // GET api/employee/5

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Employee"/>.
        /// </returns>
        public Employee Get(int id)
        {
            return this._service.GetEmployeeById(id);
        }

        // POST api/employee

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]Employee employee)
        {
            this._service.PostEmployee(employee);
        }

        // PUT api/employee/5

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="employee">
        /// The employee.
        /// </param>
        [System.Web.Mvc.HttpPut]
        public void Put(int id, [FromBody]Employee employee)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.PutEmployee(id, employee);
            }
        }

        // DELETE api/employee/5

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.DeleteEmployee(id);
            }
        }
    }
}
