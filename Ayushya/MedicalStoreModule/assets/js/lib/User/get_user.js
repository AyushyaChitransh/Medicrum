﻿$(function () {
    $.ajax({
        type: 'POST',
        url: 'ViewDetailedUser.aspx/GetUser',
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
            document.getElementById("name").value = arr.name;
            document.getElementById("role").value = arr.role;
            document.getElementById("email").value = arr.email;
            document.getElementById("address").value = arr.address;
            document.getElementById("phone_number").value = arr.phoneNumber;
        },
        error: function (error) {
            alert("Failed to load data!");
        }
    });
});