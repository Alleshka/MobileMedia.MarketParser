function getappsinfo(jsonString) {
    var output;
    $.ajax({
        type: "POST",
        async: false,
        url: "/api/apps",
        data: jsonString,
        contentType: 'application/json; charset=utf-8',
        dataType: "text",
        success: function (data) {
            output = data;
        }
    }).fail(function (data) {
        console.error(data);
        alert(data.responseText);
    });
    return output;
}

function getappinfo(jsonString) {
    var output;
    var ajax = $.ajax({
        type: "POST",
        async: false,
        url: "/api/app",
        data: jsonString,
        contentType: 'application/json; charset=utf-8',
        dataType: "text",
    });
    ajax.done(function (data) {
        output = data;
    });
    ajax.fail(function (data) {
        console.error(data);
        alert(data.responseText);
    });

    return output;
}
