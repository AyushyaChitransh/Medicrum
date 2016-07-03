function ViewDetailedCustomer(customerId) {
    $.ajax({
        type: 'POST',
        url: 'ViewCustomer.aspx/SetCustomerSession',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'customerId': " + customerId + " }",
        success: function () {
        },
        error: function (error) {
            alert("Failed!");
        }
    });
    setTimeout(function () {
        window.open("ViewDetailedCustomer.aspx", '_blank');
    }, 500);
}