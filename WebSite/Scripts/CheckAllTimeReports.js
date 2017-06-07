//Выделение всех чекбоксов, при нажатии на чекбокс("Выделить всё!")
$(".checkALL").change(function () {
    if ($(".checkALL").prop("checked")) {
        $(".timeReports").not(":disabled").prop("checked", true);
        $(".timeReports").not(":disabled").prop("id", 2);

    } else {
        $(".timeReports").prop("checked", false);
        $(".timeReports").prop("id", 1);
    }
});

//function AddTeamMember() {
//    var valueTimeMember = $("[id = 'dropDownListTeamMember'] option:selected").text();
//    var valueRoleInProject = $("[id = 'dropDownListRole'] option:selected").text();
//    $("div#AddTeamMember").before("<h4 class = 'GenerationHtmlCode'>" + valueTimeMember + " / " + valueRoleInProject + "   <input type='button' value='Delete' class='btn btn-default' onclick='DeleteHtml()'/></h4>");
//}

//function AddTasks() {
//    var valueTasks = $("[id = 'dropDownListTasks'] option:selected").text();
//    $("div#AddTasks").before("<h4 class = 'GenerationHtmlCode'>" + valueTasks + "   <input type='button' value='Delete' class='btn btn-default' onclick='DeleteHtml()'/></h4>");
//}

function AddTeamMember() {
    var valueTimeMember = $("[id = 'dropDownListTeamMember'] option:selected").text();
    var valueRoleInProject = $("[id = 'dropDownListRole'] option:selected").text();
    var idTimeMember = $("[id = 'dropDownListTeamMember']").val();
    var idRoleInProject = $("[id = 'dropDownListRole']").val();
    $("table#AddTeamMember").append("<tr class = 'GenerationHtmlCode'><input type = 'hidden' value = " + idTimeMember + " name = 'idTimeMember'/><input type = 'hidden' value = " + idRoleInProject + "  name = 'idRoleInProject'/><td>" + valueTimeMember + "</td><td>" + valueRoleInProject + "</td><td><input type='button' value='Delete' class='btn btn-default' onclick='DeleteHtml(this)'/></td></tr>");
}

function AddTasks() {
    var valueTasks = $("[id = 'dropDownListTasks'] option:selected").text();
    var idTasks = $("[id = 'dropDownListTasks']").val();
    $("table#AddTasks").append("<tr class = 'GenerationHtmlCode'><input type = 'hidden' value = " + idTasks + " name = 'idTasks'/><td>" + valueTasks + "</td><td><input type='button' value='Delete' class='btn btn-default' onclick='DeleteHtml(this)'/></td></tr>");
}

$(".timeReports").change(function () {
    if ($(".timeReports").not(":disabled").prop("checked")) {
        $(".timeReports").prop("id", 2);
    } else {
        $(".timeReports").prop("id", 1);
    }
});


(function accept(elements) {
    if ($(".timeReports").not(":disabled").prop("id") == 2) {
        $.ajax({
            url: window.DECLINE_REPORT_URL,
            success: function () {
                if ($(".timeReports").prop("name") == $(elements).prop("Id")) {
                    $(elements).prop("Status", "Accept");
                }
            }
        });
    }
});



function DeleteHtml(e) {
    e.parentNode.parentNode.remove();
}