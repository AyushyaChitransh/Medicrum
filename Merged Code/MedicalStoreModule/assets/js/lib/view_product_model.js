function ViewDetailedProduct(productModelId) {
    $.ajax({
        type: 'POST',
        url: 'ViewProductModel.aspx/SetProductSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'productModelId': " + productModelId + " }",
        success: function () {
        },
        error: function (error) {
            alert("Failed!");
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedProductModel.aspx", '_blank');
    }, 50);
}