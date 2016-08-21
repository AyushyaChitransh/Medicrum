<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MedicalStoreModule.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Remove Tap Highlight on Windows Phone IE -->
    <meta name="msapplication-tap-highlight" content="no"/>

    <link rel="icon" type="image/png" href="assets/img/favicon-16x16.png" sizes="16x16" />
    <link rel="icon" type="image/png" href="assets/img/favicon-32x32.png" sizes="32x32" />

    <title>Login Page</title>

    <link href='http://fonts.googleapis.com/css?family=Roboto:300,400,500' rel='stylesheet' type='text/css' />

    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css"/>

    <!-- altair admin login page -->
    <link rel="stylesheet" href="assets/css/login_page.min.css" />
</head>
<body class="login_page">

    <div class="login_page_wrapper">
        <div class="md-card" id="login_card">
            <div class="md-card-content large-padding" id="login_form">
                <div class="login_heading">
                    <div class="uk-align-center"><img src="assets/img/MedicrumLogo2-1.png"></div>
                </div>
                <form>
                    <div class="uk-form-row">
                        <label for="login_username">Username/Email</label>
                        <input class="md-input" type="text" id="login_username" name="login_username" required="required" value="ravi.jain" />
                    </div>
                    <div class="uk-form-row">
                        <label for="login_password">Password</label>
                        <input class="md-input" type="password" id="login_password" name="login_password" required="required" value="abcd" />
                    </div>
                    <div class="uk-margin-medium-top" id="submit_login_details" onclick="LoginButtonClicked()">
                        <a class="md-btn md-btn-primary md-btn-block md-btn-large">Sign In</a>
                    </div>
                    <div class="uk-margin-top">
                        <a href="#" id="login_help_show" class="uk-float-right">Need help?</a>
                        <span class="icheck-inline">
                            <input type="checkbox" name="login_remember_me" id="login_remember_me" data-md-icheck />
                            <label for="login_remember_me" class="inline-label">Remember Me</label>
                        </span>
                    </div>
                    <div class="uk-margin-top">
                        <a href="#" id="password_reset_show" class="uk-float-right">Forgot Password</a>
                        <br />
                        <!--<span class="icheck-inline">
                            <input type="checkbox" name="login_page_stay_signed" id="login_page_stay_signed" data-md-icheck />
                            <label for="login_page_stay_signed" class="inline-label">Stay signed in</label>
                        </span>-->
                    </div>
                </form>
            </div>
            
            <div class="md-card-content large-padding" id="login_password_reset" style="display: none">
                <button type="button" class="uk-position-top-right uk-close uk-margin-right uk-margin-top back_to_login"></button>
                <h2 class="heading_a uk-margin-large-bottom">Reset password</h2>
                <form>
                    <div class="uk-form-row">
                        <label for="login_reset_email">Your registered email address</label>
                        <input class="md-input" type="email" id="login_reset_email" name="login_email_reset"" />
                    </div>
                    <div class="uk-margin-medium-top">
                        <a  onclick="ResetPassword()" class="md-btn md-btn-primary md-btn-block md-btn-large">Reset Password</a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!-- common functions -->
    <script src="assets/js/common.min.js"></script>
    <!-- uikit functions -->
    <script src="assets/js/uikit_custom.min.js"></script>
    <!-- altair core functions -->
    <script src="assets/js/altair_admin_common.min.js"></script>

    <!-- altair login page functions -->
    <script src="assets/js/lib/notification.js"></script>
    <script src="assets/js/lib/login/login.js"></script>

</body>
</html>