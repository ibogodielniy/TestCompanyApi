namespace TestCompanyApi.Mapper
{
    using System.Collections.Generic;

    using AutoMapper;

    public class ViewModel
    {
        public CompanyViewModel GetCompanyViewModel(Company company)
        {
            return Mapper.Map<Company, CompanyViewModel>(company);
        }

        public EmployeeViewModel GetEmployeeViewModel(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeViewModel>(employee);
        }

        public DepartmentVieweModel GetDepartmentVieweModel(Department department)
        {
            return Mapper.Map<Department, DepartmentVieweModel>(department);
        }

        public IEnumerable<EmployeeViewModel> GetEmployeeViewModels(IEnumerable<Employee> employees)
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
        }

        public IEnumerable<CompanyViewModel> GetCompaniesViewModels(IEnumerable<Company> companies)
        {
            return Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyViewModel>>(companies);
        }

        public IEnumerable<DepartmentVieweModel> GetDepartmentsViewModels(IEnumerable<Department> departments)
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentVieweModel>>(departments);
        }
    }
}
