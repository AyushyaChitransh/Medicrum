$(function () {
    // login_page
    altair_login_page.init();
});

// variables
var $login_card = $('#login_card'),
    $login_form = $('#login_form'),
    $login_help = $('#login_help'),
    $submit_login_details = $('submit_login_details');

altair_login_page = {
    init: function () {
        // show login form (hide other forms)
        var login_form_show = function () {
            $login_form
                .show()
                .siblings()
                .hide();
        };

        // show login help (hide other forms)
        var login_help_show = function () {
            $login_help
                .show()
                .siblings()
                .hide();
        };

        $('#login_help_show').on('click', function (e) {
            e.preventDefault();
            // card animation & complete callback: login_help_show
            altair_md.card_show_hide($login_card, undefined, login_help_show, undefined);
        });

        $('.back_to_login').on('click', function (e) {
            e.preventDefault();
            $('#signup_form_show').fadeIn('280');
            // card animation & complete callback: login_form_show
            altair_md.card_show_hide($login_card, undefined, login_form_show, undefined);
        });
    }
};
function VerifyCredentials() {
    var email = document.getElementById('login_username').value;
    var password = document.getElementById('login_password').value;
    $.ajax({
        type: 'POST',
        url: 'Login.aspx/VerifyCredentials',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'email': '" + email + "','password': '" + password + "' }",
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