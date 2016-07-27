$(function () {
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/GetProductModelOptions",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var productModel = $("[id*=wizard_product_model_id]");
            productModel.empty().append('<option selected="selected" value="">Select Product Model</option>');

            $.each(msg.d.Options, function (index, item) {
                $("#wizard_product_model_id").get(0).options[index + 1] = new Option(item.DisplayText, item.Value);
            });
        },
        error: function () {
            Notification('u');
        }
    });
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/GetSupplierOptions",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var supplier = $("[id*=wizard_supplier_id]");
            supplier.empty().append('<option selected="selected" value="">Select Supplier</option>');

            $.each(msg.d.Options, function (index, item) {
                $("#wizard_supplier_id").get(0).options[index + 1] = new Option(item.DisplayText, item.Value);
            });
        },
        error: function () {
            Notification('u');
        }
    });
});