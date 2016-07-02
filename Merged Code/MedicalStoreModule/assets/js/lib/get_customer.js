$(function () {
    $.ajax({
        type: 'POST',
        url: 'ViewDetailedCustomer.aspx/GetCustomer',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Loading Details...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        success: function (response) {
            var arr = JSON.parse(response.d);
            document.getElementById("customer_name").value = arr.customerName;
            document.getElementById("company_name").value = arr.companyName;
            document.getElementById("address").value = arr.address;
            document.getElementById("district").value = arr.district;
            document.getElementById("state").value = arr.state;
            document.getElementById("country").value = arr.country;
            document.getElementById("pincode").value = arr.pincode;
            document.getElementById("email").value = arr.email;
            document.getElementById("phone_number").value = arr.phoneNumber;
            document.getElementById("mobile").value = arr.mobile;
            document.getElementById("date_of_birth").value = arr.date_of_birth;
            document.getElementById("height").value = arr.height;
            document.getElementById("weight").value = arr.weight;
            document.getElementById("blood_group").value = arr.blood_group;
            document.getElementById("added_by").value = arr.addedBy;
            document.getElementById("added_timestamp").value = arr.addedTimestamp;
            document.getElementById("last_updated_by").value = arr.lastUpdatedBy;
            document.getElementById("last_updated_timestamp").value = arr.lastUpdatedTimestamp;
            alert(arr.addedBy + "  " + arr.lastUpdatedBy);
        },
        error: function (error) {
            alert("Failed to load data!");
        }
    });
});