namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;

    public class DepartmentController : ApiController
    {
        private readonly CompanyService _service;

        private DepartmentController()
        {
            var service = new CompanyService();
            this._service = service;
        }

        public ViewModel dw = new ViewModel();


        [System.Web.Mvc.HttpGet]
        [ActionName("GetDepartments")]
        public IEnumerable<DepartmentVieweModel> GetDepartments()
        {
            return this.dw.GetDepartmentsViewModels(this._service.FindAllDepartments());
        }

        [System.Web.Mvc.HttpGet]
        [ActionName("GetDepartments")]
        public DepartmentVieweModel GetDepartments(int id)
        {
            return this.dw.GetDepartmentVieweModel(this._service.FindDepartmentsById(id));
        }

        [System.Web.Mvc.HttpGet]
        [ActionName("GetDepartmentsByCompany")]
        public IEnumerable<DepartmentVieweModel> GetDepartmentsByCompany(int id)
        {
            return this.dw.GetDepartmentsViewModels(this._service.FindAllCompanysDepartments(id));
        }

        [System.Web.Mvc.HttpDelete]
        [ActionName("GetDepartments")]
        public void Delete(int id)
        {
            this._service.RemoveDepartment(id);
        }

        [System.Web.Mvc.HttpPost]
        [ActionName("GetDepartments")]
        public void Post([FromBody]DepartmentVieweModel department)
        {
            this._service.AddDepartment(this.dw.GetDepartmentFromViewModel(department));
        }

        [System.Web.Mvc.HttpPut]
        [ActionName("GetDepartments")]
        public void Put(int id, [FromBody] DepartmentVieweModel department)
        {
            if (this._service.FindDepartmentsById(id) != null)
            {
                this._service.EditDepartment(id, this.dw.GetDepartmentFromViewModel(department));
            }
        }

        [System.Web.Mvc.HttpOptions]
        //[ActionName("Options")]
        [ActionName("GetDepartments")]
        public void Options()
        {
            //httpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE, PUT");
            //HttpContext.Current.Response.AppendHeader("Allow", "POST, GET, OPTIONS, DELETE, PUT");
            //HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With");
        }
    }
}
