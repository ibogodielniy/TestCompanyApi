var DepartmentModule = {

    companyId: 0,

    init: function () {
        //Department UI methods:

        //Add Department:
        $('.add-department-modal-btn').on('click', function () {
            DepartmentModule.addDepartment();
        });

        //Submit Newly Added Department:
        $('#add-submit-department-btn').on('click', function () {
            DepartmentModule.submitAddDepartment();
        });

        //Close Adding Modal:
        $('#add-close-department-modal-btn').on('click', function () {
            DepartmentModule.closeDepartmentAddModal();
        });

        //Edit Department:
        $(document).delegate('.edit-department-modal-btn', 'click', function () {
            DepartmentModule.openDepartmentModal($(this).attr("data-dId"));
        });

        //Delete Department:
        $(document).delegate('.delete-department-btn', 'click', function () {
            DepartmentModule.deleteDepartment($(this).attr("data-dId"));
        });

        //Select Department:
        $(document).delegate('.select-dep-btn', 'click', function () {
            var Id = $(this).attr('data-dId');
            mediator.publish('departmentSelected', Id);
        });

        //Move Department:
        $(document).delegate('ul', 'sortchange', function () {
            var Id = $(this).find('button').attr('data-dId');
            mediator.publish('departmentMovedFrom', Id);
        });

        //Submit Edited Department:
        $(document).delegate('#submit', 'click', function () {
            DepartmentModule.submitEditDepartment($('#department-modal').attr('data-dId'));
        });

        //Subscribe To Company Selection Event:
        mediator.subscribe('CompanySelected', function (CompanyId) {
            DepartmentModule.companyId = CompanyId;
            var departments = JSON.parse(AjaxModule.GetJSON(API.Urls.DepartmentByCompany + CompanyId).responseText);
            $('#companyConteiner').empty();
            DepartmentModule.renderTree(departments);
        });
    },

    closeDepartmentAddModal: function () {
        $('#add-department-modal').modal('hide');
    },

    closeDepartmentEditModal: function () {
        $('#department-modal').modal('hide');
    },

    deleteDepartment: function (Id) {
        AjaxModule.DeleteJSON(API.Urls.DepartmentsUrl, Id);
    },

    addDepartment: function () {
        $('#add-department-modal').modal('show');
    },

    submitAddDepartment: function () {
        var str = $("#adddepform").serialize() + '&' + $.param({ 'CompanyId': this.companyId });
        AjaxModule.PostJSON(API.Urls.DepartmentsUrl, str);
        DepartmentModule.closeDepartmentAddModal();
    },

    submitEditDepartment: function (Id) {
        var str = $("#editdepform").serialize() + '&' + $.param({ 'CompanyId': this.companyId }) + '&' + $.param({ 'IdDepartment': Id });
        AjaxModule.PutJSON(API.Urls.DepartmentsUrl, str, Id);
        DepartmentModule.closeDepartmentEditModal();
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

        return $('<li></li>').append(namediv).append(btndiv).addClass('sortable').attr('data-dId', department.IdDepartment);

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
            (ul).find('li.sortable[data-did= ' + Id + ']').append(intermediateUl);
            ancestorDeps.splice(t, 1);
        }

        if (ancestorDeps.length) {
            DepartmentModule.appendDepartmentToTree(ancestorDeps, ul);
        }

        return ul;
    },

    renderTree: function(departments) {
        $("#companyConteiner").append(DepartmentModule.appendDepartmentToTree(departments, $('<ul></ul>')));
        $('.hideble').hide();
        $("#companyConteiner ul").sortable({
            connectWith: "#companyConteiner ul",
            placeholder: "ui-state-highlight",
            stop: function (event, ui) {
                DepartmentModule.departmentMovedTo(ui.item);
            }
        });

        //Depatment Button Group Setting:
        $('.treeNode').on('mouseover',function () {
            $(this).find('.hideble').show();
        }).on('mouseout', function () {
                $('.hideble').hide();
            });
    },

    departmentMovedTo: function (item) {
        var parent = item.parent().parent().attr('data-dId');
        var Id = item.attr('data-dId');
        var dep = JSON.parse(AjaxModule.GetJSON(API.Urls.DepartmentsUrl + Id).responseText);
        var department = {};
        department.AncestorDepartment_IdDepartment = parent;
        department.Name = dep.Name;
        department.Description = dep.Description;
        department.IdDepartment = Id;
        department.CompanyId = dep.CompanyId;
        AjaxModule.PutJSON(API.Urls.DepartmentsUrl, department, Id);
    },

    openDepartmentModal: function (Id) {
        var departments = JSON.parse(AjaxModule.GetJSON(API.Urls.DepartmentsUrl).responseText);
        for (var i = 0, n = departments.length; i < n; i++) {
            var department = departments[i];
            if (department.IdDepartment == Id) {
                var item = {name: department.Name, description: department.Description};
                $("#target").html(_.template($('#template').html(), {item: item}));
                $('#department-modal').modal('show').attr('data-dId', Id);
            }
        }
    }
};

//?
$("#sortable").sortable().disableSelection();




