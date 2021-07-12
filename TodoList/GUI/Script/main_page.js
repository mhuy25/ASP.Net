
/* TABLE */
function Table() {
    load_modal();
}
function load_modal() {
    $("#insert_employee").click(function () {
        var name = document.getElementById("employee_name");
        var email = document.getElementById("employee_email");
        var password = document.getElementById("employee_password");
        var role = document.getElementById("employee_role");
        
        if(name.value != "" && email.value != ""  && password.value != "" && role.value != "")
        {
            var value = name.value + "|" + email.value + "|" + password.value + "|" + role.value;
            console.log(JSON.stringify(value));
            $.ajax({
                type: "POST",
                url: "Load_Content.aspx/Insert_Employee",
                contentType: "application/json",
                data: "{'value':'" + JSON.stringify(value) + "'}",
                dataType: "json",
                sucess: function (msg) { },
                error: function (xhr, status, error) {
                    alert("XHR: " + xhr);
                    alert("Status: " + status);
                    alert("Error: " + error)
                }
            });
        }
        else
        {
            alert("Dữ liệu của nhân viên không được bỏ trống");
        }
    });

    $(".admin_management").click(function () {
        $.ajax({
            type: "POST",
            url: "Load_Content.aspx/load_table_employee",
            contentType: "application/json",
            dataType: "json",
            sucess: function (msg) {},
            error: function (xhr, status, error) {
                alert("XHR: " + xhr);
                alert("Status: " + status);
                alert("Error: " + error)
            }
        }).done(function (data) {
            document.getElementById("content").innerHTML = data.d;
        });
    });

    $(".info_btn").click(function () {
        var id = $(this).closest("tr").find(".job_id").text();
        console.log(id);
        $.ajax({
            type: "POST",
            url: "Load_Content.aspx/load_table_info",
            data: "{'value':'" + JSON.stringify(id) + "'}",
            contentType: "application/json",
            dataType: "json",
            sucess: function (msg) { },
            error: function (xhr, status, error) {
                alert("XHR: " + xhr);
                alert("Status: " + status);
                alert("Error: " + error)
            }
        }).done(function (data) {
            document.getElementById('info_container').innerHTML = data.d;
        });
    })

    $("#add_row").on('click', function () {
        document.getElementById("job_title").value = "";
        document.getElementById("startDate").value = "";
        document.getElementById("endDate").value = "";
    });

    $("#create_btn").on("click", function () {
            var job_title = document.getElementById("job_title");
            var startDate = document.getElementById("startDate");
            var endDate = document.getElementById("endDate");
            var job_range = $("#job_range").val();
            if (Validate(job_title, startDate, endDate))
            {
                var object = new Object();
                var arrayOfID = [];
                $('input:checkbox:checked', table_employee).each(function () {
                    var str =
                        $(this).closest('tr').find('.nv_id').text() + "|" +
                        $(this).closest('tr').find('.nv_name').text() + "|" +
                        $(this).closest('tr').find('.nv_email').text() + "|" +
                        $(this).closest('tr').find('.nv_role').text();
                    arrayOfID.push(str);
                }).get();
                text = job_title.value + "|" + startDate.value + "|" + endDate.value + "|" + job_range;

                var values = new Array();

                if (arrayOfID.length != 0) {
                    var array = [];
                    for (var i = 0; i < arrayOfID.length ; i++) {
                        //valuesID[i] = arrayOfID[i].split("|")[0];
                        values.push(new Array(arrayOfID[i].split("|")[0]));
                    }
                    values.push(new Array(text));
                    console.log(values);
                    $.ajax({
                        type: "POST",
                        url: "transfer_data.aspx/Insert",
                        data: "{'value':'" + JSON.stringify(values) + "'}",
                        contentType: "application/json",
                        dataType: "json",
                        sucess: function (msg) {},
                        error: function (xhr, status, error) {
                            alert("XHR: " + xhr);
                            alert("Status: " + status);
                            alert("Error: " + error)
                        }
                    }).done(function () {
                        location.reload(true);
                    });
                }
                console.log("Valid form");
            }
            else {
                alert("Dữ liệu bạn vừa thêm khôg hợp lệ");
            }
    });

    $(".edit_btn").click(function () {
        var arrayOfValues = [];
        var item = $(this).closest("tr").find(".job_id").text() + "|" +
                   $(this).closest("tr").find(".job_title").text() + "|" +
                   $(this).closest("tr").find(".job_startDate").text() + "|" +
                   $(this).closest("tr").find(".job_finishDate").text() + "|" +
                   $(this).closest("tr").find(".job_Range").text();
        arrayOfValues = item.split('|');
        document.getElementById("edit_job_id").value = arrayOfValues[0];
        document.getElementById("edit_job_title").value = arrayOfValues[1];
        document.getElementById("edit_startDate").value = arrayOfValues[2];
        document.getElementById("edit_endDate").value = arrayOfValues[3];
        document.getElementById("edit_job_range").value = arrayOfValues[4];
        var values = new Array();
        for (var i = 0; i < arrayOfValues.length; i++) {
            values.push(new Array(arrayOfValues[i]));
        }
        console.log(values[0]);
        $.ajax({
            type: "POST",
            url: "dashboard_page.aspx/load_edit_table",
            data: "{'value':'" + JSON.stringify(values) + "'}",
            contentType: "application/json",
            dataType: "json",
            sucess: function (data) {
                
            },
            error: function (xhr, status, error) {
                alert("XHR: " + xhr);
                alert("Status: " + status);
                alert("Error: " + error)
            }
        }).done(function (data) {
            document.getElementById("edit_table_employee").innerHTML = data.d;
        });
    });

    $(".del").click(function () {
        if (confirm("Bạn có muốn xoá dữ liệu này không ?"))
        {
            var item = $(this).closest("tr").find(".job_id").text();

            $.ajax({
                type: "POST",
                url: "dashboard_page.aspx/Delete",
                contentType: "application/json; charset=UTF-8",
                dataType: "json",
                data: "{'value':'" + item + "'}",
                sucess: function (msg) { },
                error: function (xhr, status, error) {
                    alert("XHR: " + xhr);
                    alert("Status: " + status);
                    alert("Error: " + error)
                }
            }).done(function () {
                location.reload(true);
            });
        }
    });

    $("#edit_btn").click(function () {
        var job_id = document.getElementById("edit_job_id");
        var job_title = document.getElementById("edit_job_title");
        var startDate = document.getElementById("edit_startDate");
        var endDate = document.getElementById("edit_endDate");
        var job_range = $("#edit_job_range").val();
        var object = new Object();
        var arrayOfID = [];
        $('input:checkbox:checked', table_edit_employee).each(function () {
            var str =
                $(this).closest('tr').find('.nv_id').text() + "|" +
                $(this).closest('tr').find('.nv_name').text() + "|" +
                $(this).closest('tr').find('.nv_email').text() + "|" +
                $(this).closest('tr').find('.nv_role').text();
            arrayOfID.push(str);
        }).get();
        text = job_id.value + "|" + job_title.value + "|" + startDate.value + "|" + endDate.value + "|" + job_range;
        console.log(text);
        console.log("array: " + arrayOfID);
        var values = new Array();
        if (arrayOfID.length != 0) {
            var array = [];
            for (var i = 0; i < arrayOfID.length ; i++) {
                //valuesID[i] = arrayOfID[i].split("|")[0];
                values.push(new Array(arrayOfID[i].split("|")[0]));
            }
            values.push(new Array(text));
            console.log(values);
            $.ajax({
                type: "POST",
                url: "dashboard_page.aspx/Update_Job",
                data: "{'value':'" + JSON.stringify(values) + "'}",
                contentType: "application/json",
                dataType: "json",
                sucess: function (msg) { },
                error: function (xhr, status, error) {
                    alert("XHR: " + xhr);
                    alert("Status: " + status);
                    alert("Error: " + error)
                }
            }).done(function () {
                location.reload(true);
            });
        }
        else {
            alert("Bạn chưa chọn nhân viên cho công việc này");
        }
    });

    $(".finish_btn").click(function () {
        var id = $(this).closest('tr').find('.job_id').text();
        $.ajax({
            type: "POST",
            url: "dashboard_page.aspx/Change_Finish",
            data: "{'value':'" + JSON.stringify(id) + "'}",
            contentType: "application/json",
            dataType: "json",
            sucess: function (msg) { },
            error: function (xhr, status, error) {
                alert("XHR: " + xhr);
                alert("Status: " + status);
                alert("Error: " + error)
            }
        }).done(function () {
            location.reload(true);
        });
    });
}

function Validate(job_title, startDate, endDate) {
    if (job_title.value == "")
    {
        job_title.focus();
        return false;
    }
    else if(!Check_Date(startDate.value, endDate.value))
    {
        console.log("Invalid date");
        return false;
    }
    return true;
}

function Check_Date(date1, date2) {
    if (date1 == "" || date2 == "")
    {
        return false;
    }
    else
    {
        console.log(date1 > date2);
        if (date1 > date2) {
            return false;
        }
        return true;
    }
}
