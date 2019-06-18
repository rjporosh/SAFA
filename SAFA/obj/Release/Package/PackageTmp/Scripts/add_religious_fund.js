$(document).ready(function () {

    loadData();




});









//Load Data function 2nd wayyyyyyyy  


function loadData() {



    $('#mydatatable').DataTable({




        ajax: {

            url: '/Religious/GetByAjaxFund',
            dataSrc: ""

        },

        columns: [

            {
                data: "ReligiousFundTypeName"
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
    $('#ReligiousFundTypeName').css('border-color', 'lightgrey');



    $.ajax({
        url: "/Religious/GetbyID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ReligiousFundTypeId').val(result.ReligiousFundTypeId);

            $('#ReligiousFundTypeName').val(result.ReligiousFundTypeName);




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

        "ReligiousFundTypeId": $('#ReligiousFundTypeId').val(),


        "ReligiousFundTypeName": $('#ReligiousFundTypeName').val()


    };

    $.ajax({

        url: "/Religious/Create",
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

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var obj = {

        //"Id": $('#Id').val(),
        "ReligiousFundTypeId": $('#ReligiousFundTypeId').val(),

        "ReligiousFundTypeName": $('#ReligiousFundTypeName').val()

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

    if ($('#ReligiousFundTypeName').val().trim() == "") {
        $('#ReligiousFundTypeName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ReligiousFundTypeName').css('border-color', 'lightgrey');
    }



    return isValid;
}