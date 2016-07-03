<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDetailedCustomer.aspx.cs" Inherits="MedicalStoreModule.ViewDetailedCustomer" %>

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
    <title>View Customer</title>

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
            <h2 class="heading_b uk-margin-bottom">Customer Information</h2>
            <div class="md-card uk-margin-large-bottom">
                <div class="md-card-content">
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-1 parsley-row">
                            <span>Customer Name</span>
                            <input id="customer_name" class="md-input" disabled="disabled" type="text" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-1 parsley-row">
                            <span>Company Name</span>
                            <input id="company_name" class="md-input" disabled="disabled" type="text" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-2-4 parsley-row">
                            <span>Email</span>
                            <input id="email" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Mobile Number</span>
                            <input id="mobile" title="Mobile Number" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Phone</span>
                            <input id="phone_number" class="md-input" disabled="disabled" type="text" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-1 parsley-row">
                            <span>Address</span>
                            <input id="address" class="md-input" disabled="disabled" type="text" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>District</span>
                            <input id="district" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>State</span>
                            <input id="state" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Country</span>
                            <input id="country" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Pincode</span>
                            <input id="pincode" class="md-input" disabled="disabled" type="text" />
                        </div>
                    </div>
                    <div class="uk-grid">
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Date of birth</span>
                            <input id="date_of_birth" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Height</span>
                            <input id="height" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Weight</span>
                            <input id="weight" class="md-input" disabled="disabled" type="text" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Blood Group</span>
                            <input id="blood_group" class="md-input" disabled="disabled" type="text" />
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
    <script src="assets/js/lib/customer/get_customer.js"></script>

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
ml>