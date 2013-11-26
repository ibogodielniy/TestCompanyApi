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

var hash = 2;
$template = $(".template");

$(document).ready(function () {
    Page.Tabs.EmployeeTab.AddTab.OpenBtn.on('click', function () {
        EmployeeModule.AddEmployee();
    });

    Page.Tabs.EmployeeTab.AddTab.SubmitBtn.on('click', function () {
        EmployeeModule.SubmitEmployee();
        $(document).trigger('submitEmployee')
    });

    Page.Tabs.EmployeeTab.AddTab.CloseBtn.on('click', function () {
        EmployeeModule.CloseAddEmployeeModal();
    });

    Page.Tabs.EmployeeTab.EditTab.CloseBtn.on('click', function () {
        EmployeeModule.CloseEmployeeEditModal();
    });

    $('.delete-employee-btn').on('click', function () {
        EmployeeModule.DeleteEmployee($(this).attr("eid"));
        $(document).trigger('deleteEmployee')
    });

    $('.edit-employee-modal-btn').on('click', function () {
        EmployeeModule.OpenEmployeeModal($(this).attr("eId"));
    });
});

var EmployeeModule = {

    AddEmployee: function () {
        $('#add-employee-modal').modal('show');
    },

    CloseAddEmployeeModal: function () {
        $('#add-employee-modal').modal('hide');
    },

    EditEmployee: function (employee) {

        Page.Modals.EditEmployee.modal('show');
        $("#editEmpId").val(employee.Id).data('eId', employee.Id);
        Page.Tabs.EmployeeTab.EditTab.EmployeeNameInp.val(employee.Name);
        Page.Tabs.EmployeeTab.EditTab.EmployeePhoneInp.val(employee.Phone);
        Page.Tabs.EmployeeTab.EditTab.EmployeeEmailInp.val(employee.Email);
        Page.Tabs.EmployeeTab.EditTab.SubmitBtn.on('click', function () {
            employee.Name = Page.Tabs.EmployeeTab.EditTab.EmployeeNameInp.val();
            employee.Phone = Page.Tabs.EmployeeTab.EditTab.EmployeePhoneInp.val();
            employee.Email = Page.Tabs.EmployeeTab.EditTab.EmployeeEmailInp.val();
            AjaxModule.PutJSON(Page.Urls.EmployeeUrl, employee, employee.Id);
            this.CloseEmployeeEditModal();
        });
    },

    CloseEmployeeEditModal: function () {
        $('#edit-employee-modal').modal('hide');
    },

    DeleteEmployee: function (Id) {
        AjaxModule.DeleteJSON(Page.Urls.EmployeeUrl, Id);
    },

    SubmitEmployee: function () {
        this.clearEmployeeList();
        var employee = {};
        employee.Name = Page.Tabs.EmployeeTab.AddTab.EmployeeNameInp.val();
        employee.Phone = Page.Tabs.EmployeeTab.AddTab.EmployeePhoneInp.val();
        employee.Email = Page.Tabs.EmployeeTab.AddTab.EmployeeEmailInp.val();
        AjaxModule.PostJSON(Page.Urls.EmployeeUrl, employee);
        this.CloseAddEmployeeModal();
        this.getEmployeeFromJSON();
    },

    getEmployeeFromJSON: function () {
        var employee = JSON.parse(AjaxModule.GetJSON(Page.Urls.EmployeeUrl).responseText);
        for (var i = 0, len = employee.length; i < len; i++) {
            this.addPanel(employee[i].Id, employee[i].Name, employee[i].Email, employee[i].Phone);
        }
    },

    clearEmployeeList: function () {
        $('#accordion').empty();
    },

    addPanel: function (Id, Name, Email, Phone) {
        var $newPanel = $template.clone();
        $newPanel.find(".collapse").removeClass("in");
        $newPanel.find(".accordion-toggle").attr("href", "#" + (++hash)).text(Name);
        $newPanel.find(".panel-collapse").attr("id", hash).addClass("collapse").removeClass("in");
        $newPanel.find(".info-phone").text(Phone);
        $newPanel.find(".info-email").text(Email);
        $newPanel.find('.edit-employee-modal-btn').attr("eId", Id); //.data("Name", Name).data("dId", Id).data("Phone", Phone).data("Email", Email);
        $newPanel.find(".delete-employee-btn").attr("eId", Id);
        $("#accordion").append($newPanel.fadeIn());
    },

    OpenEmployeeModal: function (Id) {
        var employees = JSON.parse(AjaxModule.GetJSON(Page.Urls.EmployeeUrl).responseText);
        for (var i = 0, n = employees.length; i < n; i++) {
            var employee = employees[i];
            if (employee.Id == Id) {
                var emp = {name: employee.Name, phone: employee.Phone, email: employee.Email};
                $("#target").html(_.template($('#employee-template').html(), {employee: emp}));
                $('#edit-employee-modal').modal('show');
            }
        }
        $('#edit-submit-emplyee-btn').on("click", function () {
            employee.Name = $('#edit-employee-name-inp').val();
            employee.Phone = $('#edit-employee-phone-inp').val();
            employee.Email = $('#edit-employee-email-inp').val();
            AjaxModule.PutJSON(Page.Urls.EmployeeUrl, employee, Id);
            EmployeeModule.CloseEmployeeEditModal();
        });
    }
};

mediator.subscribe('departmentSelected', function (Id) {
alert('department selected' + Id);
});

EmployeeModule.getEmployeeFromJSON();
