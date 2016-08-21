$(function () {
    $.ajax({
        type: 'POST',
        url: 'Dashboard.aspx/GetSales',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var arr = response.d;
            if (arr !== false) {
                alert(arr);
                console.log(arr);
                var template = $('#admin_sales_template').html(),
                    template_compiled = Handlebars.compile(template),
                    context = arr,
                    the_compiled_html = template_compiled(context);
                $('#admin_sales_view').html(the_compiled_html);
            }
        },
        error: function (error) {
            Notification('u');
        }
    });
});