function ViewDetailedProduct(productId) {
    $.ajax({
        type: 'POST',
        url: 'ViewProduct.aspx/SetProductSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'productId': " + productId + " }",
        success: function () {
        },
        error: function (error) {
            alert("Failed!");
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedProduct.aspx", '_blank');
    }, 500);
}