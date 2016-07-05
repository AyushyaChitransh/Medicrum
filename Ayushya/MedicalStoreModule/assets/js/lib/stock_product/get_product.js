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
            document.getElementById("productModelId").value = arr.productName;
            //document.getElementById("productModelName").value = arr.productModelName;
            document.getElementById("supplierId").value = arr.supplierStoreName;
            document.getElementById("barcode").value = arr.barcode;
            document.getElementById("batchNumber").value = arr.batchNumber;
            var date = GetDate(arr.manufactureDate);
            document.getElementById("manufactureDate").value = date;
            date = GetDate(arr.expiryDate);
            document.getElementById("expiryDate").value = date;
            document.getElementById("packageQuantity").value = arr.packageQuantity;
            document.getElementById("price").value = arr.price;
            document.getElementById("manufactureLicenceNumber").value = arr.manufactureLicenceNumber;
            document.getElementById("weight").value = arr.weight;
            document.getElementById("volume").value = arr.volume;
            document.getElementById("quantity").value = arr.quantity;
            document.getElementById("tax").value = arr.tax;
            if (arr.inStock == 1) {
                document.getElementById("inStock").style.display = 'block';
            }
            else {
                document.getElementById("outOfStock").style.display = 'block';
            }
        },
        error: function (error) {
            alert("Failed to load data!");
        }
    });
});