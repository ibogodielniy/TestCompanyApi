namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;

    public class EmployeeController : ApiController
    {
        private ViewModel vm = new ViewModel();
        private readonly EmployeeService _service;

        private EmployeeController()
        {
            var service = new EmployeeService(new Repository<Employee>(new CompanyContext()), new Repository<Department>(new CompanyContext()));
            this._service = service;
        }

        //GET api/employee
        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return this.vm.GetEmployeeViewModels(this._service.GetAllEmployees());
        }

        public IEnumerable<EmployeeViewModel> GetEmployeeByDepartments(int id)
        {
            return this.vm.GetEmployeeViewModels(this._service.GetEmployeesByDept(id));
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

        [System.Web.Http.HttpOptions]
        public void Options()
        {
            //httpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE, PUT");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With");
        }
    }
}
