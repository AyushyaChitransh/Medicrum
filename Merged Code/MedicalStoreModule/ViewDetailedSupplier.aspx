﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDetailedSupplier.aspx.cs" Inherits="MedicalStoreModule.ViewDetailedSupplier" %>

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
    <title>View Supplier</title>

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
            <h2 class="heading_b uk-margin-bottom">Supplier Details</h2>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Supplier Name</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <input type="text" id="contact_person_name" class="md-input" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Location Information</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-2">
                            <div class="uk-form-row">
                                <span>Supplier Store Name</span>
                                <input type="text" id="supplier_store_name" class="md-input" disabled="disabled" />
                            </div>
                        </div>
                        <div class="uk-width-1-2">
                            <div class="uk-form-row">
                                <span>Address</span>
                                <input type="text" id="address" class="md-input" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                    <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                        <div class="uk-width-medium-1-4 uk-form-row">
                            <span>District</span>
                            <input type="text" id="district" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>State</span>
                            <input type="text" id="state" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Country</span>
                            <input type="text" id="country" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Pincode</span>
                            <input type="text" id="pincode" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Contact Description</h3>
                    <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Email</span>
                                <input type="text" id="email" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Phone Number</span>
                                <input type="text" id="phone_number" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                    <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Mobile</span>
                                <input type="text" id="mobile" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Website</span>
                                <input type="text" id="website" class="md-input" disabled="disabled" />
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
    <script src="assets/js/lib/supplier/get_supplier.js"></script>

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
