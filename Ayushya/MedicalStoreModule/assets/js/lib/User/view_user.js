function ViewDetailedUser(userName) {
    $.ajax({
        type: 'POST',
        url: 'UserList.aspx/SetUserSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'userName': '" + userName + "' }",
        success: function () {
        },
        error: function (error) {
            Notification('u');
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedUser.aspx", '_blank');
    }, 500);
}