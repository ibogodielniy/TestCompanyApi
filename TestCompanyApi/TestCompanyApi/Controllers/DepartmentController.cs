using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestCompanyApi.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET api/department
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/department/5
        public string Get(int id)
        {
            return "value";
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
