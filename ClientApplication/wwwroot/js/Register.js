$(document).ready(function () {
    $('#registerForm').submit(function (e) {
        e.preventDefault();
        var username = $('#registerUsername').val();
        var password = $('#registerPassword').val();
        var accessType = $('#registerAccessType').val();

        $.ajax({
            type: "POST",
            url: "https://localhost:7284/" + accessType + "/Register", // Update URL with your API project URL
            contentType: "application/json",
            data: JSON.stringify({ username: username, password: password }),
            success: function (response) {
                alert(response);
                // Redirect to login page or perform other actions based on the response
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
});
