$(function () {
    $.ajax({
        type: 'POST',
        url: 'ViewDetailedProductModel.aspx/GetProduct',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Loading Details...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        success: function (response) {
            var arr = JSON.parse(response.d);
            document.getElementById("product_name").value = arr.productName;
            document.getElementById("trade_name").value = arr.tradeName;
            document.getElementById("company").value = arr.company;
            document.getElementById("composition").value = arr.composition;
            document.getElementById("purpose").value = arr.purpose;
            document.getElementById("category").value = arr.category;
            document.getElementById("sub_category").value = arr.subCategory;
            document.getElementById("type").value = arr.type;
            document.getElementById("dosage_instruction").value = arr.dosageInstruction;
            document.getElementById("storage_instruction").value = arr.storageInstruction;
            document.getElementById("schedule").value = arr.schedule;
            document.getElementById("description").value = arr.description;
            document.getElementById("other_information").value = arr.otherInformation;
            document.getElementById("indications").value = arr.indications;
            document.getElementById("warning").value = arr.warning;
            //document.getElementById("added_by").value = arr.addedBy;
            //document.getElementById("added_timestamp").value = arr.addedTimestamp;
            //document.getElementById("last_updated_by").value = arr.lastUpdatedBy;
            //document.getElementById("last_updated_timestamp").value = arr.lastUpdatedTimestamp;
        },
        error: function (error) {
            Notification('u');
        }
    });
});