$(document).ready(function () {
    $("#myTable").hide();
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
                $("#myTable").show();
                $("#tableBody").empty();
                var jsnData = { Id: StudentId };
                $.ajax({

                    type: "POST",
                    url: '/Student/GetCoursesResultByStudent',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(jsnData),
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        
                        $.each(data, function (key, value) {
                            $("#tableBody").append('<tr><td>' + value.Code + '</td><td>' + value.Name + '</td><td>' + value.CourseGrade + '</td></tr>');
                        });
                    }
                });
            }
        });

    });

});


