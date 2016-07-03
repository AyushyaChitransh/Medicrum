function addDetails(form_serialized) {
    $.ajax({
        type: 'POST',
        url: 'AddStore.aspx/InsertStore',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'data': " + form_serialized + " }",
        dataType: "json",
        success: function (response) {
            if (response.d == true) {
                Notification('s');
                setTimeout(function () {
                    window.location = "Dashboard.aspx";
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
function CheckStoreId() {
    var storeId = document.getElementById("wizard_store_id").value;
    $.ajax({
        type: 'POST',
        url: 'AddStore.aspx/CheckStoreId',
        contentType: 'application/json; charset=utf-8',
        data: "{ 'StoreId': '" + storeId + "' }",
        success: function (response) {
            if (response.d == false) {
                document.getElementById("wizard_store_id").setAttribute("class", "md-input md-input-danger");
                document.getElementById("storeIdCheck").style.display = 'block';
                return false;
            }
            else {
                document.getElementById("wizard_store_id").setAttribute("class", "md-input md-input-success");
                document.getElementById("storeIdCheck").style.display = 'none';
                return true;
            }
        },
        error: function (error) {
            alert("Failed!");
        }
    });
}