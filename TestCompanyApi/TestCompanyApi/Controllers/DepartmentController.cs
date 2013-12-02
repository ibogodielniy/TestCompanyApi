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

        // GET api/department/5
        public DepartmentVieweModel GetDep(int id)
        {
            return this.dw.GetDepartmentVieweModel(this._service.FindDepartmentsById(id));
        }

        //public IEnumerable<DepartmentVieweModel> GetDepartments()
        //{
        //    return this.dw.GetDepartmentsViewModels(this._service.FindAllDepartments());
        //}

        public IEnumerable<DepartmentVieweModel> GetDepartmentsByCompany(int id)
        {
            return this.dw.GetDepartmentsViewModels(this._service.FindAllCompanysDepartments(id));
        }

        [System.Web.Mvc.HttpDelete]
        public void Delete(int id)
        {
            this._service.RemoveDepartment(id);
        }

        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]DepartmentVieweModel department)
        {
            this._service.AddDepartment(this.dw.GetDepartmentFromViewModel(department));
        }

        [System.Web.Mvc.HttpPut]
        public void Put(int id, [FromBody] DepartmentVieweModel department)
        {
            if (this._service.FindDepartmentsById(id) != null)
            {
                this._service.EditDepartment(id, this.dw.GetDepartmentFromViewModel(department));
            }
        }

        [System.Web.Mvc.HttpOptions]
        public void Options()
        {
            //httpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE, PUT");
            HttpContext.Current.Response.AppendHeader("Allow", "POST, GET, OPTIONS, DELETE, PUT");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With");
           
        }
    }
}
