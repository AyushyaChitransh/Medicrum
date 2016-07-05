function CheckEmail() {
    var email = document.getElementById("wizard_email").value;
    if (email) {
        var result;
        $.ajax({
            type: 'POST',
            url: 'AddUser.aspx/CheckEmail',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'email': '" + email + "' }",
            async: false,
            success: function (response) {
                if (response.d == false) {
                    document.getElementById("wizard_email").setAttribute("class", "md-input md-input-danger");
                    document.getElementById("emailCheck").style.display = 'block';
                }
                else {
                    document.getElementById("wizard_email").setAttribute("class", "md-input md-input-success");
                    document.getElementById("emailCheck").style.display = 'none';
                }
                result = response.d;
            },
            error: function (error) {
                alert("Failed!");
            }
        });
        return result;
    }
}
function CheckUserName() {
    var userName = document.getElementById("wizard_user_name").value;
    if (userName) {
        var result;
        $.ajax({
            type: 'POST',
            url: 'AddUser.aspx/CheckUserName',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'userName': '" + userName + "' }",
            async: false,
            success: function (response) {
                if (response.d == false) {
                    document.getElementById("wizard_user_name").setAttribute("class", "md-input md-input-danger");
                    document.getElementById("userNameCheck").style.display = 'block';
                    $('#button').prop("disabled", true);
                }
                else {
                    document.getElementById("wizard_user_name").setAttribute("class", "md-input md-input-success");
                    document.getElementById("userNameCheck").style.display = 'none';
                    $('#button').prop("disabled", false);
                }
                result = response.d;
            },
            error: function (error) {
                alert("Failed!");
            }
        });
        return result;
    }
}