$(document).ready(function () {
    $("table").hide();
    $("#departmentDropDownList").change(function() {
        
        //$("#courseDropDownList").empty();
        var departmentId = $("#departmentDropDownList").val();
        var jasonData = { id: departmentId };

        $.ajax({
            type: "POST",
            url: '/ClassRoom/Schedule',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jasonData),
            dataType: "json",
            success: function(data) {
                $("table").show();
                //$("#courseDropDownList").append('<option value=0>--Select a Course--</option>');
                $("tbody").empty();
                console.log(data);
                $.each(data, function(key, value) {
                    var schedule = "";
                    for(var s=0; s<value.ClassRoomAllocations.length;s++) {
                        if (value.ClassRoomAllocations[s].Day.length === 0) {
                            schedule += "<span>Not Scheduled Yet.</span>";
                            break;
                        } else {
                            schedule += "<span>R. No :" + value.ClassRoomAllocations[s].RoomName + "," + value.ClassRoomAllocations[s].Day + "," + value.ClassRoomAllocations[s].FromTime + "-" + value.ClassRoomAllocations[s].ToTime + ";</span><br />";
                        }
                    }
                    $("tbody").append('<tr><td>' + value.Code + '</td><td>' + value.Name + '</td><td>' + schedule);

                });
            },

        });
    });
});