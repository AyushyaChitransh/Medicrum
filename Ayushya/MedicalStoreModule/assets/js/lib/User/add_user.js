function validate() {
    var userName = document.getElementById('wizard_user_name').value;
    var validUesrName = function () {
        if (!userName) {
            return false;
        }
        if (!CheckUserName) {
            alert("User Name must be unique!");
            return false;
        }
            return true;
    }
    var validEmail = function () {
        if (!CheckEmail()) {
            return false;
        }
        else {
            return true;
        }
    }
    if (validUesrName && validEmail) {
        return true;
    }
    else {
        return false;
    }
}
function addDetails() {
    event.preventDefault();
    var result = validate();
    if (ValidityState) {
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
function CheckEmail() {
    var email = document.getElementById("wizard_email").value;
    $.ajax({
        type: 'POST',
        url: 'AddUser.aspx/CheckEmail',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'email': '" + email + "' }",
        success: function (response) {
            if (response.d == false) {
                document.getElementById("wizard_email").setAttribute("class", "md-input md-input-danger");
                document.getElementById("emailCheck").style.display = 'block';
                return false;
            }
            else {
                document.getElementById("wizard_email").setAttribute("class", "md-input md-input-success");
                document.getElementById("emailCheck").style.display = 'none';
                return true;
            }
        },
        error: function (error) {
            alert("Failed!");
        }
    });
}
function CheckUserName() {
    var userName = document.getElementById("wizard_user_name").value;
    $.ajax({
        type: 'POST',
        url: 'AddUser.aspx/CheckUserName',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'userName': '" + userName + "' }",
        success: function (response) {
            if (response.d == false) {
                document.getElementById("wizard_user_name").setAttribute("class", "md-input md-input-danger");
                document.getElementById("userNameCheck").style.display = 'block';
                return false;
            }
            else {
                document.getElementById("wizard_user_name").setAttribute("class", "md-input md-input-success");
                document.getElementById("userNameCheck").style.display = 'none';
                return true;
            }
        },
        error: function (error) {
            alert("Failed!");
        }
    });
}
$('#wizard_advanced_form')
    .parsley()
            .on('form:validated', function () {
                setTimeout(function () {
                    altair_md.update_input($wizard_advanced_form.find('.md-input'));
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
                    altair_wizard.content_height($('#wizard_advanced'), currentIndex);
                }, 100);

            });
