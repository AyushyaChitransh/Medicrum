//Add Customer
function AddCustomer()
{
    window.location = "AddCustomer.aspx";
}

//Add Invoice
function AddInvoice() {
    event.preventDefault();
    var data = JSON.stringify($('#form_invoice').serializeObject(), null, 2);
    //UIkit.modal.alert('<p>Invoice data:</p><pre>' + data + '</pre>');
    $.ajax({
        type: 'POST',
        url: 'PageInvoice.aspx/InsertInvoice',
        contentType: 'application/json; charset=utf-8',
        data: data,
        success: function (response) {
            window.location = "PageInvoice.aspx";
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
function GetInvoiceNumber() {
    $.ajax({
        type: "POST",
        url: "PageInvoice.aspx/GetInvoiceNumber",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            document.getElementById('invoice_number').value = msg.d;
        },
        error: function () {
            alert("Failed to load");
        }
    });
}

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
                var displayText = item.DisplayText + " | " + item.AdditionalText;
                $("#inv_medicine_" + id).get(0).options[index + 1] = new Option(displayText, item.Value);
            });
        },
        error: function () {
            alert("Failed to load");
        }
    });
}

function GetUnitPrice(id) {
    var productId = document.getElementById('inv_medicine_' + id).value;
    $.ajax({
        type: "POST",
        url: "PageInvoice.aspx/GetProductPrice",
        data: "{ 'productId': " + productId + " }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            document.getElementById('inv_medicine_' + id + '_unit_price').value = msg.d;
        },
        error: function () {
            alert("Failed to load");
        }
    });
}

function CalculateTotal(id) {
    var quantity = document.getElementById('inv_medicine_' + id + '_qty').value;
    var unitPrice = document.getElementById('inv_medicine_' + id + '_unit_price').value;
    document.getElementById('inv_medicine_' + id + '_price').value = quantity * unitPrice;
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

function response() {
    var searchText = document.getElementById('search_invoice').value;
    $.ajax({
        type: 'POST',
        url: 'PageInvoice.aspx/InvoiceSideBar',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'searchText': '" + searchText + "' }",
        dataType: "json",
        success: function (response) {
            document.getElementById('invoices_list').innerHTML = response.d;
        },
        error: function (error) {
            alert('Failed to load Invoice');
        }
    });
}

//Delete invoice
function DeleteInvoice(invoiceId)
{
    $.ajax({
        type: 'POST',
        url: 'PageInvoice.aspx/DeleteInvoice',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'invoiceId': " + invoiceId + " }",
        dataType: "json",
        success: function (response) {
            window.location = "PageInvoice.aspx";
        },
        error: function (error) {
            alert(JSON.stringify(error));
        }
    });
}