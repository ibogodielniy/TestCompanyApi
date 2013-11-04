namespace TestCompanyApi.Controllers
{
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;
    
    public class CompanyController : ApiController
    {
        private readonly CompanyRESTService _service;
        
        private CompanyController()
        {
            var service = new CompanyRESTService();
            this._service = service;
        }

        public CompanyViewModel Get(int id)
        {
            var dw = new CompanyViewModel();
            return dw.GetCompanyViewModel(this._service.GetCompanyById(id)) ;
        }
    }
}
