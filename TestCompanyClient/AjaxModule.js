var AjaxModule = {
    GetJSON: function (url) {
        return $.ajax({
            type: "GET",
            url: url,
            async: false,
            dataType: "application/json"
        });
    },

    PutJSON: function (url, data, Id) {
        $.ajax({
            url: url + Id,
            type: 'PUT',
            data: data,
            success: function () {
                alert('Entity has been modified');
            }
        });
    },

    PostJSON: function (url, data) {
        $.ajax({
            url: url,
            type: 'POST',
            data: data,
            success: function () {
                alert('New entity has been added');
            }
        });
    },

    DeleteJSON: function (url, id) {
        $.ajax({
            url: url + id,
            type: 'DELETE',
            crossDomain: true,
            success: function () {
                alert('Entity has been deleted');
            }
        });
    }
};
