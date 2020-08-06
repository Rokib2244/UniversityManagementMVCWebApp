$(document).ready(function () {
    $("#registrationNoDropDownList").change(function () {
        //$("")

        var studentId = $("#registrationNoDropDownList").val();
        var jasnData = { Id: studentId };

        $.ajax({

            type: "POST",
            url: '/Course/GetStudentInfoById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasnData),
            dataType: "json",
            success: function (data) {
                $("#nameTextBox").val(data["Name"]);
                $("#emailTextBox").val(data["Email"]);
                $("#departmentTextBox").val(data["DepartmentName"]);
                document.getElementById("departmentTextBox").classList.add(data["ID"]);
                console.log(data);
            },
            complete: function () {
                var StudentId = parseInt(document.getElementById("departmentTextBox").classList[1], 10);
                document.getElementById("departmentTextBox").classList.remove(StudentId);
                console.log(StudentId);
                var jsnData = { Id: StudentId };
                $.ajax({

                    type: "POST",
                    url: '/Student/GetCoursesByStudent',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(jsnData),
                    dataType: "json",
                    success: function (data) {

                        $("#courseDropDownList").empty().append("<option value='0'>--Select a Course--</option>");
                        $.each(data, function (key, value) {
                            $("#courseDropDownList").append("<option value=" + value.CourseID + ">" + value.CourseName + "</option>");
                        });
                    }
                });
            }
        });

    });
});

