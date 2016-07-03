function validate() {
    var productModelId = document.getElementById('wizard_product_model_id').value;
    var supplierId = document.getElementById('wizard_supplier_id').value;
    var batchNumber = document.getElementById('wizard_batch_number').value;
    var packageQuantity = document.getElementById('wizard_package_quantity').value;
    var quantity = document.getElementById('wizard_quantity').value;
    var price = document.getElementById('wizard_price').value;
    var manufactureDate = document.getElementById('wizard_manufacture_date').value;
    var expiryDate = document.getElementById('wizard_expiry_date').value;
    if (!productModelId || !supplierId || !batchNumber || !packageQuantity || !quantity || !price || !manufactureDate || !expiryDate) {
        return false;
    }
    else {
        return true;
    }
        
}
function addDetails() {
    $('#wizard_advanced_form')
    .parsley()
                .on('form:validated', function () {
                    setTimeout(function () {
                        altair_md.update_input($wizard_advanced_form.find('.md-input'));
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
                        altair_wizard.content_height($('#wizard_advanced'), currentIndex);
                    }, 100);

                });
    var result = validate();
    if (result) {
        event.preventDefault();
        var form_serialized = JSON.stringify($('#wizard_advanced_form').serializeObject(), null, 2);
        $.ajax({
            type: 'POST',
            url: 'AddProduct.aspx/InsertProduct',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "AddProduct.aspx";
                    }, 1000);
                }
                else
                    Notification('u');
            },
            error: function (error) {
                Notification('u');
            }
        });
    }
}