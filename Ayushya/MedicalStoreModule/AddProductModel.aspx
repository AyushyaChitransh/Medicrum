﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProductModel.aspx.cs" Inherits="MedicalStoreModule.AddProductModel" %>

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
    <title>Add Product Model</title>

    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css" media="all" />
    <!-- flag icons -->
    <link rel="stylesheet" href="assets/icons/flags/flags.min.css" media="all" />
    <!-- altair admin -->
    <link rel="stylesheet" href="assets/css/main.min.css" media="all" />
    <!-- additional styles for plugins -->
    <!-- kendo UI -->
    <link rel="stylesheet" href="bower_components/kendo-ui/styles/kendo.common-material.min.css"/>
    <link rel="stylesheet" href="bower_components/kendo-ui/styles/kendo.material.min.css"/>
</head>
<body class=" sidebar_main_open sidebar_main_swipe">

    <uc1:HeaderAndSideBar runat="server" ID="HeaderAndSideBar" />

    <div id="page_content">
        <div id="page_content_inner">
            <h2 class="heading_b uk-margin-bottom">Add Product Model</h2>
            <div class="md-card uk-margin-large-bottom">
                <div class="md-card-content">
                    <form class="uk-form-stacked" id="wizard_advanced_form">
                        <div id="wizard_advanced" data-uk-observe="data-uk-observe">
                            <section>
                                <h2 class="heading_a">Product Model Information 
                                    <span class="sub-heading">Enter Details below</span>
                                </h2>
                                <hr class="md-hr" />
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_product_name">Product Name<span class="req">*</span></label>
                                        <input type="text" name="productName" id="wizard_product_name" required="required" class="md-input" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Name of product" />
                                    </div>
                                </div>
                                <div class="uk-grid">
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_company">Company<span class="req">*</span></label>
                                        <input type="text" name="company" id="wizard_company" required="required" style="width:100%;" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Manufacturer" />
                                    </div>
                                    <div class="uk-width-medium-1-2 parsley-row">
                                        <label for="wizard_trade_name">Trade Name<span class="req">*</span></label>
                                        <input type="text" name="tradeName" id="wizard_trade_name" required="required" class="md-input" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Trade Name of product" />
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_category">Category<span class="req">*</span></label>
                                        <input type="text" name="category" id="wizard_category" required="required" style="width:100%;" placeholder="Category" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Select Category for the product" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_sub_category">Sub-Category</label>
                                        <input type="text" name="subCategory" id="wizard_sub_category" style="width:100%;" placeholder="Sub-Category" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Select Sub-Category for the product" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_type">Type<span class="req">*</span></label>
                                        <input type="text" name="type" id="wizard_type" required="required" style="width:100%;" placeholder="Type" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Type of product" />
                                    </div>
                                    <div class="uk-width-medium-1-4 parsley-row">
                                        <label for="wizard_schedule">Schedule</label>
                                        <input type="text" name="schedule" id="wizard_schedule" class="input-count md-input" maxlength="10" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Add Schedule of medicine if any" />
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_composition">Composition</label>
                                        <textarea name="composition" id="wizard_composition" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Please write all the composition of the product in detail" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_description">Description</label>
                                        <textarea name="description" id="wizard_description" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Description of the product" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_purpose">Purpose</label>
                                        <textarea name="purpose" id="wizard_purpose" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Please write purpose of product" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_dosage_instruction">Dosage Instruction</label>
                                        <textarea name="dosageInstruction" id="wizard_dosage_instruction" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Dosage Instruction of the product" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_storage_instruction">Storage Instruction</label>
                                        <textarea name="storageInstruction" id="wizard_storage_instruction" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Storage Instruction of the product" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_indications">Indications</label>
                                        <textarea name="indications" id="wizard_indications" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Add Indication if any" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_warning">Warning</label>
                                        <textarea name="warning" id="wizard_warning" data-uk-tooltip="{cls:'long-text',pos:'bottom'}" title="Add Warning if any" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
                                    </div>
                                </div>
                                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                                    <div class="uk-width-medium-1-1 parsley-row">
                                        <label for="wizard_other_information">Other Information</label>
                                        <textarea name="otherInformation" id="wizard_other_information" cols="30" rows="4" class="input-count md-input" maxlength="2000"></textarea>
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

    <!-- page specific plugins -->
    <!-- kendo UI -->
    <script src="assets/js/kendoui_custom.min.js"></script>
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
    <script src="assets/js/lib/product_model/add_product_model.js"></script>
    <script src="assets/js/lib/product_model/combo_box.js"></script>

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

