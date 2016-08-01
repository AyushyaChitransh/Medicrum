$(function () {
    $.ajax({
        type: "POST",
        url: "AddProduct.aspx/GetProductModelOptions",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $('#wizard_product_model_id').kendoComboBox({
                dataTextField: "DisplayText",
                dataValueField: "Value",
                dataSource: msg.d.Options,
                placeholder: "Select Product Model",
                filter: "contains"
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
            $('#wizard_supplier_id').kendoComboBox({
                dataTextField: "DisplayText",
                dataValueField: "Value",
                dataSource: msg.d.Options,
                placeholder: "Select Supplier",
                filter: "contains"
            });
        },
        error: function () {
            Notification('u');
        }
    });
});