function ViewDetailedSupplier(supplierId) {
    $.ajax({
        type: 'POST',
        url: 'SupplierList.aspx/SetSupplierSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'supplierId': " + supplierId + " }",
        success: function () {
        },
        error: function (error) {
            Notification('u');
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedSupplier.aspx", '_blank');
    }, 500);
}