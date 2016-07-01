<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="MedicalStoreModule.ViewCustomer" %>

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
            <div class="md-card">
                <div class="md-card-content">
                    <div class="uk-grid" data-uk-grid-margin="">
                        <div class="uk-width-medium-4-6">
                            <h3 class="heading_b uk-margin-bottom">Product List</h3>
                        </div>
                        <br />
                        <div class="uk-width-medium-2-6">
                            <label for="search_product">Search Product</label>
                            <input type="text" class="md-input" id="search_product" name="search_product" onkeyup="response()" />
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            <br />
            <div class="md-card">
                <div class="md-card-content">
                    <div id="product_list"></div>
                </div>
            </div>

        </div>
    </div>

    <div class="md-fab-wrapper">
        <a class="md-fab md-fab-accent" href="AddProduct.aspx">
            <i class="material-icons">&#xE145;</i>
        </a>
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
    <!-- JQuery-UI -->
    <link rel="stylesheet" href="assets/skins/jquery-ui/material/jquery-ui.min.css" />
    <script src="bower_components/jquery-ui/jquery-ui.min.js"></script>

    <!-- jTable -->
    <!-- jTable style file -->
    <link rel="stylesheet" href="assets/skins/jtable/jtable.min.css" />
    <!-- Core jTable script file -->
    <script src="bower_components/jtable/lib/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script src="bower_components/jtable/lib/extensions/jquery.jtable.aspnetpagemethods.js"></script>

    <!-- Page function scripts -->
    <script src="assets/js/lib/view_product_model.js"></script>
    <script src="assets/js/lib/product_model_table.js"></script>

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
