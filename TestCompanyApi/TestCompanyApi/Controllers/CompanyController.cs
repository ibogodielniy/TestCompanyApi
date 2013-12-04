namespace TestCompanyApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using TestCompanyApi.Mapper;
    using TestCompanyApi.Services;

    public class CompanyController : ApiController
    {
        private readonly CompanyService _service;

        private CompanyController()
        {
            var service = new CompanyService();
            this._service = service;
        }

        private ViewModel wModel = new ViewModel();

        [System.Web.Http.ActionName("Company")]
        public CompanyViewModel Get(int id)
        {
            return this.wModel.GetCompanyViewModel(this._service.FindCompanyById(id));
        }

        [System.Web.Http.ActionName("Company")]
        public IEnumerable<CompanyViewModel> Get()
        {
            return this.wModel.GetCompaniesViewModels(this._service.FindAllCompanies());
        }
    }
}
