
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

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Company"/>.
        /// </returns>
        //public Company Get(int id)
        //{
        //    return this._service.GetCompanyById(id);
        //}

        //public object Get(int id)
        //{
        //    return
        //}
    }
}
