﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="MedicalStoreModule.ResetPassword" %>

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

    <title>Reset Password</title>

    <link href='http://fonts.googleapis.com/css?family=Roboto:300,400,500' rel='stylesheet' type='text/css' />

    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css"/>

    <!-- altair admin login page -->
    <link rel="stylesheet" href="assets/css/login_page.min.css" />
</head>
<body class="Password_reset_page">

    <div class="login_page_wrapper">
        <div class="md-card" id="login_card">
            <div class="md-card-content large-padding" id="login_form">
                <div class="login_heading">
                    <div class="user_avatar"></div>
                </div>
                <form>
                    <div class="uk-form-row">
                        <label for="login_password">New Password</label>
                        <input class="md-input" type="password" id="login_password" name="login_password" required="required" />
                    </div>
                    <div class="uk-form-row">
                        <label for="login_password_confirm">Confirm Password</label>
                        <input class="md-input" type="password" id="login_password_confirm" name="login_password_confirm" required="required" />
                    </div>
                    <div class="uk-margin-medium-top" id="submit_login_details" onclick="UpdatePassword()">
                        <a class="md-btn md-btn-primary md-btn-block md-btn-large">Update Password</a>
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
    <script src="assets/js/lib/login/ResetPassword.js"></script>

</body>
</html>