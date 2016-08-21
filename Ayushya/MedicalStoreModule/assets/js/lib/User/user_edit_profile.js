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
            document.getElementById("name").value = arr.name;
            document.getElementById("address").value = arr.address;
            document.getElementById("phone_number").value = arr.phoneNumber;
        },
        error: function (error) {
            Notification('u');
        }
    });
});

function EditUser()
{
    var name = document.getElementById("name").value,
        address = document.getElementById("address").value,
        number = document.getElementById("phone_number").value;
    $.ajax({
        type: 'POST',
        url: 'UserProfileEdit.aspx/EditUserDetails',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'name': '" + name + "', 'address': '" + address + "', 'number': '" + number + "' }",
        dataType: "json",
        success: function (response) {
            if (response.d == true) {
                Notification('s');
                setTimeout(function () {
                    window.location = "UserProfile.aspx";
                }, 1000);
            }
            else
                Notification('e');
        },
        error: function (error) {
            Notification('u');
        }
    });
}