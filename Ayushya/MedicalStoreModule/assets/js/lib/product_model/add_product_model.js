function validate() {
    var productName = document.getElementById('wizard_product_name').value;
    var tradeName = document.getElementById('wizard_trade_name').value;
    var company = document.getElementById('wizard_company').value;
    var category = document.getElementById('wizard_category').value;
    var type = document.getElementById('wizard_type').value;
    if (!productName || !tradeName || !company || !category || !type) {
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
            url: 'AddProductModel.aspx/InsertProductModel',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "AddProductModel.aspx";
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