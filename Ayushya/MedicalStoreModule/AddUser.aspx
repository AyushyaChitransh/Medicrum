<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="MedicalStoreModule.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Remove Tap Highlight on Windows Phone IE -->
    <meta name="msapplication-tap-highlight" content="no" />
    <link rel="icon" type="image/png" href="assets/img/favicon-16x16.png" sizes="16x16" />
    <link rel="icon" type="image/png" href="assets/img/favicon-32x32.png" sizes="32x32" />
    <title>Add User</title>

    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css" media="all" />
    <!-- flag icons -->
    <link rel="stylesheet" href="assets/icons/flags/flags.min.css" media="all" />
    <!-- altair admin -->
    <link rel="stylesheet" href="assets/css/main.min.css" media="all" />
</head>
<body class=" sidebar_main_open sidebar_main_swipe">

    <uc1:HeaderAndSideBar runat="server" ID="HeaderAndSideBar" />

    <div id="page_content">
        <div id="page_content_inner">
            <h2 class="heading_b uk-margin-bottom">Add User</h2>
            <div class="md-card uk-margin-large-bottom">
                <div class="md-card-content">
                    <form class="uk-form-stacked" id="wizard_advanced_form">
                        <div id="wizard_advanced" data-uk-observe="data-uk-observe">
                            <section>
                                <h2 class="heading_a">User Information
                                    <span class="sub-heading">Enter details below</span>
                                </h2>
                                <hr class="md-hr" />
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_name">Name<span class="req">*</span></label>
                                        <input type="text" name="name" id="wizard_name" required="required" class="md-input" />
                                    </div>
                                </div>
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_user_name">User Name<span class="req">*</span></label>
                                        <input type="text" name="userName" id="wizard_user_name" data-parsley-trigger="change" required="required" class="md-input" onkeyup="CheckUserName(true)" />
                                        <span class="md-color-red-600" id="userNameCheck" style="display:none;">User Name already taken.</span>
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_password">Password<span class="req">*</span></label>
                                        <input type="password" name="password" id="wizard_password" required="required" class="md-input" />
                                    </div>
                                </div>
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_email">Email</label>
                                        <input type="email" name="email" id="wizard_email" data-parsley-trigger="change" class="md-input" onkeyup="CheckEmail(true)"/>
                                        <span class="md-color-red-600" id="emailCheck" style="display:none;">Email ID already registered.</span>
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_role">Role<span class="req">*</span></label>
                                        <select id="wizard_role" name="role" required="required" class="md-input label-fixed">
                                            <option value="">Select Role</option>
                                            <option value="1">Admin</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_address">Address</label>
                                        <input type="text" name="address" id="wizard_address" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_phone_number">Phone</label>
                                        <input type="text" name="phoneNumber" id="wizard_phone" pattern="[0-9]{7,20}" title="Phone Number" data-parsley-trigger="change" class="md-input" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1">
                                        <button id="button" class="md-btn md-btn-primary md-btn-block" onclick="addDetails()">Finish</button>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- google web fonts -->
    <script>
        WebFontConfig = {
            google: {
                families: [
                    'Source+Code+Pro:400,700:latin',
                    'Roboto:400,300,500,700,400italic:latin'
                ]
            }
        };
        (function () {
            var wf = document.createElement('script');
            wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
            '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })();
    </script>
    <!-- common functions -->
    <script src="assets/js/common.min.js"></script>
    <!-- uikit functions -->
    <script src="assets/js/uikit_custom.min.js"></script>
    <!-- altair common functions/helpers -->
    <script src="assets/js/altair_admin_common.min.js"></script>

    <uc1:StyleSwitcher runat="server" ID="StyleSwitcher" />

    <!-- page specific plugins -->
    <!-- parsley (validation) -->
    <script>
        // load parsley config (altair_admin_common.js)
        altair_forms.parsley_validation_config();
        // load extra validators
        altair_forms.parsley_extra_validators();
    </script>
    <script src="bower_components/parsleyjs/dist/parsley.min.js"></script>

    <!-- Page function scripts -->
    <script src="assets/js/lib/notification.js"></script>
    <script src="assets/js/lib/User/validate_data.js"></script>
    <script src="assets/js/lib/user/add_user.js"></script>

    <script>
        $(function () {
            // enable hires images
            altair_helpers.retina_images();
            // fastClick (touch devices)
            if (Modernizr.touch) {
                FastClick.attach(document.body);
            }
        });
    </script>
</body>
</html>
