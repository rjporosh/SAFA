$(document).ready(function () {


    loadData();




});









//Load Data function 2nd wayyyyyyyy  

function loadData() {

    $('#myDataTable_wrapper .dataTables_filter input').addClass("input-medium "); $('#myDataTable_wrapper .dataTables_length select').addClass("select2-wrapper span12");


    $('#myDataTable').DataTable({

        "sDom": "<'row'<'col-md-6'l <'toolbar'>><'col-md-6'f>r>t<'row'<'col-md-12'p i>>",



        ajax: {

            url: '/Charitable/GetByAjax',
            dataSrc: ""

        },

        columns: [
            {
                data: "CharitableFundTypeName"
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
        url: "/Charitable/GetbyID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CharitableFundTypeId').val(result.CharitableFundTypeId);

            $('#CharitableFundTypeName').val(result.CharitableFundTypeName);




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

        "CharitableFundTypeId": $('#CharitableFundTypeId').val(),


        "CharitableFundTypeName": $('#CharitableFundTypeName').val()


    };

    $.ajax({

        url: "/Charitable/add_charitable_fund",
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
        "CharitableFundTypeId": $('#CharitableFundTypeId').val(),

        "CharitableFundTypeName": $('#CharitableFundTypeName').val()

    };

    $.ajax({
        url: "/Charitable/Edit",
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
            url: "/Charitable/Delete/" + id,
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

    if ($('#CharitableFundTypeName').val().trim() == "") {
        $('#CharitableFundTypeName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CharitableFundTypeName').css('border-color', 'lightgrey');
    }



    return isValid;
}