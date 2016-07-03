$(function () {
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/GetProductModelForProduct",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var productModel = $("[id*=wizard_product_model_id]");
            productModel.empty().append('<option selected="selected" value="">Select Product Model</option>');

            $.each(msg.d, function (index, item) {
                $("#wizard_product_model_id").get(0).options[index + 1] = new Option(item.Value, item.Key);
            });
        },
        error: function () {
            alert("Failed to load");
        }
    });
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/GetSupplierForProduct",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var supplier = $("[id*=wizard_supplier_id]");
            supplier.empty().append('<option selected="selected" value="">Select Supplier</option>');

            $.each(msg.d, function (index, item) {
                $("#wizard_supplier_id").get(0).options[index + 1] = new Option(item.Value, item.Key);
            });
        },
        error: function () {
            alert("Failed to load");
        }
    });
});