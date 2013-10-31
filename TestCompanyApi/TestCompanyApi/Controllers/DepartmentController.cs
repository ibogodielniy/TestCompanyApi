using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestCompanyApi.Services;

namespace TestCompanyApi.Controllers
{
    public class DepartmentController : ApiController
    {
        private CompanyStructureService _service;

        private DepartmentController()
        {
            var service = new CompanyStructureService();
            _service = service;
        }

        // GET api/department
        //public IEnumerable<string> Get()
        //{
        //    return "value";
        //}

        // GET api/department/5
        public Department Get(int id)
        {
            return _service.GetDepartmentsById(id);
        }

        // POST api/department
        public void Post([FromBody]string value)
        {
        }

        // PUT api/department/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/department/5
        public void Delete(int id)
        {
        }
    }
}
