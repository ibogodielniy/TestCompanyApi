namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;

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

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Employee")]
        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return this.vm.GetEmployeeViewModels(this._service.GetAllEmployees());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetEmployeeByDepartments")]
        public IEnumerable<EmployeeViewModel> GetEmployeeByDepartments(int id)
        {
            return this.vm.GetEmployeeViewModels(this._service.GetEmployeesByDept(id));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Employee")]
        public EmployeeViewModel Get(int id)
        {
            return this.vm.GetEmployeeViewModel(this._service.GetEmployeeById(id));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Employee")]
        public void Post([FromBody]EmployeeViewModel employee)
        {
            this._service.PostEmployee(this.vm.GetEmployeeFromViewModel(employee));
        }

        [System.Web.Http.ActionName("Employee")]
        [System.Web.Http.HttpPut]
        public void Put(int id, [FromBody]EmployeeViewModel employee)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.PutEmployee(id, this.vm.GetEmployeeFromViewModel(employee));
            }
        }

        [System.Web.Http.ActionName("Employee")]
        public void Delete(int id)
        {
            if (this._service.GetEmployeeById(id) != null)
            {
                this._service.DeleteEmployee(id);
            }
        }

        [System.Web.Http.HttpOptions]
        [System.Web.Http.ActionName("Employee")]
        public void Options()
        {
            //httpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE, PUT");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With");
        }
    }
}
