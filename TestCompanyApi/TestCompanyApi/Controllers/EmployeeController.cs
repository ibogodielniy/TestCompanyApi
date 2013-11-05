namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;

    public class EmployeeController : ApiController
    {
        ViewModel vm = new ViewModel();
        private readonly EmployeeService _service;

        private EmployeeController()
        {
            var service = new EmployeeService(new Repository<Employee>(new CompanyContext()));
            this._service = service;
        }

        // GET api/employee
        public IEnumerable<EmployeeViewModel> Get()
        {
            return this.vm.GetEmployeeViewModels(this._service.GetAllEmployees());
        }

        // GET api/employee/5
        public EmployeeViewModel Get(int id)
        {
            return this.vm.GetEmployeeViewModel(this._service.GetEmployeeById(id));
        }

        // POST api/employee
        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]Employee employee)
        {
            this._service.PostEmployee(employee);
        }

        // PUT api/employee/5
        [System.Web.Mvc.HttpPut]
        public void Put(int id, [FromBody]Employee employee)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.PutEmployee(id, employee);
            }
        }

        // DELETE api/employee/5        
        public void Delete(int id)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.DeleteEmployee(id);
            }
        }
    }
}
