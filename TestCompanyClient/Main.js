var Page = {
    Urls: {
        EmployeeUrl: 'http://localhost:15571/api/employee/',
        CompaniesUrl: 'http://localhost:15571/api/company/',
        DepartmentsUrl: 'http://localhost:15571/api/department/',
        EmployeeByDepartment: 'http://localhost:15571/api/employee/GetEmployeeByDepartments/',
        DepartmentByCompany: 'http://localhost:15571/api/department/GetDepartmentsByCompany/'
    },
    Elements: {},
    Modals: {},
    Tabs: {
        EmployeeTab: {
            AddTab: {},
            EditTab: {}
        },
        DepartmentTab: {
            AddTab: {},
            EditTab: {}
        },
        CompanyTab: {},
        HeaderTab: {}
    }
};

Page.Tabs.HeaderTab.HomeBtn = $('#header-home-btn');
Page.Tabs.HeaderTab.AboutBtn = $('#header-about-btn');
Page.Tabs.HeaderTab.ContactBtn = $('#header-contact-btn');
//Page.Tabs.HeaderTab.LogInBtn = $('#header-login-btn');
//Page.Tabs.HeaderTab.LogOut = $('#header-logout-btn');


/*EmployeeModule.init();

 EmployeeModule = (function () {
 var changeContext = function (depId) {

 //todo smth
 }

 var initInternalHandlers = function () {
 //$(/..).on("cliuck",...)
 }

 return {
 init: function () {
 observer.registerHandler("", changeContext);
 initInternalHandlers();
 }
 }
 })();*/
/*

 $(document).on('companyselected', function () {
 alert('company selected')
 });

 $(document).on('submitEmployee', function () {
 EmployeeModule.clearEmployeeList();
 EmployeeModule.getEmployeeFromJSON();
 });

 $(document).on('deleteEmployee', function () {
 EmployeeModule.clearEmployeeList();
 EmployeeModule.getEmployeeFromJSON();
 });
 */




























