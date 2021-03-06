﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MedicalStoreModule.Dashboard" %>

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
    <title>Dashboard</title>

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
            <h2 class="heading_b uk-margin-bottom">Dashboard</h2>
            <div class="uk-grid uk-grid-width-small-1-2 uk-grid-width-large-1-3 uk-grid-width-xlarge-1-5 uk-text-center uk-sortable sortable-handler" id="dashboard_sortable_cards" data-uk-sortable="data-uk-sortable" data-uk-grid-margin="data-uk-grid-margin">
                <div>
                    <div class="md-card md-card-hover md-card-overlay">
                        <div class="md-card-content">
                            <div class="epc_chart" data-percent="100" data-bar-color="#03a9f4">
                                <span class="epc_chart_icon"><i class="material-icons">&#xE53E;</i></span>
                            </div>
                        </div>
                        <div class="md-card-overlay-content">
                            <div class="uk-clearfix md-card-overlay-header">
                                <i class="md-icon material-icons md-card-overlay-toggler">&#xE5D4;</i>
                                <h3>Invoice
                                </h3>
                            </div>
                            <p>You can add and view your invoices</p>
                            <div>
                                <a href="PageInvoice.aspx" class="md-btn md-btn-primary">Invoice</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card md-card-hover md-card-overlay">
                        <div class="md-card-content">
                            <div class="epc_chart" data-percent="100" data-bar-color="#03a9f4">
                                <span class="epc_chart_icon"><i class="material-icons">&#xE8CB;</i></span>
                            </div>
                        </div>
                        <div class="md-card-overlay-content">
                            <div class="uk-clearfix md-card-overlay-header">
                                <i class="md-icon material-icons md-card-overlay-toggler">&#xE5D4;</i>
                                <h3>Product
                                </h3>
                            </div>
                            <p>You can add and view your products</p>
                            <div>
                                <a href="AddProduct.aspx" class="md-btn md-btn-primary">Add</a>
                                <a href="ProductList.aspx" class="md-btn md-btn-primary">View</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card md-card-hover md-card-overlay">
                        <div class="md-card-content">
                            <div class="epc_chart" data-percent="100" data-bar-color="#03a9f4">
                                <span class="epc_chart_icon"><i class="material-icons">description</i></span>
                            </div>
                        </div>
                        <div class="md-card-overlay-content">
                            <div class="uk-clearfix md-card-overlay-header">
                                <i class="md-icon material-icons md-card-overlay-toggler">&#xE5D4;</i>
                                <h3>Product Model
                                </h3>
                            </div>
                            <p>You can add and view your product models</p>
                            <div>
                                <a href="AddProductModel.aspx" class="md-btn md-btn-primary">Add</a>
                                <a href="ProductModelList.aspx" class="md-btn md-btn-primary">View</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card md-card-hover md-card-overlay">
                        <div class="md-card-content">
                            <div class="epc_chart" data-percent="100" data-bar-color="#03a9f4">
                                <span class="epc_chart_icon"><i class="material-icons">person</i></span>
                            </div>
                        </div>
                        <div class="md-card-overlay-content">
                            <div class="uk-clearfix md-card-overlay-header">
                                <i class="md-icon material-icons md-card-overlay-toggler">&#xE5D4;</i>
                                <h3>Customer
                                </h3>
                            </div>
                            <p>You can add and view your customers</p>
                            <div>
                                <a href="AddCustomer.aspx" class="md-btn md-btn-primary">Add</a>
                                <a href="CustomerList.aspx" class="md-btn md-btn-primary">View</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card md-card-hover md-card-overlay">
                        <div class="md-card-content">
                            <div class="epc_chart" data-percent="100" data-bar-color="#03a9f4">
                                <span class="epc_chart_icon"><i class="material-icons">people</i></span>
                            </div>
                        </div>
                        <div class="md-card-overlay-content">
                            <div class="uk-clearfix md-card-overlay-header">
                                <i class="md-icon material-icons md-card-overlay-toggler">&#xE5D4;</i>
                                <h3>Supplier
                                </h3>
                            </div>
                            <p>You can add and view your suppliers</p>
                            <div>
                                <a href="AddSupplier.aspx" class="md-btn md-btn-primary">Add</a>
                                <a href="SupplierList.aspx" class="md-btn md-btn-primary">View</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="admin_sales_view" class="uk-grid uk-grid-width-large-1-4 uk-grid-width-medium-1-2 uk-grid-medium uk-sortable sortable-handler hierarchical_show" data-uk-sortable="" data-uk-grid-margin=""></div>
            <div class="uk-grid uk-grid-medium uk-grid-width-medium-1-2 uk-grid-width-large-1-3 uk-sortable sortable-handler" data-uk-sortable="data-uk-sortable" data-uk-grid-margin="" data-uk-grid-match="{target:'.md-card-content'}">
                <div>
                    <div class="md-card">
                        <div class="md-card-content">
                            <div class="uk-overflow-container">
                                <table class="uk-table">
                                    <thead>
                                        <tr>
                                            <th class="uk-text-nowrap"><a href="EmptyStocks.aspx">Out Of Stock Products</a></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%= OutOfStockList() %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card">
                        <div class="md-card-content">
                            <div class="uk-overflow-container">
                                <table class="uk-table">
                                    <thead>
                                        <tr>
                                            <th class="uk-text-nowrap"><a href="PageInvoice.aspx.aspx">Invoices Generated Today</a></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%= InvoiceList() %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="md-card">
                        <div class="md-card-content">
                            <div class="uk-overflow-container">
                                <table class="uk-table">
                                    <thead>
                                        <tr>
                                            <th class="uk-text-nowrap"><a href="EmergencyStocks.aspx">Emergency Stocks</a></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%= EmergencyStockList() %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script id="admin_sales_template" type="text/x-handlebars-template">
        <div>
            <div class="md-card">
                <div class="md-card-content">
                    <span class="uk-text-muted uk-text-small">Current Day Sales</span>
                    <h2 class="uk-margin-remove">&#8377;{{day_sales}}</h2>
                </div>
            </div>
        </div>
        <div>
            <div class="md-card">
                <div class="md-card-content">
                    <span class="uk-text-muted uk-text-small">Week Sales (Last 7 Days)</span>
                    <h2 class="uk-margin-remove">&#8377;{{week_sales}}</h2>
                </div>
            </div>
        </div>
        <div>
            <div class="md-card">
                <div class="md-card-content">
                    <span class="uk-text-muted uk-text-small">Month Sales (Last 30 Days)</span>
                    <h2 class="uk-margin-remove">&#8377;{{month_sales}}</h2>
                </div>
            </div>
        </div>
        <div>
            <div class="md-card">
                <div class="md-card-content">
                    <span class="uk-text-muted uk-text-small">Year Sales (Last 365 Days)</span>
                    <h2 class="uk-margin-remove">&#8377;{{year_sales}}</h2>
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
    <!-- chartist (charts) -->
    <script src="bower_components/chartist/dist/chartist.min.js"></script>
    <!-- peity (small charts) -->
    <script src="bower_components/peity/jquery.peity.min.js"></script>
    <!-- easy-pie-chart (circular statistics) -->
    <script src="bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js"></script>
    <!-- countUp -->
    <script src="bower_components/countUp.js/countUp.min.js"></script>
    <!--  dashbord functions -->
    <script src="assets/js/pages/dashboard.min.js"></script>
    <script src="assets/js/lib/dashboard/sales_view.js"></script>

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
