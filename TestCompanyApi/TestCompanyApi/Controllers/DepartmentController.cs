
namespace TestCompanyApi.Controllers
{
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;
    using TestCompanyApi.Mapper;
    using AutoMapper;

    /// <summary>
    /// The department controller.
    /// </summary>
    public class DepartmentController : ApiController
    {
        /// <summary>
        /// The _service.
        /// </summary>
        private CompanyRESTService _service;

        /// <summary>
        /// Prevents a default instance of the <see cref="DepartmentController"/> class from being created.
        /// </summary>
        private DepartmentController()
        {
            var service = new CompanyRESTService();
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
        public DepartmentVieweModel Get(int id)
        {
            var dw = new DepartmentVieweModel();
            return dw.GetDepartmentVieweModel(this._service.GetDepartmentsById(id));
        }
    }
}
