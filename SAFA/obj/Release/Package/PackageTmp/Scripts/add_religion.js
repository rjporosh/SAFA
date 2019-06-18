$(document).ready(function () {

    loadData();




});









//Load Data function 2nd wayyyyyyyy  


function loadData() {



    $('#mydatatable').DataTable({




        ajax: {

            url: '/Religious/GetByAjax',
            dataSrc: ""

        },

        columns: [

            {
                data: "ReligionName"
            },

            {
                render: function (data, type, organization) {
                    return "<div class='btn-group'><a href='#' class='btn btn-primary' onclick='return getbyID(" + organization.Id + ")'>Edit</a><a href='#' class='btn btn-danger' onclick='Delete(" + organization.Id + ")'>Delete</a></div>";
                }
            }
        ]


    });


}


//Function for getting the Data Based upon Class
function getbyID(id) {
    $('#Name').css('border-color', 'lightgrey');



    $.ajax({
        url: "/Bank/GetbyID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ReligionId').val(result.ReligionId);

            $('#ReligionName').val(result.ReligionName);




            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#myCustomForm')[0].reset();
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var obj = {

        "ReligionId": $('#ReligionId').val(),


        "ReligionName": $('#ReligionName').val()


    };
   
    $.ajax({
        
        url: "/Religious/add_religion",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
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

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var obj = {

        //"Id": $('#Id').val(),
        "ReligionId": $('#ReligionId').val(),

        "ReligionName": $('#ReligionName').val()

    };

    $.ajax({
        url: "/Religious/Edit",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            if (result.status) {


                $('#message').addClass('alert alert-success').html("<strong>" + result.message + "</strong>").show(200).delay(2500).hide(200);
                $("#mydatatable").dataTable().fnDestroy();
                loadData();



            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}

function Delete(id) {

    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Religious/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $("#mydatatable").dataTable().fnDestroy();
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

}

function clearTextBox() {
    $('#myCustomForm')[0].reset();
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}
function validate() {
    var isValid = true;

    if ($('#ReligionName').val().trim() == "") {
        $('#ReligionName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ReligionName').css('border-color', 'lightgrey');
    }



    return isValid;
}