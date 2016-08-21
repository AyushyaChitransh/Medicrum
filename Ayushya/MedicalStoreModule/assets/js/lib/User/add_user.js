function call() {
    var e = parseInt(document.getElementById('wizard_role').value);
    if (e == 2) {

        document.getElementById('wizard_privilege').style.display = 'block';
        document.getElementById('wizard_add_product_model').checked = false;
        document.getElementById('wizard_view_product_model').checked = false;
        document.getElementById('wizard_add_product').checked = false;
        document.getElementById('wizard_view_product').checked = false;
        document.getElementById('wizard_add_supplier').checked = false;
        document.getElementById('wizard_view_supplier').checked = false;
        document.getElementById('wizard_invoice').checked = false;
        document.getElementById('wizard_add_customer').checked = false;
        document.getElementById('wizard_view_customer').checked = false;

    }
    else if (e == 1) {
            document.getElementById('wizard_privilege').style.display = 'none';
            document.getElementById('wizard_add_product_model').checked = true;
            document.getElementById('wizard_view_product_model').checked = true;
            document.getElementById('wizard_add_product').checked = true;
            document.getElementById('wizard_view_product').checked = true;
            document.getElementById('wizard_add_supplier').checked = true;
            document.getElementById('wizard_view_supplier').checked = true;
            document.getElementById('wizard_invoice').checked = true;
            document.getElementById('wizard_add_customer').checked = true;
            document.getElementById('wizard_view_customer').checked = true;            
        }
}
function validate() {
    var userName = document.getElementById('wizard_user_name').value;
    var email = document.getElementById('wizard_email').checkValidity();
    var phone = document.getElementById('wizard_phone').checkValidity();
    var name = document.getElementById('wizard_name').value;
    var role = document.getElementById('wizard_role').value;
    var password = document.getElementById('wizard_password').value;
    if (!userName || !name || !role || !password || !email || !phone) {
        return false;
    }
    else {
        return true;
    }
}
function addDetails() {
    var result = validate();
    if (result) {
        event.preventDefault();
        $('#wizard_privilege').find('input[type="checkbox"]').each(function () {
            if ($(this).is(":checked") != true) {
                $(this).prop('checked', true);
                $(this).attr('value', '0');
            }
        });
        var form_serialized = JSON.stringify($('#wizard_advanced_form').serializeObject(), null, 2);
        $.ajax({
            type: 'POST',
            url: 'AddUser.aspx/InsertUser',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + ", 'userPrivileges': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "UserList.aspx";
                    }, 1000);
                }
                else
                    Notification('e');
            },
            error: function (error) {
                Notification('u');
            }
        });
    }
}
$('#wizard_advanced_form')
    .parsley()
                .on('form:validated', function () {
                    setTimeout(function () {
                        altair_md.update_input($('#wizard_advanced_form').find('.md-input'));
                        // adjust content height
                        $window.resize();
                    }, 100)
                })
                .on('field:validated', function (parsleyField) {

                    var $this = $(parsleyField.$element);
                    setTimeout(function () {
                        altair_md.update_input($this);
                        // adjust content height
                        var currentIndex = $('#wizard_advanced').find('.body.current').attr('data-step');
                    }, 100);

                });