function ViewDetailedSupplier(supplierId) {
    $.ajax({
        type: 'POST',
        url: 'ViewSupplier.aspx/SetSupplierSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'supplierId': " + supplierId + " }",
        success: function () {
        },
        error: function (error) {
            alert("Failed!");
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedSupplier.aspx", '_blank');
    }, 50);
}