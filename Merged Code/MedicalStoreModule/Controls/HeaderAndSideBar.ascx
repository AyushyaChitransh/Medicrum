<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderAndSideBar.ascx.cs" Inherits="MedicalStoreModule.Controls.HeaderAndSideBar" %>

<!-- main header -->
<header id="header_main">
    <div class="header_main_content">
        <nav class="uk-navbar">

            <!-- main sidebar switch -->
            <a href="#" id="sidebar_main_toggle" class="sSwitch sSwitch_left">
                <span class="sSwitchIcon"></span>
            </a>

            <!-- secondary sidebar switch -->
            <a href="#" id="sidebar_secondary_toggle" class="sSwitch sSwitch_right sidebar_secondary_check">
                <span class="sSwitchIcon"></span>
            </a>

            <div id="menu_top_dropdown" class="uk-float-left uk-hidden-small">
                <div class="uk-button-dropdown" data-uk-dropdown="{mode:'click'}">
                    <a href="#" class="top_menu_toggle" data-uk-tooltip="{pos:'bottom'}" title="Shortcuts"><i class="material-icons md-24">&#xE8F0;</i></a>
                    <div class="uk-dropdown uk-dropdown-width-2">
                        <div class="uk-grid uk-dropdown-grid" data-uk-grid-margin="data-uk-grid-margin">
                            <div class="uk-width-1">
                                <div class="uk-grid uk-grid-width-medium-1-3 uk-margin-top uk-margin-bottom uk-text-center" data-uk-grid-margin="data-uk-grid-margin">
                                    <a href="PageInvoice.aspx">
                                        <i class="material-icons md-36">&#xE53E;</i>
                                        <span class="uk-text-muted uk-display-block">Inovice</span>
                                    </a>
                                    <a href="AddProduct.aspx">
                                        <i class="material-icons md-36">&#xE8CB;</i>
                                        <span class="uk-text-muted uk-display-block">Add Inventory</span>
                                    </a>
                                    <a href="AddProductModel.aspx">
                                        <i class="material-icons md-36">description</i>
                                        <span class="uk-text-muted uk-display-block">Add Product Model</span>
                                    </a>
                                    <a href="AddCustomer.aspx">
                                        <i class="material-icons md-36">person</i>
                                        <span class="uk-text-muted uk-display-block">Add Customer</span>
                                    </a>
                                    <a href="AddSupplier.aspx">
                                        <i class="material-icons md-36">people</i>
                                        <span class="uk-text-muted uk-display-block">Add Supplier</span>
                                    </a>  
                                    <a href="ViewProduct.aspx">
                                        <i class="material-icons md-36">&#xE8CB;</i>
                                        <span class="uk-text-muted uk-display-block">View Inventory</span>
                                    </a>                                  
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="uk-navbar-flip">
                <ul class="uk-navbar-nav user_actions">
                    <li><a href="#" id="full_screen_toggle" class="user_action_icon uk-visible-large" data-uk-tooltip="{pos:'bottom'}" title="Full Screen"><i class="material-icons md-24 md-light">&#xE5D0;</i></a></li>
                    <li data-uk-dropdown="{mode:'click',pos:'bottom-right'}">
                        <a href="#" class="user_action_icon">
                            <span><i class="material-icons md-24 md-light">settings_input_composite</i></span></a>
                        <div class="uk-dropdown uk-dropdown-small">
                            <ul class="uk-nav js-uk-prevent">
                                <li><a href="UserProfile.aspx">My Account</a></li>
                                <li><a href="StoreProfile.aspx">Store</a></li>
                                <li><a href="#" onclick="logout()">Logout</a></li>
                            </ul>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
    <div class="header_main_search_form">
        <i class="md-icon header_main_search_close material-icons">&#xE5CD;</i>
        <form class="uk-form">
            <input type="text" class="header_main_search_input" />
            <button class="header_main_search_btn uk-button-link"><i class="md-icon material-icons">&#xE8B6;</i></button>
        </form>
    </div>
</header>
<script>
    function logout() {
        $.ajax({
            type: 'POST',
            url: 'Login.aspx/Logout',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                window.location = "Login.aspx";
            },
            error: function (error) {
                Notification('u');
            }
        });
    }
</script>
<!-- main header end -->

<!-- main sidebar -->
<aside id="sidebar_main">

    <div class="sidebar_main_header">
        <div class="sidebar_logo">
            <a href="#" class="sSidebar_hide">
                <img src="assets/img/MedicrumLogo2-1.png" alt="" height="55" width="120" /></a>
            <a href="#" class="sSidebar_show">
                <img src="assets/img/MedicrumLogo2-1.png" alt="" height="32" width="32" /></a>
        </div>
    </div>

    <div class="menu_section">
        <ul>
            <li title="Dashboard" id="Dashboard">
                <a href="Dashboard.aspx">
                    <span class="menu_icon"><i class="material-icons">&#xE871;</i></span>
                    <span class="menu_title">Dashboard</span>
                </a>
            </li>
            <li title="Product Model" id="Product Model">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">description</i></span>
                    <span class="menu_title">Product Model</span>
                </a>
                <ul>
                    <li id="Add Product Model"><a href="AddProductModel.aspx">Add Product Model</a></li>
                    <li id="View Product Model"><a href="ViewProductModel.aspx">View Product Model</a></li>
                </ul>
            </li>
            <li title="Inventory" id="Inventory">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">&#xE8CB;</i></span>
                    <span class="menu_title">Inventory</span>
                </a>
                <ul>
                    <li id="Add Product"><a href="AddProduct.aspx">Add Product</a></li>
                    <li id="View Product"><a href="ViewProduct.aspx">View Product</a></li>
                    <li id="Emergency Stocks"><a href="EmergencyStocks.aspx">Emergency Stocks</a></li>
                    <li id="Empty Stocks"><a href="EmptyStocks.aspx">Empty Stocks</a></li>
                </ul>
            </li>
            <li title="Invoice" id="Invoice">
                <a href="PageInvoice.aspx">
                    <span class="menu_icon"><i class="material-icons">&#xE53E;</i></span>
                    <span class="menu_title">Inovice</span>
                </a>
            </li>
            <li title="Customer" id="Customer">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">person</i></span>
                    <span class="menu_title">Customer</span>
                </a>
                <ul>
                    <li id="Add Customer"><a href="AddCustomer.aspx">Add Customer</a></li>
                    <li id="View Customer"><a href="ViewCustomer.aspx">View Customer</a></li>
                </ul>
            </li>
            <li title="Supplier" id="Supplier">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">people</i></span>
                    <span class="menu_title">Supplier</span>
                </a>
                <ul>
                    <li id="Add Supplier"><a href="AddSupplier.aspx">Add Supplier</a></li>
                    <li id="View Supplier"><a href="ViewSupplier.aspx">View Supplier</a></li>
                </ul>
            </li>
            <li title="User" id="User">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">face</i></span>
                    <span class="menu_title">User</span>
                </a>
                <ul>
                    <li id="My Profile"><a href="UserProfile.aspx">My Profile</a></li>
                    <li id="Add User"><a href="AddUser.aspx">Add User</a></li>
                    <li id="View User"><a href="ViewUser.aspx">View User</a></li>
                </ul>
            </li>
        </ul>
    </div>
    <script>
        var activeItem = document.title;
        document.getElementById(activeItem).setAttribute("class", "current_section act_item");
    </script>
</aside>
<!-- main sidebar end -->
