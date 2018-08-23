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
    });
    return output;
}

function getappinfo(jsonString) {
    var output;
    $.ajax({
        type: "POST",
        async: false,
        url: "/api/app",
        data: jsonString,
        contentType: 'application/json; charset=utf-8',
        dataType: "text",
        success: function (data) {
            output = data;
        }
    });
    return output;
}

function render(jsonString) {
    var str = "";
    var item = JSON.parse(jsonString);

    str += "<div class=\"divTableRow\">";

    str += "<div class=\"divTableCell\"><a href=\"https://play.google.com/store/apps/details?id=@item.PackageName\" target=\"_blank\">" + item.PackageName + "</a></div>";
    str += "<div class=\"divTableCell\">" + item.AppName + "</div>";
    str += "<div class=\"divTableCell\"><img src=" + item.IconUrl + " width=\"60\" height=\"60\" /></div>";
    str += "<div class=\"divTableDescriptionCell\">" + getdescr(item.Description) + "</div>";

    str += "</div>";


    return str;
}

function getdescr(descr) {
    if (descr.length > 100) {
        return descr.substr(0, 100) + "...";
    }
    else return descr;
}