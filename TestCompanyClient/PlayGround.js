//#region GLOBAL OBJECT
//Global application object




var Page = {
    Urls: {
        EmployeeUrl: 'http://localhost:15571/api/employee/',
        CompaniesUrl: 'http://localhost:15571/api/company/',
        DepartmentsUrl: 'http://localhost:15571/api/department/'
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

//Gets commonly used DOM elements for one time.
GetDOMElements = function () {

    //Header Tab controls:
    Page.Tabs.HeaderTab.HomeBtn = $('#header-home-btn');
    Page.Tabs.HeaderTab.AboutBtn = $('#header-about-btn');
    Page.Tabs.HeaderTab.ContactBtn = $('#header-contact-btn');
    //Page.Tabs.HeaderTab.LogInBtn = $('#header-login-btn');
    //Page.Tabs.HeaderTab.LogOut = $('#header-logout-btn');

    //Company Tab controls:
    Page.Tabs.CompanyTab.CompanySelect = $('.company-select');

    //Department Tab controls:
    Page.Tabs.DepartmentTab.AddTab.OpenBtn = $('.add-department-modal-btn');
    Page.Tabs.DepartmentTab.AddTab.SubmitBtn = $('#add-submit-department-btn');
    Page.Tabs.DepartmentTab.AddTab.CloseBtn = $('#add-close-department-modal-btn');
    Page.Tabs.DepartmentTab.AddTab.DepartmentNameInp = $('#add-department-name-inp');
    Page.Tabs.DepartmentTab.AddTab.DepartmentDescriptionInp = $('#add-department-description-inp');

    Page.Tabs.DepartmentTab.EditTab.DepartmentId = {};

    Page.Tabs.DepartmentTab.EditTab.OpenBtn = $('#edit-department-modal-btn');
    Page.Tabs.DepartmentTab.EditTab.SubmitBtn = $('#edit-submit-department-btn');
    Page.Tabs.DepartmentTab.EditTab.CloseBtn = $('#edit-close-department-modal-btn');
    Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp = $('#edit-department-name-inp');
    Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp = $('#edit-department-description-inp');

    Page.Tabs.DepartmentTab.DeleteBtn = $('.delete-department-btn');

    //Employee Tab controls:
    Page.Tabs.EmployeeTab.AddTab.OpenBtn = $('.add-employee-modal-btn');
    Page.Tabs.EmployeeTab.AddTab.SubmitBtn = $('#add-submit-emplyee-btn');
    Page.Tabs.EmployeeTab.AddTab.CloseBtn = $('#add-close-emplyee-modal-btn');
    Page.Tabs.EmployeeTab.AddTab.EmployeeNameInp = $('#add-employee-name-inp');
    Page.Tabs.EmployeeTab.AddTab.EmployeePhoneInp = $('#add-employee-phone-inp');
    Page.Tabs.EmployeeTab.AddTab.EmployeeEmailInp = $('#add-employee-email-inp');
    Page.Tabs.EmployeeTab.AddTab.EmployeeDepInp = $('#add-employee-dep-inp');
    Page.Tabs.EmployeeTab.AddTab.EmployeeAltDepInp = $('#add-employee-altdep-inp');

    Page.Tabs.EmployeeTab.EditTab.EmployeeId = {};

    Page.Tabs.EmployeeTab.EditTab.OpenBtn = $('.edit-employee-modal-btn');
    Page.Tabs.EmployeeTab.EditTab.SubmitBtn = $('#edit-submit-emplyee-btn');
    Page.Tabs.EmployeeTab.EditTab.CloseBtn = $('#edit-close-emplyee-modal-btn');
    Page.Tabs.EmployeeTab.EditTab.EmployeeNameInp = $('#edit-employee-name-inp');
    Page.Tabs.EmployeeTab.EditTab.EmployeePhoneInp = $('#edit-employee-phone-inp');
    Page.Tabs.EmployeeTab.EditTab.EmployeeEmailInp = $('#edit-employee-email-inp');
    Page.Tabs.EmployeeTab.EditTab.EmployeeDepInp = $('#edit-employee-dep-inp');
    Page.Tabs.EmployeeTab.EditTab.EmployeeAltDepInp = $('#edit-employee-altdep-inp');

    Page.Tabs.EmployeeTab.DeleteBtn = $('.delete-employee-btn');

    //Modals:
    Page.Modals.AddEmployee = $('#add-employee-modal');
    Page.Modals.EditEmployee = $('#edit-employee-modal');
    Page.Modals.AddDepartment = $('#add-department-modal');
    Page.Modals.EditDepartment = $('#edit-department-modal');
}();



//#Region EVENTS

$(document).ready(function () {

    //Employee UI functions:

    //Submit Employee
    Page.Tabs.EmployeeTab.AddTab.OpenBtn.on('click', function () {
        AddEmployee();
    });

    Page.Tabs.EmployeeTab.AddTab.SubmitBtn.on('click', function () {
        SubmitEmployee();
    });

    Page.Tabs.EmployeeTab.EditTab.CloseBtn.on('click', function () {
        CloseAddEmployeeModal();
    });

    //Delete Employee
    $('.delete-employee-btn').on('click', function () {
        DeleteEmployee($(this).data("eId"));
    });

    //Edit Employee
    $('.edit-employee-modal-btn').on('click', function () {
        var employee = {};
        employee.Id = $(this).data("eId");
        employee.Name = $(this).data("Name");
        employee.Phone = $(this).data("Phone");
        employee.Email = $(this).data("Email");
        EditEmployee(employee);
    });

    //Company UI functions:
    Page.Tabs.CompanyTab.CompanySelect.change(function () {
        var parentCompany = $(this).children("option").attr('value');
        SelectCompany(parentCompany);
    });

    //Department UI functions:

    //Add Department:
    Page.Tabs.DepartmentTab.AddTab.OpenBtn.on('click', function () {
        AddDepartment();
    });

    //Submit Department:
    Page.Tabs.DepartmentTab.AddTab.SubmitBtn.on('click', function () {
        SubmitDepartment();
    });

    Page.Tabs.DepartmentTab.AddTab.CloseBtn.on('click', function () {
        CloseDepartmentAddModal();
    });

    //Edit Department
    $('.edit-department-modal-btn').bind('click',function () {
        alert('that\'s working!');
        /*var department = {};
        department.Id = $(this).data("dId");
        department.Name = $(this).data("Name");
        department.Description = $(this).data("Description");
        EditDepartment(department);*/
    });

    //Delete Department
    $('.delete-department-btn').bind('click', function () {
        DeleteDepartment($(this).data("dId"));
    });
});

var $template = $(".template");
var hash = 2;

function addPanel(Id, Name, Email, Phone) {
    var $newPanel = $template.clone();
    $newPanel.find(".collapse").removeClass("in");
    $newPanel.find(".accordion-toggle").attr("href", "#" + (++hash)).text(Name);
    $newPanel.find(".panel-collapse").attr("id", hash).addClass("collapse").removeClass("in");
    $newPanel.find(".info-phone").text(Phone);
    $newPanel.find(".info-email").text(Email);
    $newPanel.find('.edit-employee-modal-btn').data("Name", Name).data("dId", Id).data("Phone", Phone).data("Email", Email);
    $newPanel.find("#emplyee-delete").data("eId", Id);
    $("#accordion").append($newPanel.fadeIn());
}

getEmployeeFromJSON();
getCompaniesFromJSON();

//Employee Methods That Should be Private:
function AddEmployee() {
    $('#add-employee-modal').modal('show');
}

function CloseAddEmployeeModal() {
    $('#add-employee-modal').modal('hide');
}

function EditEmployee(employee) {
    Page.Modals.EditEmployee.modal('show');
    $("#editEmpId").val(employee.Id).data('eId', employee.Id);
    Page.Tabs.EmployeeTab.EditTab.EmployeeNameInp.val(employee.Name);
    Page.Tabs.EmployeeTab.EditTab.EmployeePhoneInp.val(employee.Phone);
    Page.Tabs.EmployeeTab.EditTab.EmployeeEmailInp.val(employee.Email);
    Page.Tabs.EmployeeTab.EditTab.SubmitBtn.on('click', function () {
        employee.Name = Page.Tabs.EmployeeTab.EditTab.EmployeeNameInp.val();
        employee.Phone = Page.Tabs.EmployeeTab.EditTab.EmployeePhoneInp.val();
        employee.Email = Page.Tabs.EmployeeTab.EditTab.EmployeeEmailInp.val();
        PutJSON(Page.Urls.EmployeeUrl, employee, employee.Id);
        CloseEmployeeEditModal();
    });
}

function CloseEmployeeEditModal() {
    $('#edit-employee-modal').modal('hide');
}

function DeleteEmployee(Id) {
    DeleteJSON(Page.Urls.EmployeeUrl, Id);
}

function SubmitEmployee() {
    var employee = {};
    employee.Name = Page.Tabs.EmployeeTab.AddTab.EmployeeNameInp.val();
    employee.Phone = Page.Tabs.EmployeeTab.AddTab.EmployeePhoneInp.val();
    employee.Email = Page.Tabs.EmployeeTab.AddTab.EmployeeEmailInp.val();
    PostJSON(Page.Urls.EmployeeUrl, employee);
    CloseAddEmployeeModal();
}

function getEmployeeFromJSON() {
    var employee = JSON.parse(GetJSON(Page.Urls.EmployeeUrl).responseText);
    for (var i = 0, len = employee.length; i < len; i++) {
        addPanel(employee[i].Id, employee[i].Name, employee[i].Email, employee[i].Phone);
    }
}

//Department Methods That Should be Private:
function AddDepartment() {
    $(Page.Modals.AddDepartment).modal('show');
}

function SubmitDepartment() {
    var department = {};
    department.Name = Page.Tabs.DepartmentTab.AddTab.DepartmentNameInp.val();
    department.Description = Page.Tabs.DepartmentTab.AddTab.DepartmentDescriptionInp.val();
    PostJSON(Page.Urls.DepartmentsUrl, department);
    CloseDepartmentAddModal();
}

function CloseDepartmentAddModal() {
    $(Page.Modals.AddDepartment).modal('hide');
}

function CloseDepartmentEditModal() {
    $(Page.Modals.EditDepartment).modal('hide');
}

function DeleteDepartment(Id) {
    DeleteJSON(Page.Urls.DepartmentsUrl, Id);
}

function EditDepartment(department) {
    $(Page.Modals.EditDepartment).modal('show');
    $("#editDepId").val(department.Id).data("dId", department.Id);
    Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp.val(department.Name);
    Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp.val(department.Description);
    Page.Tabs.DepartmentTab.EditTab.SubmitBtn.on("click", function () {
        department.Name = Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp.val();
        department.Description = Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp.val();
        PutJSON(Page.Urls.DepartmentsUrl, department, department.Id);
        CloseDepartmentEditModal();
    });
}

function appendToTree(departments, parentCompany) {
    var ul = document.createElement("ul");
    for (var i = 0, n = departments.length; i < n; i++) {
        var department = departments[i];
        var li = document.createElement("li");
        var text = document.createTextNode(department.Name);
        var div = document.createElement('div');
        var editbtn = document.createElement('button');
        var deletebtn = document.createElement('button');
        editbtn.appendChild(document.createTextNode('Edit'));
        editbtn.setAttribute('data-dId', department.IdDepartment);
        editbtn.className += 'edit-department-modal-btn';
        deletebtn.appendChild(document.createTextNode('Delete'));
        deletebtn.setAttribute('data-dId', department.IdDepartment);
        deletebtn.className += 'delete-department-btn';
        div.className += 'treeNode';
        div.appendChild(text);
        div.appendChild(editbtn);
        div.appendChild(deletebtn);
        li.appendChild(div);
        if (department.ChilDepartments) {
            li.appendChild(appendToTree(department.ChilDepartments, parentCompany));
            ul.appendChild(li);
        }
    }
    return ul;
}

//Company Methods That Should be Private:
function SelectCompany(parentCompany) {
    var departments = JSON.parse(GetJSON(Page.Urls.DepartmentsUrl).responseText);
    var cont = $('#companyConteiner');
    cont.empty();
    function renderTree() {
        var treeEl = document.getElementById("companyConteiner");
        treeEl.appendChild(appendToTree(departments, parentCompany));
    }
    renderTree();
}

function getCompaniesFromJSON() {
    var company = JSON.parse(GetJSON(Page.Urls.CompaniesUrl).responseText);
    $.each(company, function () {
        var option = document.createElement("option");
        option.innerHTML = this.Name;
        option.value = this.Id;
        Page.Tabs.CompanyTab.CompanySelect.append(option);
    });
}

//Ajax functions:
function PutJSON(url, data, Id) {
    $.ajax({
        url: url + Id,
        type: 'PUT',
        data: data,
        success: function () {
            alert('Employee has been modified');
        }
    });
}

function GetJSON(url) {
    return $.ajax({
        type: "GET",
        url: url,
        async: false,
        dataType: "application/json"
    });
}

function PostJSON(url, data) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function () {
            alert('New employee has been added');
        }
    });
}

function DeleteJSON(url, id) {
    $.ajax({
        url: url + id,
        type: 'DELETE',
        crossDomain: true,
        success: function () {
            alert('Employee has been deleted');
        }
    });
}






















