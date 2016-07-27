function ViewDetailedProduct(productId) {
    $.ajax({
        type: 'POST',
        url: 'ProductList.aspx/SetProductSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'productId': " + productId + " }",
        success: function () {
        },
        error: function (error) {
            Notification('u');
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedProduct.aspx", '_blank');
    }, 500);
}