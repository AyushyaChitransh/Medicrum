﻿$(function () {
    // login_page
    altair_login_page.init();
});

// variables
var $login_card = $('#login_card'),
    $login_form = $('#login_form'),
    $submit_login_details = $('submit_login_details'),
    $login_password_reset = $('#login_password_reset');

altair_login_page = {
    init: function () {
        // show login form (hide other forms)
        var login_form_show = function () {
            $login_form
                .show()
                .siblings()
                .hide();
        };

        // show password reset form (hide other forms)
        var password_reset_show = function () {
            $login_password_reset
                .show()
                .siblings()
                .hide();
        };

        $('.back_to_login').on('click', function (e) {
            e.preventDefault();
            //$('#signup_form_show').fadeIn('100');
            // card animation & complete callback: login_form_show
            altair_md.card_show_hide($login_card, undefined, login_form_show, undefined);
        });

        $('#password_reset_show').on('click', function (e) {
            e.preventDefault();
            // card animation & complete callback: password_reset_show
            altair_md.card_show_hide($login_card, undefined, password_reset_show, undefined);
        });
    }
};

function LoginButtonClicked() {
    var email = document.getElementById('login_username').value;
    var password = document.getElementById('login_password').value;
    var rememberMe = document.getElementById("login_remember_me").checked;
    $.ajax({
        type: 'POST',
        url: 'Login.aspx/LoginButtonClicked',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'email': '" + email + "','password': '" + password + "','rememberMe':'" + rememberMe + "' }",
        success: function (response) {
            if (response.d == true) {
                window.location = "Dashboard.aspx";
            }
            else {
                Notification('i');
            }
        },
        error: function (error) {
            Notification('u');
        }
    });
}

function ResetPassword() {
    var email = document.getElementById('login_reset_email').value;
    $.ajax({
        type: 'POST',
        url: 'Login.aspx/SendResetCode',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Sending Email...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        data: "{ 'email': '" + email + "' }",
        success: function (response) {
            if (response.d == true) {
                window.location = "Login.aspx";
            }
            else {
                Notification('i');
            }
        },
        error: function (error) {
            Notification('u');
        }
    });
}
