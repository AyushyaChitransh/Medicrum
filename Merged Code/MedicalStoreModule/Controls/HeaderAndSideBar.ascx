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
                    <a href="#" class="top_menu_toggle"><i class="material-icons md-24">&#xE8F0;</i></a>
                    <div class="uk-dropdown uk-dropdown-width-2">
                        <div class="uk-grid uk-dropdown-grid" data-uk-grid-margin="data-uk-grid-margin">
                            <div class="uk-width-1">
                                <div class="uk-grid uk-grid-width-medium-1-3 uk-margin-top uk-margin-bottom uk-text-center" data-uk-grid-margin="data-uk-grid-margin">
                                    <a href="AddUser.aspx">
                                        <i class="material-icons md-36">face</i>
                                        <span class="uk-text-muted uk-display-block">Add User</span>
                                    </a>
                                    <a href="ViewProductModel.aspx">
                                        <i class="material-icons md-36">description</i>
                                        <span class="uk-text-muted uk-display-block">Product Model</span>
                                    </a>
                                    <a href="ViewSupplier.aspx">
                                        <i class="material-icons md-36">people</i>
                                        <span class="uk-text-muted uk-display-block">Supplier</span>
                                    </a>
                                    <a href="ViewProduct.aspx">
                                        <i class="material-icons md-36">&#xE8CB;</i>
                                        <span class="uk-text-muted uk-display-block">Inventory</span>
                                    </a>
                                    <a href="ViewCustomer.aspx">
                                        <i class="material-icons md-36">person</i>
                                        <span class="uk-text-muted uk-display-block">Customer</span>
                                    </a>
                                    <a href="#">
                                        <i class="material-icons md-36">&#xE53E;</i>
                                        <span class="uk-text-muted uk-display-block">Inovice</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="uk-navbar-flip">
                <ul class="uk-navbar-nav user_actions">
                    <li><a href="#" id="full_screen_toggle" class="user_action_icon uk-visible-large"><i class="material-icons md-24 md-light">&#xE5D0;</i></a></li>
                    <%--<li><a href="#" id="main_search_btn" class="user_action_icon"><i class="material-icons md-24 md-light">&#xE8B6;</i></a></li>--%>
                    <%--<li data-uk-dropdown="{mode:'click',pos:'bottom-right'}">
                        <a href="#" class="user_action_icon"><i class="material-icons md-24 md-light">&#xE7F4;</i><span class="uk-badge">16</span></a>
                        <div class="uk-dropdown uk-dropdown-xlarge">
                            <div class="md-card-content">
                                <ul class="uk-tab uk-tab-grid" data-uk-tab="{connect:'#header_alerts',animation:'slide-horizontal'}">
                                    <li class="uk-width-1-2 uk-active"><a href="#" class="js-uk-prevent uk-text-small">Messages (12)</a></li>
                                    <li class="uk-width-1-2"><a href="#" class="js-uk-prevent uk-text-small">Alerts (4)</a></li>
                                </ul>
                                <ul id="header_alerts" class="uk-switcher uk-margin">
                                    <li>
                                        <ul class="md-list md-list-addon">
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <span class="md-user-letters md-bg-cyan">vz</span>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading"><a href="pages_mailbox.html">Ad corporis.</a></span>
                                                    <span class="uk-text-small uk-text-muted">Qui inventore ratione quis aut alias voluptatem ut est in ea accusamus.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <img class="md-user-image md-list-addon-avatar" src="assets/img/avatars/avatar_07_tn.png" alt="" />
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading"><a href="pages_mailbox.html">Vel eum accusamus.</a></span>
                                                    <span class="uk-text-small uk-text-muted">Enim suscipit vel saepe sed dolores iste sint dicta odit delectus.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <span class="md-user-letters md-bg-light-green">fb</span>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading"><a href="pages_mailbox.html">Inventore saepe.</a></span>
                                                    <span class="uk-text-small uk-text-muted">Et eius labore tenetur unde porro voluptatibus omnis et quos.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <img class="md-user-image md-list-addon-avatar" src="assets/img/avatars/avatar_02_tn.png" alt="" />
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading"><a href="pages_mailbox.html">Voluptatem culpa ab.</a></span>
                                                    <span class="uk-text-small uk-text-muted">Tempore qui sed voluptatem quam eligendi in voluptas rem sit saepe.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <img class="md-user-image md-list-addon-avatar" src="assets/img/avatars/avatar_09_tn.png" alt="" />
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading"><a href="pages_mailbox.html">Nobis necessitatibus beatae.</a></span>
                                                    <span class="uk-text-small uk-text-muted">Nesciunt quam qui eum consequatur sint.</span>
                                                </div>
                                            </li>
                                        </ul>
                                        <div class="uk-text-center uk-margin-top uk-margin-small-bottom">
                                            <a href="page_mailbox.html" class="md-btn md-btn-flat md-btn-flat-primary js-uk-prevent">Show All</a>
                                        </div>
                                    </li>
                                    <li>
                                        <ul class="md-list md-list-addon">
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <i class="md-list-addon-icon material-icons uk-text-warning">&#xE8B2;</i>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading">Autem eos et.</span>
                                                    <span class="uk-text-small uk-text-muted uk-text-truncate">Architecto tenetur optio quo eos.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <i class="md-list-addon-icon material-icons uk-text-success">&#xE88F;</i>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading">Aut sint.</span>
                                                    <span class="uk-text-small uk-text-muted uk-text-truncate">Tempore dolor at expedita unde dolorem.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <i class="md-list-addon-icon material-icons uk-text-danger">&#xE001;</i>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading">Praesentium sed ratione.</span>
                                                    <span class="uk-text-small uk-text-muted uk-text-truncate">Molestias ut sit aperiam iste.</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="md-list-addon-element">
                                                    <i class="md-list-addon-icon material-icons uk-text-primary">&#xE8FD;</i>
                                                </div>
                                                <div class="md-list-content">
                                                    <span class="md-list-heading">Et at omnis.</span>
                                                    <span class="uk-text-small uk-text-muted uk-text-truncate">Voluptatem doloremque sed ea cum.</span>
                                                </div>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </li>--%>
                    <li data-uk-dropdown="{mode:'click',pos:'bottom-right'}">
                        <a href="#" class="user_action_icon">
                            <span><i class="material-icons md-24 md-light">menu</i></span></a>
                        <div class="uk-dropdown uk-dropdown-small">
                            <ul class="uk-nav js-uk-prevent">
                                <li><a href="UserProfile.aspx">My profile</a></li>
                                <li><a href="StoreProfile.aspx">My Store</a></li>
                                <%--<li><a href="page_settings.html">Settings</a></li>--%>
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
                <img src="assets/img/logo_main.png" alt="" height="15" width="71" /></a>
            <a href="#" class="sSidebar_show">
                <img src="assets/img/logo_main_small.png" alt="" height="32" width="32" /></a>
        </div>
        <div class="sidebar_actions">
            <select id="lang_switcher" name="lang_switcher">
                <option value="gb" selected="selected">English</option>
            </select>
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
            <li title="Inovice" id="Inovice">
                <a href="#">
                    <span class="menu_icon"><i class="material-icons">&#xE53E;</i></span>
                    <span class="menu_title">Inovice</span>
                </a>
            </li>
        </ul>
    </div>
    <script>
        var activeItem = document.title;
        document.getElementById(activeItem).setAttribute("class", "current_section act_item");
    </script>
</aside>
<!-- main sidebar end -->
