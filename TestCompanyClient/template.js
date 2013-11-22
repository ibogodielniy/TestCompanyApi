$("#selector").jstree({
    "plugins": ["json_data"],
    "json_data": {
        "ajax": {
            "url": "http://localhost:15571/api/department/", // получаем наш JSON
            "data": function (n) {
                // необходиый коллбэк
            }
        }
    }
});