<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="MedicalStoreModule.Invoice" %>

<!DOCTYPE html>

<!--[if lte IE 9]> <html class="lte-ie9" lang="en"> <![endif]-->
<!--[if gt IE 9]><!-->
<html lang="en">
<!--<![endif]-->
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Remove Tap Highlight on Windows Phone IE -->
    <meta name="msapplication-tap-highlight" content="no" />

    <link rel="icon" type="image/png" href="assets/img/favicon-16x16.png" sizes="16x16">
    <link rel="icon" type="image/png" href="assets/img/favicon-32x32.png" sizes="32x32">

    <title>Altair Admin v2.2.0</title>


    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css" media="all">

    <!-- flag icons -->
    <link rel="stylesheet" href="assets/icons/flags/flags.min.css" media="all">

    <!-- altair admin -->
    <link rel="stylesheet" href="assets/css/main.min.css" media="all">

    <!-- matchMedia polyfill for testing media queries in JS -->
    <!--[if lte IE 9]>
        <script type="text/javascript" src="bower_components/matchMedia/matchMedia.js"></script>
        <script type="text/javascript" src="bower_components/matchMedia/matchMedia.addListener.js"></script>
    <![endif]-->

</head>
<body class=" sidebar_main_open sidebar_main_swipe header_double_height">

    <uc1:HeaderAndSideBar runat="server" ID="HeaderAndSideBar" />
    <div id="page_content">
        <div id="page_content_inner">

            <div class="uk-width-medium-8-10 uk-container-center reset-print">
                <div class="uk-grid uk-grid-collapse" data-uk-grid-margin>
                    <div class="uk-width-large-7-10">
                        <div class="md-card md-card-single main-print" id="invoice">
                            <div id="invoice_preview"></div>
                            <div id="invoice_form"></div>
                        </div>
                    </div>
                    <div class="uk-width-large-3-10 hidden-print uk-visible-large">
                        <div class="md-list-outside-wrapper">
                            <ul class="md-list md-list-outside invoices_list" id="invoices_list">
                                <li class="heading_list">November 2015</li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 9/2015 <span class="uk-text-small uk-text-muted">(12 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Moore, Schimmel and Bernier</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 9/2015 <span class="uk-text-small uk-text-muted">(11 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Hettinger-O'Connell</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="uk-badge uk-badge-danger">Overdue</span>
                                        <span class="md-list-heading uk-text-truncate">Invoice 166/2015 <span class="uk-text-small uk-text-muted">(10 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Medhurst PLC</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 68/2015 <span class="uk-text-small uk-text-muted">(9 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Friesen, Deckow and Hilpert</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 176/2015 <span class="uk-text-small uk-text-muted">(8 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Fadel-West</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 54/2015 <span class="uk-text-small uk-text-muted">(7 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Hettinger, Gusikowski and Kris</span>
                                    </a>
                                </li>

                                <li class="heading_list">Oldest</li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 100/2015 <span class="uk-text-small uk-text-muted">(31 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Hodkiewicz, Oberbrunner and Hayes</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 199/2015 <span class="uk-text-small uk-text-muted">(15 Sep)</span></span>
                                        <span class="uk-text-small uk-text-muted">Kemmer Inc</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 101/2015 <span class="uk-text-small uk-text-muted">(1 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Grady LLC</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="uk-badge uk-badge-danger">Overdue</span>
                                        <span class="md-list-heading uk-text-truncate">Invoice 73/2015 <span class="uk-text-small uk-text-muted">(27 Jul)</span></span>
                                        <span class="uk-text-small uk-text-muted">Steuber, Schaden and Considine</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 154/2015 <span class="uk-text-small uk-text-muted">(24 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Moen and Sons</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 73/2015 <span class="uk-text-small uk-text-muted">(2 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Bins, Padberg and Grant</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="uk-badge uk-badge-danger">Overdue</span>
                                        <span class="md-list-heading uk-text-truncate">Invoice 73/2015 <span class="uk-text-small uk-text-muted">(19 Jun)</span></span>
                                        <span class="uk-text-small uk-text-muted">Wintheiser and Sons</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 82/2015 <span class="uk-text-small uk-text-muted">(19 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Denesik PLC</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 149/2015 <span class="uk-text-small uk-text-muted">(24 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Kerluke, Huels and Glover</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 74/2015 <span class="uk-text-small uk-text-muted">(16 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Lemke-Schultz</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 159/2015 <span class="uk-text-small uk-text-muted">(3 Sep)</span></span>
                                        <span class="uk-text-small uk-text-muted">Murazik-Dietrich</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 145/2015 <span class="uk-text-small uk-text-muted">(29 Jun)</span></span>
                                        <span class="uk-text-small uk-text-muted">Bauch-Farrell</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 19/2015 <span class="uk-text-small uk-text-muted">(11 Jul)</span></span>
                                        <span class="uk-text-small uk-text-muted">Treutel, Botsford and Harber</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="1">
                                        <span class="md-list-heading uk-text-truncate">Invoice 131/2015 <span class="uk-text-small uk-text-muted">(26 Aug)</span></span>
                                        <span class="uk-text-small uk-text-muted">Torp PLC</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="md-fab-wrapper">
        <a class="md-fab md-fab-accent" href="#" id="invoice_add">
            <i class="material-icons">&#xE145;</i>
        </a>
    </div>

    <div id="sidebar_secondary">
        <div class="sidebar_secondary_wrapper uk-margin-remove"></div>
    </div>

    <script id="invoice_template" type="text/x-handlebars-template">
        <div class="md-card-toolbar">
            <div class="md-card-toolbar-actions hidden-print">
                <i class="md-icon material-icons" id="invoice_print">&#xE8ad;</i>
                <div class="md-card-dropdown" data-uk-dropdown="{pos:'bottom-right'}">
                    <i class="md-icon material-icons">&#xE5D4;</i>
                    <div class="uk-dropdown uk-dropdown-small">
                        <ul class="uk-nav">
                            <li><a href="#">Archive</a></li>
                            <li><a href="#" class="uk-text-danger">Remove</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <h3 class="md-card-toolbar-heading-text large" id="invoice_name">Invoice {{invoice_id.invoice_number}}
            </h3>
        </div>
        <div class="md-card-content">
            <div class="uk-margin-medium-bottom">
                <span class="uk-text-muted uk-text-small uk-text-italic">Date:</span> {{invoice_id.invoice_date}}
               
                <br />
                <span class="uk-text-muted uk-text-small uk-text-italic">Due Date:</span> {{invoice_id.invoice_due_date}}
           
            </div>
            <div class="uk-grid" data-uk-grid-margin>
                <div class="uk-width-small-3-5">
                    <div class="uk-margin-bottom">
                        <span class="uk-text-muted uk-text-small uk-text-italic">Customer:</span>
                        <address>
                            <p><strong>{{invoice_id.invoice_customer_name}}</strong></p>
                            <p>{{invoice_id.invoice_customer_address}}</p>
                            <p>{{invoice_id.invoice_customer_district}}</p>
                            <p>{{invoice_id.invoice_customer_state}}</p>
                            <p>{{invoice_id.invoice_customer_country}}</p>
                            <p>{{invoice_id.invoice_customer_pincode}}</p>
                        </address>
                    </div>
                </div>
                <div class="uk-width-small-2-5">
                    <span class="uk-text-muted uk-text-small uk-text-italic">Total:</span>
                    <p class="heading_b uk-text-success">{{invoice_id.invoice_total_value}}</p>
                    <p class="uk-text-small uk-text-muted uk-margin-top-remove">Incl. VAT - {{invoice_id.invoice_vat_value}}</p>
                </div>
            </div>
            <div class="uk-grid uk-margin-large-bottom">
                <div class="uk-width-1-1">
                    <table class="uk-table">
                        <thead>
                            <tr class="uk-text-upper">
                                <th>Medicine</th>
                                <th>Rate</th>
                                <th class="uk-text-center">Quantity</th>
                                <th class="uk-text-center">Vat</th>
                                <th class="uk-text-center">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            {{#each invoice_id.invoice_medicines}}
                           
                            <tr class="uk-table-middle">
                                <td>
                                    <span class="uk-text-large">{{ medicine_name }}</span><br />
                                    <span class="uk-text-muted uk-text-small">{{ medicine_description }}</span>
                                </td>
                                <td>{{ medicine_rate }}
                                </td>
                                <td class="uk-text-center">{{ medicine_quantity }}
                                </td>
                                <td class="uk-text-center">{{ medicine_vat }}
                                </td>
                                <td class="uk-text-center">{{ medicine_total }}
                                </td>
                            </tr>
                            {{/each}}
                       
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </script>

    <script id="invoice_form_template" type="text/x-handlebars-template">
        <form action="" class="uk-form-stacked">
            <div class="md-card-toolbar">
                <div class="md-card-toolbar-actions">
                    <i class="md-icon material-icons">&#xE161;</i>
                </div>
                <input name="invoice_number" id="invoice_number" class="md-card-toolbar-input" type="text" value="" placeholder="Invoice number" />
            </div>
            <div class="md-card-content large-padding">
                <div class="uk-grid" data-uk-grid-margin>
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label" for="hobbies">Issue date:</label>
                        <div class="uk-input-group">
                            <span class="uk-input-group-addon"><i class="uk-input-group-icon uk-icon-calendar"></i></span>
                            <label for="invoice_dp">Select date</label>
                            <input class="md-input" type="text" id="invoice_dp" value="" data-uk-datepicker="{format:'DD.MM.YYYY'}">
                        </div>
                    </div>
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label uk-margin-bottom" for="hobbies">Due date (days):</label>
                        <span class="icheck-inline">
                            <input type="radio" name="invoice_due_date" id="invoice_due_date_7" data-md-icheck />
                            <label for="invoice_due_date_7" class="inline-label">7</label>
                        </span>
                        <span class="icheck-inline">
                            <input type="radio" name="invoice_due_date" id="invoice_due_date_14" data-md-icheck />
                            <label for="invoice_due_date_14" class="inline-label">14</label>
                        </span>
                        <span class="icheck-inline">
                            <input type="radio" name="invoice_due_date" id="invoice_due_date_21" data-md-icheck />
                            <label for="invoice_due_date_21" class="inline-label">21</label>
                        </span>
                    </div>
                </div>
                <div class="uk-grid uk-grid-divider grid-block" data-uk-grid-margin>
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label uk-margin-bottom" for="hobbies">From:</label>
                        <div class="uk-form-row">
                            <label for="invoice_from_company">Company Name</label>
                            <input type="text" class="md-input" id="invoice_from_company" name="invoice_from_company" />
                        </div>
                        <div class="uk-form-row">
                            <label for="invoice_from_address_1">Address 1</label>
                            <input type="text" class="md-input" id="invoice_from_address_1" name="invoice_from_address_1" />
                        </div>
                        <div class="uk-form-row">
                            <label for="invoice_from_address_2">Address 2</label>
                            <input type="text" class="md-input" id="invoice_from_address_2" name="invoice_from_address_2" />
                        </div>
                    </div>
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label uk-margin-bottom" for="hobbies">To:</label>
                        <div class="uk-form-row">
                            <label for="invoice_to_company">Company Name</label>
                            <input type="text" class="md-input" id="invoice_to_company" name="invoice_to_company" />
                        </div>
                        <div class="uk-form-row">
                            <label for="invoice_to_address_1">Address 1</label>
                            <input type="text" class="md-input" id="invoice_to_address_1" name="invoice_to_address_1" />
                        </div>
                        <div class="uk-form-row">
                            <label for="invoice_to_address_2">Address 2</label>
                            <input type="text" class="md-input" id="invoice_to_address_2" name="invoice_to_address_2" />
                        </div>
                    </div>
                </div>
                <div class="uk-grid" data-uk-grid-margin>
                    <div class="uk-width-1-1">
                        <div id="form_invoice_medicines"></div>
                        <div class="uk-text-center uk-margin-medium-top uk-margin-bottom">
                            <a href="#" class="md-btn md-btn-flat md-btn-flat-primary" id="invoice_form_append_medicine_btn">Add new</a>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </script>
    <script id="invoice_form_template_medicines" type="text/x-handlebars-template">
        {{#ifCond invoice_medicine_id '!==' 1}}
       
        <hr class="md-hr" />
        {{/ifCond}}
       
        <div class="uk-grid" data-uk-grid-margin data-medicine-number="{{invoice_medicine_id}}">
            <div class="uk-width-medium-1-10 uk-text-center">
                <p class="uk-text-large">{{invoice_medicine_id}}.</p>
            </div>
            <div class="uk-width-medium-9-10">
                <div class="uk-grid uk-grid-small" data-uk-grid-margin>
                    <div class="uk-width-medium-5-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}">Medicine Name</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}" name="inv_medicine_id_{{invoice_medicine_id}}" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_rate">Rate</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_rate" name="inv_medicine_{{invoice_medicine_id}}_rate" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_hours">Hours</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_hours" name="inv_medicine_{{invoice_medicine_id}}_hours" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_vat">VAT</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_vat" name="inv_medicine_{{invoice_medicine_id}}_vat" />
                    </div>
                    <div class="uk-width-medium-2-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_vat">Total</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_vat" name="inv_medicine_{{invoice_medicine_id}}_vat" readonly />
                    </div>
                </div>
                <div class="uk-grid" data-uk-grid-margin>
                    <div class="uk-width-medium-1-1">
                        <label for="inv_medicine_{{invoice_medicine_id}}_desc">Description</label>
                        <textarea class="md-input" id="inv_medicine_{{invoice_medicine_id}}_desc" name="invoice_medicine_id_{{invoice_medicine_id}}_desc" cols="30" rows="2"></textarea>
                    </div>
                </div>
            </div>
        </div>
    </script>

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
    <!-- handlebars.js -->
    <script src="bower_components/handlebars/handlebars.min.js"></script>
    <script src="assets/js/custom/handlebars_helpers.min.js"></script>

    <!--  invoices functions -->
    <script src="assets/js/pages/page_invoices.min.js"></script>

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
