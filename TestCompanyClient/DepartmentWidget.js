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


Page.Modals.addDepartment = $('#add-department-modal');
Page.Modals.editDepartment = $('#edit-department-modal');

$(document).ready(function () {
    //Department UI methods:

    //Add Department:
    Page.Tabs.DepartmentTab.AddTab.OpenBtn.on('click', function () {
        DepartmentModule.addDepartment();
    });

    //Submit Department:
    Page.Tabs.DepartmentTab.AddTab.SubmitBtn.on('click', function () {
        DepartmentModule.submitAddDepartment();
    });

    Page.Tabs.DepartmentTab.AddTab.CloseBtn.on('click', function () {
        DepartmentModule.closeDepartmentAddModal();
    });

    //Edit Department
    $(document).delegate('.edit-department-modal-btn', 'click', function () {
        DepartmentModule.openDepartmentModal($(this).attr("data-dId"));
    });

    //Delete Department
    $(document).delegate('.delete-department-btn', 'click', function () {
        DepartmentModule.deleteDepartment($(this).attr("data-dId"));
    });

    //Select Department
    $(document).delegate('.select-dep-btn', 'click', function () {
        var Id = $(this).attr('data-dId');
        mediator.publish('departmentSelected', Id);
    });

    //Move Department
    $(document).delegate('ul', 'sortchange', function () {
        var Id = $(this).find('button').attr('data-dId');
        mediator.publish('departmentMovedFrom', Id);
    });

    $(document).delegate('#submit', 'click', function () {
        DepartmentModule.submitEditDepartment($('#department-modal').attr('data-dId'));
    });
});

var DepartmentModule = {

        companyId: 0,

        addDepartment: function () {
            $(Page.Modals.addDepartment).modal('show');
        },

        submitAddDepartment: function () {
            var department = {};
            department.Name = Page.Tabs.DepartmentTab.AddTab.DepartmentNameInp.val();
            department.Description = Page.Tabs.DepartmentTab.AddTab.DepartmentDescriptionInp.val();
            AjaxModule.PostJSON(Page.Urls.DepartmentsUrl, department);
            DepartmentModule.closeDepartmentAddModal();
        },

        submitEditDepartment: function (Id) {
            var department = {};
            department.Name = $('#edit-department-name-inp').val();
            department.Description = $('#edit-department-description-inp').val();
            department.IdDepartment = Id;
            department.CompanyId = this.companyId;
            AjaxModule.PutJSON(Page.Urls.DepartmentsUrl, department, Id);
            DepartmentModule.closeDepartmentEditModal();
        },

        closeDepartmentAddModal: function () {
            $(Page.Modals.addDepartment).modal('hide');
        },

        closeDepartmentEditModal: function () {
            $('#department-modal').modal('hide');
        },

        deleteDepartment: function (Id) {
            AjaxModule.DeleteJSON(Page.Urls.DepartmentsUrl, Id);
        },

        createLiElement: function (department) {

            var delbtn = $('<button/>', {
                text: 'Delete',
                class: 'delete-department-btn hideble btn btn-default'}).attr('data-dId', department.IdDepartment);

            var editbtn = $('<button/>', {
                text: 'Edit',
                class: 'edit-department-modal-btn hideble btn btn-default'}).attr('data-dId', department.IdDepartment);

            var selectbtn = $('<button/>', {
                text: 'Select',
                class: 'select-dep-btn hideble btn btn-default'}).attr('data-dId', department.IdDepartment);

            var btndiv = $('<div><div/>').append(delbtn, editbtn, selectbtn).addClass('treeNode btn-group');

            var namediv = $('<div><div/>').text(department.Name).addClass('treeNode');

            var li = $('<li></li>').append(namediv).append(btndiv).addClass('sortable').attr('data-dId', department.IdDepartment);

            return  li;
        },

        appendDepartmentToTree: function (departments, ul) {
            var ancestorDeps = [];

            for (var i = 0, n = departments.length; i < n; i++) {
                var department = departments[i];

                if (department.AncestorDepartment_IdDepartment == null) {
                    ul.append(DepartmentModule.createLiElement(department));
                }
                else {
                    ancestorDeps.push(department);
                }
            }

            for (var t = 0; t < ancestorDeps.length; t++) {
                var Id = ancestorDeps[t].AncestorDepartment_IdDepartment;
                var intermediateUl = $('<ul></ul>');
                intermediateUl.append(DepartmentModule.createLiElement(ancestorDeps[t]));
                (ul).find('li.sortable[data-did= ' + Id + ']').append(intermediateUl);//.find(".sortable[data-dId$='Id']")
                ancestorDeps.splice(t, 1);
            }

            if (ancestorDeps.length) {
                DepartmentModule.appendDepartmentToTree(ancestorDeps, ul);
            }

            return ul;
        },

        departmentMovedFrom: function (item) {
            var parent = item.parent().parent().attr('data-dId');
            var first = item.parents('li').last().attr('data-dId');
        },

        departmentMovedTo: function (item) {
            var parent = item.parent().parent().attr('data-dId');
            //var first = item.parents('li').last().attr('data-dId');
            var Id = item.attr('data-dId');
            var dep = JSON.parse(AjaxModule.GetJSON(Page.Urls.DepartmentsUrl + 'GetDep/' + Id).responseText);
            var department = {};
            department.AncestorDepartment_IdDepartment = parent;
            department.Name = dep.Name;
            department.Description = dep.Description;
            department.IdDepartment = Id;
            department.CompanyId = dep.CompanyId;
            AjaxModule.PutJSON(Page.Urls.DepartmentsUrl, department, Id);
        },

        openDepartmentModal: function (Id) {
            var departments = JSON.parse(AjaxModule.GetJSON(Page.Urls.DepartmentsUrl).responseText);
            for (var i = 0, n = departments.length; i < n; i++) {
                var department = departments[i];
                if (department.IdDepartment == Id) {
                    var item = {name: department.Name, description: department.Description};
                    $("#target").html(_.template($('#template').html(), {item: item}));
                    $('#department-modal').modal('show').attr('data-dId', Id);
                }
            }
        }
    }
    ;

mediator.subscribe('CompanySelected', function (CompanyId) {
    DepartmentModule.companyId = CompanyId;
    var departments = JSON.parse(AjaxModule.GetJSON(Page.Urls.DepartmentByCompany + CompanyId).responseText);
    $('#companyConteiner').empty();
    function renderTree() {
        $("#companyConteiner").append(DepartmentModule.appendDepartmentToTree(departments, $('<ul></ul>')));
        $('.hideble').hide();
        $("#companyConteiner ul").sortable({
            connectWith: "#companyConteiner ul",
            placeholder: "ui-state-highlight",
            start: function (event, ui) {
                DepartmentModule.departmentMovedFrom(ui.item);
            },
            stop: function (event, ui) {
                DepartmentModule.departmentMovedTo(ui.item);
            }
        });

        $('.treeNode').on('mouseover',function () {
            $(this).find('.hideble').show();
        }).on('mouseout', function () {
                $('.hideble').hide();
            });
    }

    renderTree();
});

$("#sortable").sortable().disableSelection();




