namespace TestCompanyApi.Controllers
{
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;
    
    public class CompanyController : ApiController
    {
        private readonly CompanyService _service;
        
        private CompanyController()
        {
            var service = new CompanyService();
            this._service = service;
        }

        public CompanyViewModel Get(int id)
        {
            var dw = new ViewModel();
            return dw.GetCompanyViewModel(this._service.FindCompanyById(id));
        }
    }
}
