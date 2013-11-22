var getEmployeeUrl = "http://localhost:15571/api/employee/";
var Employee = new Object()
{
    Name = "";
    Phone = "";
    Email = "";
}

<!--Server methods-->

//Methods working with employee service/

function GetJSON(url) {
    return $.ajax({
        type: "GET",
        url: url,
        async: false,
        dataType: "application/json"
    });
}

function PutJSON(url, data) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function () {
            alert('New employee been added');
        }
    });
}

function DeleteJSON(url, id) {
    $.ajax({
        url: url + id,
        type: 'DELETE',
        success: function () {
            alert('Employee been deleted');
        }
    });
}

function PostJSON(url, id) {
    $.ajax({
        url: url + id,
        type: 'POST',
        success: function () {
            alert('Employee been updated');
        }
    });
}

//The company service methods

var companyURL = "http://localhost:15571/api/company/2";
var companies = JSON.parse(GetJSON(companyURL).responseText);
tab = document.getElementById("company-select");
for (var i = 0, len = companies.length; i < len; i++){
                           tab.innerHTML = "<option>" + companies[i].Name.toString() + "</option>";
}

<!--Gui methods-->

var $template = $(".template");
var hash = 2;

getEmployeeFromJSON();

function addPanel(Id, Name, Email, Phone) {
    var $newPanel = $template.clone();
    $newPanel.find(".collapse").removeClass("in");
    $newPanel.find(".accordion-toggle").attr("href", "#" + (++hash)).text(Name);
    $newPanel.find(".panel-collapse").attr("id", hash).addClass("collapse").removeClass("in");
    $newPanel.find(".panel-info").text(Email + Phone);
    $newPanel.find(".panel-info").attr("employeeId", Id);
    $newPanel.find("#emplyee-delete").attr("eId", Id);
    $("#accordion").append($newPanel.fadeIn());
}

function getEmployeeFromJSON() {
    var employee = JSON.parse(GetJSON(getEmployeeUrl).responseText);
    for (var i = 0, len = employee.length; i < len; i++) {
        addPanel(employee[i].Id, employee[i].Name, employee[i].Email, employee[i].Phone);
    }
}

var employee = document.getElementById("emplyee-delete");
employee.onclick = DeleteJSON(getEmployeeUrl, employee.getAttribute("eId"));

$("#add-emplyee-submit").click(function () {
    var employee = new Object();
    employee.Name = $("#addEmpName").val();
    employee.Phone = $("#addEmpPhone").val();
    employee.Email = $("#addEmpEmail").val();
    PutJSON(getEmployeeUrl, employee);
    $('#addEmployee').modal('hide')
});



  /*
$("#btnedit").click(function () {
    $('#editEmployee').modal('show')
});

$("#emplyee-delete").click(function () {
    var id = $("#emplyee-delete").data("data");
    DeleteJSON(getEmployeeUrl, id);
});

$("#addEmployee1").click(function () {
    $('#addEmployee').modal('show')
});

$("#close-add-dep-btn").click(function () {
    $('#addEmployee').modal('hide')
}); */






