function UpdatePassword() {
    var password = document.getElementById('login_password').value;
    var passwordConfirmation = document.getElementById('login_password_confirm').value;
    if (password != passwordConfirmation) {
        UIkit.modal.alert('Passwords do not match!');
        // passwords do not match notification to be sent
    }
    else {
        $.ajax({
            type: 'POST',
            url: 'ResetPassword.aspx/UpdatePassword',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'password': '" + password + "' }",
            success: function (response) {
                if (response.d == true) {
                    window.location = "Dashboard.aspx";
                }
            },
            error: function (error) {
                Notification('u');
            }
        });
    }
}