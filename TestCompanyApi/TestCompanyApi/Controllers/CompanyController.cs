using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestCompanyApi.Services;

namespace TestCompanyApi.Controllers
{
    public class CompanyController : ApiController
    {
        private CompanyStructureService _service;

        private CompanyController()
        {
            CompanyContext context = new CompanyContext();
            Repository<Company> rep = new Repository<Company>(context);
            CompanyStructureService service = new CompanyStructureService();
            _service = service;
        }

        // GET api/company
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/company
        public void Post([FromBody]string value)
        {
        }

        // PUT api/company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/company/5
        public void Delete(int id)
        {
        }
    }
}
