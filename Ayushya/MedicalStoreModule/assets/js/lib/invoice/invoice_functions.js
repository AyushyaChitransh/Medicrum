//Add Customer
function AddCustomer()
{
    window.location = "AddCustomer.aspx";
}

//Add Invoice
function AddInvoice() {
    event.preventDefault();
    var data = JSON.stringify($('#form_invoice').serializeObject(), null, 2);
    UIkit.modal.alert('<p>Invoice data:</p><pre>' + data + '</pre>');
    $.ajax({
        type: 'POST',
        url: 'PageInvoice.aspx/InsertInvoiceAndBillingItems',
        contentType: 'application/json; charset=utf-8',
        data: data,
        success: function (response) {
            UIkit.notify({
                message: 'Saved the invoice!',
                status: 'success',
                timeout: 2000,
                group: null,
                pos: 'top-center'
            });
        },
        error: function (error) {
            UIkit.notify({
                message: 'Please Fill the * marked fields!',
                status: 'danger',
                timeout: 2000,
                group: null,
                pos: 'top-center'
            });
        }
    });
}


//Load Customer and Product Details
function GetCustomerOptions() {
    $.ajax({
        type: "POST",
        url: "PageInvoice.aspx/GetCustomerOptions",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var product = $("[id*=invoice_form_customer]");
            product.empty().append('<option selected="selected" value="">Select Customer</option>');
            $.each(msg.d, function (index, item) {
                var displayText = item.DisplayText + " | " + item.AdditionalText;
                $("#invoice_form_customer").get(0).options[index + 1] = new Option(displayText, item.Value);
            });
        },
        error: function () {
            alert("Failed to load");
        }
    });
}

function GetProductOptions(id) {
    $.ajax({
        type: "POST",
        url: "PageInvoice.aspx/GetProductOptions",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var product = $("[id*=inv_medicine_" + id + "]");
            product.empty().append('<option selected="selected" value="">Select Product</option>');
            $.each(msg.d, function (index, item) {
                var displayText = item.DisplayText + " | " + item.AdditionalText1 + " | " + item.AdditionalText2;
                $("#inv_medicine_" + id).get(0).options[index + 1] = new Option(displayText, item.Value);
            });
        },
        error: function () {
            alert("Failed to load");
        }
    });
}


//View Invoice
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
            invoice_id.invoice_date = GetDate(invoice_id.invoice_date);
            invoice_id.invoice_due_date = GetDate(invoice_id.invoice_due_date);
        },
        error: function (error) {
            alert('Failed to load Invoice');
        }
    });
    return invoice_id;
}