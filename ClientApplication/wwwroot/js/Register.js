$(document).ready(function () {
    $('#registerForm').submit(function (e) {
        e.preventDefault();
        var username = $('#registerUsername').val();
        var password = $('#registerPassword').val();
        var accessType = $('#registerAccessType').val();

        $.ajax({
            type: "POST",
            url: "https://localhost:7284/" + accessType + "/Register",
            contentType: "application/json",
            data: JSON.stringify({ username: username, password: password }),
            success: function (response) {
                // Display registration success message
                alert("Registration Successful");

                // Optionally, you can redirect to the login page after successful registration
                window.location.href = '/Home/Login';
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    });
});
