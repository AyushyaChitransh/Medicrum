function addDetails(form_serialized) {
    $.ajax({
        type: 'POST',
        url: 'AddProductModel.aspx/InsertProduct',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'data': " + form_serialized + " }",
        dataType: "json",
        success: function (response) {
            if (response.d == true) {
                Notification('s');
                setTimeout(function () {
                    window.location = "AddProduct.aspx";
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