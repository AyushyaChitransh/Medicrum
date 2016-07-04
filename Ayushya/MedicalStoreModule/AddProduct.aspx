<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="MedicalStoreModule.AddProduct" %>

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
    <title>Add Product</title>

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
            <h2 class="heading_b uk-margin-bottom">Add Product</h2>
            <div class="md-card uk-margin-large-bottom">
                <div class="md-card-content">
                    <form class="uk-form-stacked" id="wizard_advanced_form">
                        <div id="wizard_advanced" data-uk-observe="data-uk-observe">
                            <section>
                                <h2 class="heading_a">Product Stock Information
                                    <span class="sub-heading">Enter details below</span>
                                </h2>
                                <hr class="md-hr" />
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <span>Product Model<span class="req">*</span></span>
                                        <select id="wizard_product_model_id" name="productModelId" class="md-input" required="required">
                                        </select>
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <span>Supplier<span class="req">*</span></span>
                                        <select id="wizard_supplier_id" name="supplierId" class="md-input" required="required">
                                        </select>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-5 parsley-row">
                                        <label for="wizard_barcode">Barcode</label>
                                        <input type="number" name="barcode" id="wizard_barcode" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-5 parsley-row">
                                        <label for="wizard_batch_number">Batch Number<span class="req">*</span></label>
                                        <input type="text" name="batchNumber" id="wizard_batch_number" required="required" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-5 parsley-row">
                                        <label for="wizard_package_quantity">Package Quantity<span class="req">*</span></label>
                                        <input type="number" name="packageQuantity" id="wizard_package_quantity" required="required" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-5 parsley-row">
                                        <label for="wizard_quantity">Quantity<span class="req">*</span></label>
                                        <input type="number" name="quantity" id="wizard_quantity" required="required" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-5 parsley-row">
                                        <label for="wizard_price">Price<span class="req">*</span></label>
                                        <input type="number" step="any" name="price" id="wizard_price" required="required" class="md-input" />
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_manufacture_date">Manufacture Date<span class="req">*</span></label>
                                        <input type="text" name="manufactureDate" id="wizard_manufacture_date" required="required" class="md-input" data-parsley-date="data-parsley-date" data-parsley-date-message="This value should be a valid date" data-uk-datepicker="{format:'MM.DD.YYYY'}" />
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_expiry_date">Expiry Date<span class="req">*</span></label>
                                        <input type="text" name="expiryDate" id="wizard_expiry_date" required="required" class="md-input" data-parsley-date="data-parsley-date" data-parsley-date-message="This value should be a valid date" data-uk-datepicker="{format:'MM.DD.YYYY'}" />
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_manufacture_licence_number">Manufacture Licence Number</label>
                                        <input type="text" name="manufactureLicenceNumber" id="wizard_manufacture_licence_number" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_weight">Weight</label>
                                        <input type="number" step="any" name="weight" id="wizard_weight" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_volume">Volume</label>
                                        <input type="number" step="any" name="volume" id="wizard_volume" class="md-input" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_tax">Tax</label>
                                        <input type="number" step="any" name="tax" id="wizard_tax" class="md-input" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1">
                                        <button class="md-btn md-btn-primary md-btn-block" onclick="addDetails()">Finish</button>
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

    <uc1:StyleSwitcher runat="server" ID="StyleSwitcher1" />

    <!-- page specific plugins -->
    <!-- parsley (validation) -->
    <script>
        // load parsley config (altair_admin_common.js)
        altair_forms.parsley_validation_config();
        // load extra validators
        altair_forms.parsley_extra_validators();
    </script>
    <script src="bower_components/parsleyjs/dist/parsley.min.js"></script>
    <!-- jquery steps -->
    <script src="assets/js/custom/wizard_steps.min.js"></script>

    <!-- Page function scripts -->
    <script src="assets/js/lib/stock_product/load_add_product_data.js"></script>
    <script src="assets/js/lib/notification.js"></script>
    <script src="assets/js/lib/stock_product/add_product.js"></script>

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

