<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDetailedProductModel.aspx.cs" Inherits="MedicalStoreModule.ViewDetailedProductModel" %>

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
    <title>View Product Model</title>

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
            <h3 class="heading_b uk-margin-bottom">Product Details</h3>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Product Name</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <input type="text" id="product_name" class="md-input" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Basic Details</h3>
                    <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Trade Name</span>
                            <input type="text" id="trade_name" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-2 parsley-row">
                            <span>Company Name</span>
                            <input type="text" id="company" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                    <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Category</span>
                            <input type="text" id="category" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Sub Category</span>
                            <input type="text" id="sub_category" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Type</span>
                            <input type="text" id="type" class="md-input" disabled="disabled" />
                        </div>
                        <div class="uk-width-medium-1-4 parsley-row">
                            <span>Schedule</span>
                            <input type="text" id="schedule" class="md-input" disabled="disabled" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Composition</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="composition" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Description</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="description" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Purpose</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="purpose" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Dosage Instruction</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="dosage_instruction" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Storage Instruction</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="storage_instruction" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Indications</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="indications" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Warning</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="warning" class="md-input" disabled="disabled"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="md-card">
                <div class="md-card-content">
                    <h3 class="heading_a">Other Information</h3>
                    <div class="uk-grid">
                        <div class="uk-width-1-1">
                            <div class="uk-form-row">
                                <textarea id="other_information" class="md-input" disabled="disabled"></textarea>
                            </div>
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
    <script src="assets/js/lib/get_product_model.js"></script>

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
