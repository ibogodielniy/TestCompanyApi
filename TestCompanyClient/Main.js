
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

$(function () {
    $(".source, .target").sortable({
        connectWith: ".connected"
    }).draggable();
});

Page.Tabs.HeaderTab.HomeBtn = $('#header-home-btn');
Page.Tabs.HeaderTab.AboutBtn = $('#header-about-btn');
Page.Tabs.HeaderTab.ContactBtn = $('#header-contact-btn');
//Page.Tabs.HeaderTab.LogInBtn = $('#header-login-btn');
//Page.Tabs.HeaderTab.LogOut = $('#header-logout-btn');






























