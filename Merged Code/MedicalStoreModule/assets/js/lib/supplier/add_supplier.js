function validate() {
    var supplierStoreName = document.getElementById('wizard_supplier_store_name').value;
    if (!supplierStoreName) {
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
            url: 'AddSupplier.aspx/InsertSupplier',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "AddUser.aspx";
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