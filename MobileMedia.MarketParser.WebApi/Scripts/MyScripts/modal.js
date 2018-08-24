function modal(name) {
    $('#modal-window').toggleClass('visible');

    var images = name.split(",");
    var response = "";
    images.forEach(function (item) {
        response += "<a href=\"" + item + "\" target=\"_blank\"><img src=\"" + item + "\" width=\"86\" height=\"155\"/></a>";
    });
    $("#modal-window > .modal-content").html(response || "");
}

$(document).on("mousedown", function (e) {
    $(document).on("mousedown", function (e) {
        if (
            $("#modal-window").hasClass('visible')
            && e.target.className === 'modal-close'
            || !$("#modal-window")[0].contains(e.target)
        ) {
            $("#modal-window").removeClass("visible");
        }
    });
});
