//Employee Tab controls:
Page.Tabs.EmployeeTab.AddTab.OpenBtn = $('.add-employee-modal-btn');
Page.Tabs.EmployeeTab.AddTab.SubmitBtn = $('#add-submit-emplyee-btn');
Page.Tabs.EmployeeTab.AddTab.CloseBtn = $('#add-close-emplyee-modal-btn');

Page.Tabs.EmployeeTab.EditTab.EmployeeId = {};

Page.Tabs.EmployeeTab.EditTab.OpenBtn = $('.edit-employee-modal-btn');
Page.Tabs.EmployeeTab.EditTab.SubmitBtn = $('#edit-submit-emplyee-btn');
Page.Tabs.EmployeeTab.EditTab.CloseBtn = $('#edit-close-emplyee-modal-btn');

Page.Tabs.EmployeeTab.DeleteBtn = $('.delete-employee-btn');

//Modals:
Page.Modals.addEmployee = $('#add-employee-modal');
Page.Modals.editEmployee = $('#edit-employee-modal');

var hash = 2;
$template = $(".template");

$(document).ready(function () {
    Page.Tabs.EmployeeTab.AddTab.OpenBtn.on('click', function () {
        EmployeeModule.addEmployee();
    });

    Page.Tabs.EmployeeTab.AddTab.SubmitBtn.on('click', function () {
        EmployeeModule.submitEmployee();
    });

    Page.Tabs.EmployeeTab.AddTab.CloseBtn.on('click', function () {
        EmployeeModule.closeAddEmployeeModal();
    });

    Page.Tabs.EmployeeTab.EditTab.CloseBtn.on('click', function () {
        EmployeeModule.closeEmployeeEditModal();
    });

    $(document).delegate('.delete-employee-btn', 'click', function () {
        EmployeeModule.deleteEmployee($(this).attr("eid"));
    });

    $(document).delegate('.edit-employee-modal-btn','click', function () {
        EmployeeModule.openEmployeeModal($(this).attr("eId"));
    });
});

var EmployeeModule = {

    closeEmployeeEditModal: function () {
        $('#edit-employee-modal').modal('hide');
    },

    clearEmployeeList: function () {
        $('#accordion').empty();
    },

    deleteEmployee: function (Id) {
        AjaxModule.DeleteJSON(Page.Urls.EmployeeUrl, Id);
    },

    closeAddEmployeeModal: function () {
        $('#add-employee-modal').modal('hide');
    },

    addEmployee: function () {
        $('#add-employee-modal').modal('show');
       /* var company = JSON.parse(AjaxModule.GetJSON(Page.Urls.CompaniesUrl).responseText);
        $.each(company, function () {
            var option = document.createElement("option");
            option.innerHTML = this.Name;
            option.value = this.Id;
            $('#add-employee-company-inp').append(option);
        });*/
    },

    submitEmployee: function () {
        this.clearEmployeeList();
        var str = $("#add-emp-form").serialize();
        AjaxModule.PostJSON(Page.Urls.EmployeeUrl, str);
        this.closeAddEmployeeModal();
        this.getEmployeeFromJSON();
    },

    getEmployeeFromJSON: function (DepId) {
        var employee = JSON.parse(AjaxModule.GetJSON(Page.Urls.EmployeeByDepartment + DepId).responseText);
        for (var i = 0, len = employee.length; i < len; i++) {
            this.addPanel(employee[i].Id, employee[i].Name, employee[i].Email, employee[i].Phone);
        }
    },

    addPanel: function (Id, Name, Email, Phone) {
        var $newPanel = $template.clone();
        $newPanel.find(".collapse").removeClass("in");
        $newPanel.find(".accordion-toggle").attr("href", "#" + (++hash)).text(Name);
        $newPanel.find(".panel-collapse").attr("id", hash).addClass("collapse").removeClass("in");
        $newPanel.find(".info-phone").text(Phone);
        $newPanel.find(".info-email").text(Email);
        $newPanel.find('.edit-employee-modal-btn').attr("eId", Id);
        $newPanel.find(".delete-employee-btn").attr("eId", Id);
        $("#accordion").append($newPanel.fadeIn());
    },

    openEmployeeModal: function (Id) {
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
            var str = $("#edit-emp-form").serialize();
            AjaxModule.PutJSON(Page.Urls.EmployeeUrl, str, Id);
            EmployeeModule.closeEmployeeEditModal();
        });
    }
};

mediator.subscribe('departmentSelected', function (Id) {
    EmployeeModule.clearEmployeeList();
    EmployeeModule.getEmployeeFromJSON(Id);
});


