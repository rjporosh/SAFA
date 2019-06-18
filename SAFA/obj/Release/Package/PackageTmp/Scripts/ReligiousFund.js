

$(document).ready(function () {

    loadData();


});



//Load Data 




function loadData() {

    $('#myDataTable_wrapper .dataTables_filter input').addClass("input-medium "); $('#myDataTable_wrapper .dataTables_length select').addClass("select2-wrapper span12");


    $('#myDataTable').DataTable({

        "sDom": "<'row'<'col-md-6'l <'toolbar'>><'col-md-6'f>r>t<'row'<'col-md-12'p i>>",



        ajax: {

            url: '/Religious/GetByAjax',
            dataSrc: ""

        },

        columns: [
            {
                data: "ReligiousFundTypeId"
            },
            {
                data: "ReligiousFundTypeName"
            },

            {
                data: "CreatedDate"
            },

           {
               data: "CreatedBy"
           },
            {
                data: "UpdatedDate"
            },
             {
                 data: "UpdatedBy"
             },
              {
                  data: "IsActive"
              },
            {
                render: function (data, type, obj) {
                    return "<div class='btn-group'><a href='#' class='btn btn-primary waves-effect waves-light' onclick='return getbyID(" + obj.Id + ")'>Edit</a>" +
                        "<a href='#' class='btn btn-danger waves-effect waves-light' onclick='Delete(" + obj.Id + ")'>Delete</a></div>";
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

    $('#Code').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Area/GetbyID/" + id,
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



//Add Data Function   
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

                loadData();


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

                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

}


//Valdidation using jquery  
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