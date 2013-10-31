
namespace TestCompanyApi.Controllers
{
    using System.Web.Http;
    using TestCompanyApi.Services;

    /// <summary>
    /// The department controller.
    /// </summary>
    public class DepartmentController : ApiController
    {
        /// <summary>
        /// The _service.
        /// </summary>
        private CompanyStructureService _service;

        /// <summary>
        /// Prevents a default instance of the <see cref="DepartmentController"/> class from being created.
        /// </summary>
        private DepartmentController()
        {
            var service = new CompanyStructureService();
            this._service = service;
        }

        // GET api/department/5

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Department"/>.
        /// </returns>
        public Department Get(int id)
        {
            return this._service.GetDepartmentsById(id);
        }
    }
}
