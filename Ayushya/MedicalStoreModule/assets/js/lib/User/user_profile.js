$(function () {
    $.ajax({
        type: 'POST',
        url: 'UserProfile.aspx/GetUser',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Loading Details...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        success: function (response) {
            var arr = JSON.parse(response.d);
            document.getElementById("user_name").value = arr.userName;
            document.getElementById("name").innerHTML = arr.name;
            if(arr.role === 1)
                document.getElementById("role").value = "Admin";
            else
                document.getElementById("role").value = "User";
            document.getElementById("email").value = arr.email;
            document.getElementById("address").value = arr.address;
            document.getElementById("phone_number").value = arr.phoneNumber;
        },
        error: function (error) {
            Notification('u');
        }
    });
});