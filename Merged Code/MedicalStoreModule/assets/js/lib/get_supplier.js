$(function () {
    $.ajax({
        type: 'POST',
        url: 'ViewDetailedSupplier.aspx/GetSupplier',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Loading Details...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        success: function (response) {
            var arr = JSON.parse(response.d);
            document.getElementById("contact_person_name").value = arr.contactPersonName;
            document.getElementById("supplier_store_name").value = arr.supplierStoreName;
            document.getElementById("address").value = arr.address;
            document.getElementById("district").value = arr.district;
            document.getElementById("state").value = arr.state;
            document.getElementById("country").value = arr.country;
            document.getElementById("pincode").value = arr.pincode;
            document.getElementById("email").value = arr.email;
            document.getElementById("phone_number").value = arr.phoneNumber;
            document.getElementById("mobile").value = arr.mobile;
            document.getElementById("website").value = arr.website;
            document.getElementById("added_by").value = arr.addedBy;
            document.getElementById("added_timestamp").value = arr.addedTimestamp;
            document.getElementById("last_updated_by").value = arr.lastUpdatedBy;
            document.getElementById("last_updated_timestamp").value = arr.lastUpdatedTimestamp;
        },
        error: function (error) {
            alert("Failed to load data!");
        }
    });
});