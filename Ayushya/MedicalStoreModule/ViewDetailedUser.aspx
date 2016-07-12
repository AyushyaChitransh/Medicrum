<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDetailedUser.aspx.cs" Inherits="MedicalStoreModule.ViewDetailedUser" %>

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
    <title>View User</title>

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
            <h2 class="heading_b uk-margin-bottom">View User</h2>
            <div class="md-card uk-margin-large-bottom">
                <div class="md-card-content">
                    <h2 class="heading_a">User Information
                                    <span class="sub-heading">Enter details below</span>
                    </h2>
                    <hr class="md-hr" />
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-1 parsley-row">
                            <span>Name</span>
                            <input type="text" name="name" id="name" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>User Name</span>
                            <input type="text" name="userName" id="user_name" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Email</span>
                            <input type="text" id="email" class="md-input" disabled="disabled" onkeyup="CheckEmail()" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-1 parsley-row">
                            <span>Address</span>
                            <input type="text" id="address" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Role</span>
                            <input type="text" id="role" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Phone</span>
                            <input type="text" id="phone_number" class="md-input" disabled="disabled" />
                        </div>
                    </div>
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

    <!-- Page function scripts -->
    <script src="assets/js/lib/user/get_user.js"></script>

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
