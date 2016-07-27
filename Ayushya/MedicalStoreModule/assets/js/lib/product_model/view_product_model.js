function ViewDetailedProductModel(productModelId) {
    $.ajax({
        type: 'POST',
        url: 'ProductModelList.aspx/SetProductModelSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'productModelId': " + productModelId + " }",
        success: function () {
        },
        error: function (error) {
            Notification('u');
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedProductModel.aspx", '_blank');
    }, 500);
}