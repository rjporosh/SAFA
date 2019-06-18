$(document).ready(function () {


    loadData();




});









//Load Data function 2nd wayyyyyyyy  

function loadData() {

    $('#myDataTable_wrapper .dataTables_filter input').addClass("input-medium "); $('#myDataTable_wrapper .dataTables_length select').addClass("select2-wrapper span12");


    $('#myDataTable').DataTable({

        "sDom": "<'row'<'col-md-6'l <'toolbar'>><'col-md-6'f>r>t<'row'<'col-md-12'p i>>",



        ajax: {

            url: '/Bank/GetByAjax',
            dataSrc: ""

        },

        columns: [
            {
                data: "PaymentTypeName"
            },

            {
                render: function (data, type, obj) {
                    return "<div class='btn-group'><a href='#' class='btn btn-primary' onclick='return getbyID(" + obj.Id + ")'>Edit</a><a href='#' class='btn btn-danger waves-effect waves-light' onclick='Delete(" + obj.Id + ")'>Delete</a></div>";
                }
            }
        ],

        fixedColumns: {
            rightColumns: 1
        },



        "bDestroy": true
    });

    $("div.toolbar").html('<div class="table-tools-actions"><button style="margin-left:20px;width: 90px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="clearTextBox();">Add</button></div>');
    $("#mydatatable").dataTable().fnDestroy();
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
            $('#PaymentTypeId').val(result.PaymentTypeId);

            $('#PaymentTypeName').val(result.PaymentTypeName);




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

        "PaymentTypeId": $('#PaymentTypeId').val(),


        "PaymentTypeName": $('#PaymentTypeName').val()


    };

    $.ajax({

        url: "/Bank/add_id_proof",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            if (result.status) {
                clearTextBox();
                $('#message').addClass('alert alert-success').html("<strong>" + result.message + "</strong>").show(200).delay(2500).hide(200);
                $("#myDataTable").dataTable().fnDestroy();
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
        "PaymentTypeId": $('#PaymentTypeId').val(),

        "PaymentTypeName": $('#PaymentTypeName').val()

    };

    $.ajax({
        url: "/Bank/Edit",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            if (result.status) {


                $('#message').addClass('alert alert-success').html("<strong>" + result.message + "</strong>").show(200).delay(2500).hide(200);
                $("#myDataTable").dataTable().fnDestroy();
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
            url: "/Bank/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $("#myDataTable").dataTable().fnDestroy();
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

    if ($('#PaymentTypeName').val().trim() == "") {
        $('#PaymentTypeName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PaymentTypeName').css('border-color', 'lightgrey');
    }



    return isValid;
}