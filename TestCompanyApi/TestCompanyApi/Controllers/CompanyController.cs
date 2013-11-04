
namespace TestCompanyApi.Controllers
{
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;

    /// <summary>
    /// The company controller.
    /// </summary>
    public class CompanyController : ApiController
    {
        /// <summary>
        /// The _service.
        /// </summary>
        private CompanyRESTService _service;

        /// <summary>
        /// Prevents a default instance of the <see cref="CompanyController"/> class from being created.
        /// </summary>
        private CompanyController()
        {
            var context = new CompanyContext();
            var rep = new Repository<Company>(context);
            var service = new CompanyRESTService();
            this._service = service;
        }

        public CompanyViewModel Get(int id)
        {
            var dw = new CompanyViewModel();
            return dw.GetCompanyViewModel(this._service.GetCompanyById(id));

        }
    }
}
