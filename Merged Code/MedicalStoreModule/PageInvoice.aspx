﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageInvoice.aspx.cs" Inherits="MedicalStoreModule.PageInvoice" %>

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
    <title>Invoice</title>

    <!-- uikit -->
    <link rel="stylesheet" href="bower_components/uikit/css/uikit.almost-flat.min.css" media="all" />
    <!-- flag icons -->
    <link rel="stylesheet" href="assets/icons/flags/flags.min.css" media="all" />
    <!-- altair admin -->
    <link rel="stylesheet" href="assets/css/main.min.css" media="all" />
</head>
<body class=" sidebar_main_open sidebar_main_swipe header_double_height">

    <uc1:HeaderAndSideBar runat="server" ID="HeaderAndSideBar" />

    <div id="page_content">
        <div id="page_content_inner">

            <div class="uk-width-medium-8-10 uk-container-center reset-print">
                <div class="uk-grid uk-grid-collapse" data-uk-grid-margin="data-uk-grid-margin">
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
                                    <a href="#" class="md-list-content" data-invoice-id="2">
                                        <span class="md-list-heading uk-text-truncate">Invoice 9/2015 <span class="uk-text-small uk-text-muted">(11 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Hettinger-O'Connell</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" class="md-list-content" data-invoice-id="3">
                                        <span class="uk-badge uk-badge-danger">Overdue</span>
                                        <span class="md-list-heading uk-text-truncate">Invoice 166/2015 <span class="uk-text-small uk-text-muted">(10 Nov)</span></span>
                                        <span class="uk-text-small uk-text-muted">Medhurst PLC</span>
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
                <i class="md-icon material-icons" onclick="DeleteInvoice()">delete</i>
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
                        <p><strong>{{invoice_id.invoice_customer}}</strong></p>
                        <span class="uk-text-muted uk-text-small uk-text-italic">Location:</span>
                        <address>
                            <p>{{invoice_id.invoice_address}}</p>
                            <p>{{invoice_id.invoice_district}}</p>
                            <p>{{invoice_id.invoice_state}}</p>
                            <p>{{invoice_id.invoice_country}}</p>
                            <p>{{invoice_id.invoice_pincode}}</p>
                        </address>
                        <span class="uk-text-muted uk-text-small uk-text-italic">Contact:</span>
                        <address>
                            <p>{{invoice_id.invoice_email}}</p>
                            <p>{{invoice_id.invoice_mobile}}</p>
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
                                <th>Description</th>
                                <th>Rate</th>
                                <th class="uk-text-center">Qty</th>
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
                                <td class="uk-text-center">{{ medicine_qty }}
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
            <div class="uk-grid">
                <div class="uk-width-1-1">
                    <span class="uk-text-muted uk-text-small uk-text-italic">Payment info:</span>
                    <p class="uk-margin-top-remove">
                        {{{ invoice_id.invoice_payment_terms }}}
                   
                    </p>
                    <p class="uk-text-small">Please pay within {{ invoice_id.invoice_payment_mode }} days</p>
                </div>
            </div>
        </div>
    </script>

    <script id="invoice_form_template" type="text/x-handlebars-template">
        <form action="" class="uk-form-stacked" id="form_invoice">
            <div class="md-card-toolbar">
                <div class="md-card-toolbar-actions">
                    <i class="md-icon material-icons" id="invoice_submit" onclick="AddInvoice()">save</i>
                </div>
                <input name="invoiceNumber" id="invoice_number" class="md-card-toolbar-input" type="text" value="" placeholder="Invoice number" />
            </div>
            <div class="md-card-content large-padding">
                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
                    <div class="uk-width-1-1">
                        <label for="form_customer">Customer:</label>
                        <input type="text" class="md-input" id="invoice_form_customer" name="customerId" />
                    </div>
                    <hr style="width:100%" />
                </div>
                <div class="uk-grid uk-grid-divider" data-uk-grid-margin="data-uk-grid-margin">
                    <div class="uk-width-medium-1-3">
                        <label class="uk-form-label uk-margin-bottom" for="invoice_type">Invoice Type</label>
                        <select class="md-input label-fixed" id="invoice_type" name="invoiceType">
                            <option selected="selected" value="">Invoice Type</option>
                            <option value="Sale Invoice">Sale Invoice</option>
                            <option value="Retail Invoice">Retail Invoice</option>
                        </select>
                    </div>
                    <div class="uk-width-medium-1-3">
                        <label class="uk-form-label uk-margin-bottom" for="payment_terms">Payment Terms:</label>
                        <select class="md-input label-fixed" id="payment_terms" name="paymentTerms">
                            <option selected="selected" value="">Payment Terms</option>
                            <option value="1 Day">1 Day</option>
                            <option value="7 Days">7 Days</option>
                            <option value="15 Days">15 Days</option>
                            <option value="30 Days">30 Days</option>
                        </select>
                    </div>
                    <div class="uk-width-medium-1-3">
                        <label class="uk-form-label uk-margin-bottom" for="payment_mode">Payment Mode:</label>
                        <select class="md-input label-fixed" id="payment_mode" name="paymentMode">
                            <option selected="selected" value="">Payment Mode</option>
                            <option value="Cash">Cash</option>
                            <option value="Credit Card">Credit Card</option>
                            <option value="Debit Card">Debit card</option>
                        </select>
                    </div>
                    <hr style="width:100%" />
                </div>
                <div class="uk-grid uk-grid-divider" data-uk-grid-margin="data-uk-grid-margin">
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label uk-margin-bottom" for="discount_type">Discount Type</label>
                        <select class="md-input label-fixed" id="discount_type" name="discountType">
                            <option selected="selected" value="">Discount Type</option>
                            <option value="Flat">Flat</option>
                            <option value="Percent">Percent</option>
                        </select>
                    </div>
                    <div class="uk-width-medium-1-2">
                        <label class="uk-form-label uk-margin-bottom" for="coupon_code">Coupon Code:</label>
                        <input type="text" class="md-input" id="coupon_code" name="couponCode" />
                    </div>
                    <hr style="width:100%" />
                </div>
                <div class="uk-grid" data-uk-grid-margin="data-uk-grid-margin">
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
                <div class="uk-grid uk-grid-small" data-uk-grid-margin="data-uk-grid-margin">
                    <div class="uk-width-medium-5-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}">Medicine Name</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}" name="billingItems[{{invoice_medicine_id}}][productId]" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_rate">Rate</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_rate" name="billingItems[{{invoice_medicine_id}}][unitPrice]" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_qty">Qty</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_qty" name="billingItems[{{invoice_medicine_id}}][quantity]" />
                    </div>
                    <div class="uk-width-medium-1-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_vat">VAT</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_vat" name="billingItems[{{invoice_medicine_id}}][tax]" />
                    </div>
                    <div class="uk-width-medium-2-10">
                        <label for="inv_medicine_{{invoice_medicine_id}}_vat">Total</label>
                        <input type="text" class="md-input" id="inv_medicine_{{invoice_medicine_id}}_total" name="billingItems[{{invoice_medicine_id}}][price]" />
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
    
    <script src="assets/js/lib/invoice/jquery.serialize-object.min.js"></script>
    <!--  invoices functions -->
    <script src="assets/js/lib/invoice/page_invoices.js"></script>

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