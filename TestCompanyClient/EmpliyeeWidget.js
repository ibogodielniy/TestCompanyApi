var hash = 2;

var $template = $(".template");

var EmployeeModule = {
    init: function () {

        //Add Employee:
        $('.add-employee-modal-btn').on('click', function () {
            EmployeeModule.addEmployee();
        });

        //Submit Employee:
        $('#add-submit-emplyee-btn').on('click', function () {
            EmployeeModule.submitEmployee();
        });

        //Close Adding Modal:
        $('#add-close-emplyee-modal-btn').on('click', function () {
            EmployeeModule.closeAddEmployeeModal();
        });

        //Close Editing Modal:
        $('#edit-close-emplyee-modal-btn').on('click', function () {
            EmployeeModule.closeEmployeeEditModal();
        });

        //Delete Employee:
        $(document).delegate('.delete-employee-btn', 'click', function () {
            EmployeeModule.deleteEmployee($(this).attr("eid"));
        });

        //Edit Employee:
        $(document).delegate('.edit-employee-modal-btn', 'click', function () {
            EmployeeModule.openEmployeeModal($(this).attr("eId"));
        });

        //Subscribe To Department Selection Event:
        mediator.subscribe('departmentSelected', function (Id) {
            EmployeeModule.clearEmployeeList();
            EmployeeModule.getEmployeeFromJSON(Id);
        });

        $('#add-employee-company-inp, #edit-employee-company-inp').change(function () {
            var departments = JSON.parse(AjaxModule.GetJSON(API.Urls.DepartmentByCompany + this.value).responseText);
            $.each(departments, function () {
                var option = document.createElement("option");
                option.innerHTML = this.Name;
                option.value = this.IdDepartment;
                $('#add-employee-dep-inp, #add-employee-altdep-inp, #edit-employee-dep-inp, #edit-employee-altdep-inp').append(option);
            });
        });
    },

    closeEmployeeEditModal: function () {
        $('#edit-employee-modal').modal('hide');
    },

    clearEmployeeList: function () {
        $('#accordion').empty();
    },

    deleteEmployee: function (Id) {
        AjaxModule.DeleteJSON(API.Urls.EmployeeUrl, Id);
    },

    closeAddEmployeeModal: function () {
        $('#add-employee-modal').modal('hide');
    },

    addEmployee: function () {
        EmployeeModule.populateModal('#add-employee-modal')
    },

    populateModal: function (control) {
        $(control).modal('show');
        var company = JSON.parse(AjaxModule.GetJSON(API.Urls.CompaniesUrl).responseText);
        $.each(company, function () {
            var option = document.createElement("option");
            option.innerHTML = this.Name;
            option.value = this.Id;
            $('#add-employee-company-inp, edit-employee-company-inp').append(option);
        });
    },

    submitEmployee: function () {
        this.clearEmployeeList();
        var str = $("#add-emp-form").serialize();
        AjaxModule.PostJSON(API.Urls.EmployeeUrl, str);
        this.closeAddEmployeeModal();
        this.getEmployeeFromJSON();
    },

    getEmployeeFromJSON: function (DepId) {
        var employee = JSON.parse(AjaxModule.GetJSON(API.Urls.EmployeeByDepartment + DepId).responseText);
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
        var employees = JSON.parse(AjaxModule.GetJSON(API.Urls.EmployeeUrl).responseText);
        for (var i = 0, n = employees.length; i < n; i++) {
            var employee = employees[i];
            if (employee.Id == Id) {
                var emp = {name: employee.Name, phone: employee.Phone, email: employee.Email};
                $("#target").html(_.template($('#employee-template').html(), {employee: emp}));
                EmployeeModule.populateModal('#edit-employee-modal')
                //$('#edit-employee-modal').modal('show');
            }
        }

        $('#edit-submit-emplyee-btn').on("click", function () {
            var str = $("#edit-emp-form").serialize();
            AjaxModule.PutJSON(API.Urls.EmployeeUrl, str, Id);
            EmployeeModule.closeEmployeeEditModal();
        });
    }
};




