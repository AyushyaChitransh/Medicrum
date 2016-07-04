$(function () {
    $.ajax({
        type: 'POST',
        url: 'ViewDetailedProduct.aspx/GetProduct',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (modal) {
            modal = UIkit.modal.blockUI('<div class=\'uk-text-center\'>Loading Details...<br/><img class=\'uk-margin-top\' src=\'assets/img/spinners/spinner.gif\' alt=\'\'>');
            setTimeout(function () {
                modal.hide()
            }, 1000);
        },
        success: function (response) {
            var arr = JSON.parse(response.d);
            document.getElementById("productId").value = arr.productId;
            document.getElementById("productModelId").value = arr.productModelId;
            //document.getElementById("productModelName").value = arr.productModelName;
            //document.getElementById("storeId").value = arr.storeId;
            //document.getElementById("supplierId").value = arr.supplierId;
            document.getElementById("barcode").value = arr.barcode;
            document.getElementById("batchNumber").value = arr.batchNumber;
            document.getElementById("manfactureDate").value = arr.manfactureDate;
            document.getElementById("expiryDate").value = arr.expiryDate;
            document.getElementById("packageQuantity").value = arr.packageQuantity;
            document.getElementById("price").value = arr.price;
            document.getElementById("manufacturingLicenceNumber").value = arr.manufacturingLicenceNumber;
            document.getElementById("weight").value = arr.weight;
            document.getElementById("volume").value = arr.volume;
            document.getElementById("quantity").value = arr.quantity;
            document.getElementById("tax").value = arr.tax;
            document.getElementById("status").value = arr.status;
            document.getElementById("inStock").value = arr.inStock;
            document.getElementById("deleteStatus").value = arr.deleteStatus;
            alert(arr.addedBy + "  " + arr.lastUpdatedBy);
        },
        error: function (error) {
            alert("Failed to load data!");
        }
    });
});