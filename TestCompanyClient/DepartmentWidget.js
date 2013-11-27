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


Page.Modals.AddDepartment = $('#add-department-modal');
Page.Modals.EditDepartment = $('#edit-department-modal');

$(document).ready(function () {
    //Department UI methods:

    //Add Department:
    Page.Tabs.DepartmentTab.AddTab.OpenBtn.on('click', function () {
        DepartmentModule.AddDepartment();
    });

    //Submit Department:
    Page.Tabs.DepartmentTab.AddTab.SubmitBtn.on('click', function () {
        DepartmentModule.SubmitDepartment();
    });

    Page.Tabs.DepartmentTab.AddTab.CloseBtn.on('click', function () {
        DepartmentModule.CloseDepartmentAddModal();
    });

    //Edit Department
    $(document).delegate('.edit-department-modal-btn', 'click', function () {
        DepartmentModule.OpenDepartmentModal($(this).attr("data-dId"));
    });

    //Delete Department
    $(document).delegate('.delete-department-btn', 'click', function () {
        DepartmentModule.DeleteDepartment($(this).data("dId"));
    });

    //Select Department
    $(document).delegate('.select-dep-btn', 'click', function () {
        var Id = $(this).attr('data-dId');
        mediator.publish('departmentSelected', Id);
    });

    $('.toggable-ul ul').hide();

    $(document).delegate('.toggable', 'click', function () {
        $(this).find('ul').slideToggle();
    });
});

var DepartmentModule = {

    AddDepartment: function () {
        $(Page.Modals.AddDepartment).modal('show');

    },

    SubmitDepartment: function () {
        var department = {};
        department.Name = Page.Tabs.DepartmentTab.AddTab.DepartmentNameInp.val();
        department.Description = Page.Tabs.DepartmentTab.AddTab.DepartmentDescriptionInp.val();
        AjaxModule.PostJSON(Page.Urls.DepartmentsUrl, department);
        DepartmentModule.CloseDepartmentAddModal();
    },

    CloseDepartmentAddModal: function () {
        $(Page.Modals.AddDepartment).modal('hide');
    },

    CloseDepartmentEditModal: function () {
        $('#department-modal').modal('hide');
    },

    DeleteDepartment: function (Id) {
        AjaxModule.DeleteJSON(Page.Urls.DepartmentsUrl, Id);
    },

    EditDepartment: function (department) {
        $(Page.Modals.EditDepartment).modal('show');
        $("#editDepId").val(department.Id).data("dId", department.Id);
        Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp.val(department.Name);
        Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp.val(department.Description);
        Page.Tabs.DepartmentTab.EditTab.SubmitBtn.on("click", function () {
            department.Name = Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp.val();
            department.Description = Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp.val();
            AjaxModule.PutJSON(Page.Urls.DepartmentsUrl, department, department.Id);
            DepartmentModule.CloseDepartmentEditModal();
        });
    },

    appendToTree: function (departments) {
        var ul = document.createElement("ul");
        ul.className = 'toggable-ul';
        for (var i = 0, n = departments.length; i < n; i++) {
            var department = departments[i];
            var li = document.createElement("li");
            var text = document.createTextNode(department.Name);
            var div = document.createElement('div');
            var innerdiv = document.createElement('div');
            var editbtn = document.createElement('button');
            var deletebtn = document.createElement('button');
            var selectbtn = document.createElement('button');
            selectbtn.appendChild(document.createTextNode('Select'));
            editbtn.appendChild(document.createTextNode('Edit'));
            deletebtn.appendChild(document.createTextNode('Delete'));
            innerdiv.className += 'btn-group';
            editbtn.className += 'edit-department-modal-btn hideble btn btn-default';
            selectbtn.className += 'select-dep-btn hideble btn btn-default';
            deletebtn.className += 'delete-department-btn hideble btn btn-default';
            div.className += 'treeNode';
            deletebtn.setAttribute('data-dId', department.IdDepartment);
            editbtn.setAttribute('data-dId', department.IdDepartment);
            selectbtn.setAttribute('data-dId', department.IdDepartment);
            innerdiv.appendChild(editbtn);
            innerdiv.appendChild(deletebtn);
            innerdiv.appendChild(selectbtn);
            div.setAttribute('data-did', department.IdDepartment);
            div.appendChild(innerdiv);
            div.appendChild(text);
            div.appendChild(innerdiv);
            li.appendChild(div);
            if (department.ChilDepartments) {
                li.appendChild(DepartmentModule.appendToTree(department.ChilDepartments));
                //li.className += 'toggable';
                ul.appendChild(li);
            }
        }

        return ul;
    },

    OpenDepartmentModal: function (Id) {
        var departments = JSON.parse(AjaxModule.GetJSON(Page.Urls.DepartmentsUrl).responseText);
        for (var i = 0, n = departments.length; i < n; i++) {
            var department = departments[i];
            if (department.IdDepartment == Id) {
                var item = {name: department.Name, description: department.Description};
                $("#target").html(_.template($('#template').html(), {item: item}));
                $('#department-modal').modal('show');
            }
        }
        $('#submit').on("click", function () {
            department.Name = Page.Tabs.DepartmentTab.EditTab.DepartmentNameInp.val();
            department.Description = Page.Tabs.DepartmentTab.EditTab.DepartmentDescriptionInp.val();
            AjaxModule.PutJSON(Page.Urls.DepartmentsUrl, department, Id);
            DepartmentModule.CloseDepartmentEditModal();
        });
    }
};

mediator.subscribe('CompanySelected', function (CompanyId) {
    var departments = JSON.parse(AjaxModule.GetJSON(Page.Urls.DepartmentByCompany + CompanyId).responseText);
    $('#companyConteiner').empty();
    function renderTree() {
        var treeEl = document.getElementById("companyConteiner");
        treeEl.appendChild(DepartmentModule.appendToTree(departments));
        $('.hideble').hide();

        $('.treeNode').on('mouseover',function () {
            $(this).find('.hideble').show();
        }).on('mouseout', function () {
                $('.hideble').hide();
            });
    }

    renderTree();
});


