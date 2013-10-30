using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using TestCompanyApi.Services;

namespace TestCompanyApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService _service;

        private EmployeeController()
        {
            CompanyContext context = new CompanyContext();
            Repository<Employee> rep = new Repository<Employee>(context);
            EmployeeService service = new EmployeeService(rep, context);
            _service = service;
        }

        // GET api/employee
        public IEnumerable<Employee> Get()
        {
            return _service.GetAllEmployees();
        }

        // GET api/employee/5
        public Employee Get(int id)
        {
            return _service.GetEmployeeById(id);
        }

        // POST api/employee
        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]Employee employee)
        {
            _service.PostEmployee(employee);
        }

        // PUT api/employee/5
        [System.Web.Mvc.HttpPut]
        public void Put(int id, [FromBody]Employee employee)
        {
            if (_service.GetEmployeeById(id) != null)
                _service.PutEmployee(id, employee);
        }

        // DELETE api/employee/5
        public void Delete(int id)
        {
            if (_service.GetEmployeeById(id) != null)
                _service.DeleteEmployee(id);
        }
    }
}
