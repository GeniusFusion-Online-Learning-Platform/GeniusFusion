//$(document).ready(function () {
//    $('#loginForm').submit(function (e) {
//        e.preventDefault();
//        var username = $('#username').val();
//        var password = $('#password').val();
//        var accessType = $('#accessType').val();

//        $.ajax({
//            type: "POST",
//            url: "https://localhost:7284/" + accessType + "/Login", // Update URL with your API project URL
//            contentType: "application/json",
//            data: JSON.stringify({ username: username, password: password }),
//            success: function (response) {
//                alert(response);
//                // Redirect to dashboard or perform other actions based on the response
//            },
//            error: function (xhr, status, error) {
//                alert(xhr.responseText);
//        });
//    });
//});


$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        e.preventDefault();
        var username = $('#username').val();
        var password = $('#password').val();
        var accessType = $('#accessType').val();

        $.ajax({
            type: "POST",
            url: "https://localhost:7284/" + accessType + "/Login", 
            contentType: "application/json",
            data: JSON.stringify({ username: username, password: password }),
            success: function (response) {
                alert(response);
                if (response === "Login successful" && accessType === "Admin") {
                    window.location.href = '/Home/AdminDashboard';
                }
                else if (response == "Login successful" && accessType == "Student")
                {
                    window.location.href = '/Home/StudentDashBoard';
                }
                else if (response == "Login successful" && accessType == "Faculty")
                {
                    window.location.href = '/Home/FacultyDashboard';
                }
                
                else {
                    alert("Something Went Wrong!");
                }
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
});

