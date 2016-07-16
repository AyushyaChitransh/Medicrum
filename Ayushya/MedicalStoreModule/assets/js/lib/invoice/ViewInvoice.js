function GetInvoiceDetails(invoiceId) {
    var invoice_id;
    $.ajax({
        type: 'POST',
        url: 'PageInvoice.aspx/GetInvoice',
        contentType: 'application/json; charset=utf-8',
        async: false,
        data: "{ 'invoiceId': " + invoiceId + " }",
        dataType: "json",
        success: function (response) {
            invoice_id = JSON.parse(response.d);
            invoice_id.invoice_date = parseJsonDate(invoice_id.invoice_date);
            invoice_id.invoice_due_date = parseJsonDate(invoice_id.invoice_due_date);
        },
        error: function (error) {
            alert('Failed to load Invoice');
        }
    });
    return invoice_id;
}

function parseJsonDate(jsonDateString) {
    var dateObj = new Date(parseInt(jsonDateString.substr(6)));
    return (dateObj.getMonth() + "." + dateObj.getDate() + "." + dateObj.getFullYear());
}