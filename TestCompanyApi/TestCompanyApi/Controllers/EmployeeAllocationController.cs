namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using TestCompanyApi.Services;

    public class EmployeeAllocationController : ApiController
    {
        private readonly CompanyService _service;

        public EmployeeAllocationController()
        {
            var service = new CompanyService();
            this._service = service;
        }

        // GET api/employeeallocation/4
        public IEnumerable<EmployeeAllocation> GetAllocation(int departmentId)
        {
            return this._service.GetEmployeeByDepartment(departmentId);
        }
    }
}
