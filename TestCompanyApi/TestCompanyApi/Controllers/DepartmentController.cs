namespace TestCompanyApi.Controllers
{
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;
    
    public class DepartmentController : ApiController
    {
        private readonly CompanyRESTService _service;
        
        private DepartmentController()
        {
            var service = new CompanyRESTService();
            this._service = service;
        }

        // GET api/department/5
        public DepartmentVieweModel Get(int id)
        {
            var dw = new DepartmentVieweModel();
            return dw.GetDepartmentVieweModel(this._service.GetDepartmentsById(id));
        }
    }
}
