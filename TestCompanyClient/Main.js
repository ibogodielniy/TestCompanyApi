var API = {
    Urls: {
        EmployeeUrl: 'http://localhost:15571/api/employee/',
        CompaniesUrl: 'http://localhost:15571/api/company/',
        DepartmentsUrl: 'http://localhost:15571/api/department/GetDepartments/',
        EmployeeByDepartment: 'http://localhost:15571/api/employee/GetEmployeeByDepartments/',
        DepartmentByCompany: 'http://localhost:15571/api/department/GetDepartmentsByCompany/'
    }
};

$(document).ready(function(){
    DepartmentModule.init();
    EmployeeModule.init();
    ComapanyModule.init();
});
































