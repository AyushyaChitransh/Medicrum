﻿function validate() {
    var supplierStoreName = document.getElementById('wizard_supplier_store_name').value;
    var email = document.getElementById('wizard_email').checkValidity();
    var mobile = document.getElementById('wizard_mobile_number').checkValidity();
    var phone = document.getElementById('wizard_phone').checkValidity();
    var website = document.getElementById('wizard_website').checkValidity();
    if (!supplierStoreName || !email || !mobile || !phone || !website) {
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
        var form_serialized = JSON.stringify($('#wizard_advanced_form').serializeObject(), null, 2);
        $.ajax({
            type: 'POST',
            url: 'AddSupplier.aspx/InsertSupplier',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "SupplierList.aspx";
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