namespace TestCompanyApi.Controllers
{
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

        // GET api/department/5
        public DepartmentVieweModel Get(int id)
        {
            var dw = new ViewModel();
            return dw.GetDepartmentVieweModel(this._service.FindDepartmentsById(id));
        }
    }
}
