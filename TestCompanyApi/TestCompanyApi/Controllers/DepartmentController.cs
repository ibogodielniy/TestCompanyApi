namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
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
        public DepartmentVieweModel Get(int id)
        {
            return this.dw.GetDepartmentVieweModel(this._service.FindDepartmentsById(id));
        }

        public IEnumerable<DepartmentVieweModel> Get()
        {
            return this.dw.GetDepartmentsViewModels(this._service.FindAllDepartments());
        }

        [System.Web.Mvc.HttpPost]
        public void Delete(int id)
        {
            this._service.RemoveDepartment(id);
        }

        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]Department department)
        {
            this._service.AddDepartment(department);
        }

        [System.Web.Mvc.HttpPut]
        public void Put(int id, [FromBody] Department department)
        {
            this._service.EditDepartment(id, department);
        }
    }
}
