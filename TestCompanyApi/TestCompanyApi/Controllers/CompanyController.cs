
namespace TestCompanyApi.Controllers
{
    using System.Web.Http;
    using TestCompanyApi.Services;

    /// <summary>
    /// The company controller.
    /// </summary>
    public class CompanyController : ApiController
    {
        
        private CompanyStructureService _service;

      
        private CompanyController()
        {
            var context = new CompanyContext();
            var rep = new Repository<Company>(context);
            var service = new CompanyStructureService();
            this._service = service;
        }
    }
}
