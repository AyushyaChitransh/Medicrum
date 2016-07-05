function validate() {
    var userName = document.getElementById('wizard_user_name').value;
    var validUesrName = CheckUserName();
    var validEmail = CheckEmail();
    var name = document.getElementById('wizard_name').value;
    var role = document.getElementById('wizard_role').value;
    var password = document.getElementById('wizard_password').value;
    if (!validUesrName || !validEmail || !userName || !name || !role || !password) {
        return false;
    }
    else {
        return true;
    }
}
function addDetails() {
    $('#wizard_advanced_form')
    .parsley()
                .on('form:validated', function () {
                    setTimeout(function () {
                        altair_md.update_input($('#wizard_advanced_form').find('.md-input'));
                        // adjust content height
                        $window.resize();
                    }, 100)
                })
                .on('field:validated', function (parsleyField) {

                    var $this = $(parsleyField.$element);
                    setTimeout(function () {
                        altair_md.update_input($this);
                        // adjust content height
                        var currentIndex = $('#wizard_advanced').find('.body.current').attr('data-step');
                    }, 100);

                });
    var result = validate();
    if (result) {
        event.preventDefault();
        var form_serialized = JSON.stringify($('#wizard_advanced_form').serializeObject(), null, 2);
        $.ajax({
            type: 'POST',
            url: 'AddUser.aspx/InsertUser',
            contentType: 'application/json; charset=utf-8',
            data: "{ 'data': " + form_serialized + " }",
            dataType: "json",
            success: function (response) {
                if (response.d == true) {
                    Notification('s');
                    setTimeout(function () {
                        window.location = "AddUser.aspx";
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
}