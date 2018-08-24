
function render(jsonString) {

    var table = "";
    var item = JSON.parse(jsonString);

    table += "<div class=\"divTableRow\">";


    table += "<div class=\"divTableCell\"><a href=\"https://play.google.com/store/apps/details?id=" + item.PackageName + "\" target=\"_blank\">" + item.PackageName + "</a></div>";
    table += "<div class=\"divTableCell\">" + item.AppName + "</div>";
    table += "<div class=\"divTableCell\"><img src=\"" + item.IconUrl + "\" width=\"60\" height=\"60\" /></div>";
    table += "<div class=\"divTableDescriptionCell\">" + getdescr(item.Description) + "</div>";
    table += "<div class=\"divTableCell\">" + item.AveregeRate + "</div>";
    table += "<div class=\"divTableCell\">" + item.RateCount + "</div>";
    table += "<div class=\"divTableCell\">" + item.InstallCount + "</div>";
    table += "<div class=\"divTableDescriptionCell\">" + getdescr(item.NewInfo) + "</div>";
    table += "<div class=\"divTableCell\">" + item.LastUpdate + "</div>";
    table += "<div class=\"divTableCell\">" + item.DevEmail + "</div>";
    table += "<div class=\"divTableCell\">" + item.Price + "</div>";
    table += "<div class=\"divTableCell\">" + item.MicroPrice + "</div>";

    table += "<div id='btn-show-modal' onclick=\"modal(\'" + item.Images + "\')\">Скриншоты</div>";

    table += "</div>";



    return table;
}

function getdescr(descr) {
    if (descr.length > 100) {
        return descr.substr(0, 100) + "...";
    }
    else return descr;
}

function getimages(listscr) {
    var response = "";
    listscr.forEach(function (item) {
        response += "<div>";
        response += "<img src = \"" + item + "\"/>";
        response += "</div>";
    });
    return response;
}
