$(document).ready(function () {

    //$('#sort-id, #sort-name').removeClass('asc desc');

    //if (location.search == "?sortOrder=id_asc") {
    //    $("#sort-id").addClass("asc");
    //}

    //else if (location.search == "?sortOrder=id_desc") {
    //    $("#sort-id").addClass("desc");
    //}

    //else if (location.search == "?sortOrder=name_asc") {
    //    $("#sort-name").addClass("asc");
    //}

    //else if (location.search == "?sortOrder=name_desc") {
    //    $("#sort-name").addClass("desc");
    //}

    //else if (location.search == "?sortOrder=lastname_asc") {
    //    $("#sort-lastname").addClass("asc");
    //}

    //else if (location.search == "?sortOrder=lastname_desc") {
    //    $("#sort-lastname").addClass("desc");
    //}

    if (location.search != "?ReturnUrl=%2FStudents%2FIndex" || location.search != "?ReturnUrl=%2FStudent_Oceny%2FIndex" || location.search != "") {
        $("#log-out").removeClass("login-hidden");
        $("#log-in").addClass("login-hidden");
    }
    else {
        $("#log-out").addClass("login-hidden");
        $("#log-in").removeClass("login-hidden");
    }
});

//djncskjnsk