
namespace TestCompanyApi.Controllers
{
    using System.Web.Http;
    using TestCompanyApi.Services;

    /// <summary>
    /// The company controller.
    /// </summary>
    public class CompanyController : ApiController
    {
        /// <summary>
        /// The _service.
        /// </summary>
        private CompanyStructureService _service;

        /// <summary>
        /// Prevents a default instance of the <see cref="CompanyController"/> class from being created.
        /// </summary>
        private CompanyController()
        {
            CompanyContext context = new CompanyContext();
            Repository<Company> rep = new Repository<Company>(context);
            CompanyStructureService service = new CompanyStructureService();
            _service = service;
        }
    }
}
