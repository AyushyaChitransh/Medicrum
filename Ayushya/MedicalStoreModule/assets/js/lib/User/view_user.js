function ViewDetailedUser(userName) {
    $.ajax({
        type: 'POST',
        url: 'ViewUser.aspx/SetUserSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'userName': " + userName + " }",
        success: function () {
        },
        error: function (error) {
            alert("Failed!");
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedUser.aspx", '_blank');
    }, 500);
}