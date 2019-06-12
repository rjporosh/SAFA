function Add() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var obj = {

        //"ReligionId": $('#ReligionId').val(),

        "ReligionName": $('#ReligionName').val()


    };
    //debugger;
    $.ajax({
        
        url: "/Religious/add_religion",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status) {
                clearTextBox();
                $('#message').addClass('alert alert-success').html("<strong>" + result.message + "</strong>").show(200).delay(2500).hide(200);
                $("#mydatatable").dataTable().fnDestroy();
                loadData();


            }
            else {

                $('#message').addClass('alert alert-danger').html("<strong>" + result.message + "</strong>").show(200).delay(2500).hide(200);




            }


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
