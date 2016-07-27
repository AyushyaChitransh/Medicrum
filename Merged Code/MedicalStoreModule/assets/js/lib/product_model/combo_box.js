$('#wizard_category').kendoComboBox({
    dataTextField: "text",
    dataValueField: "value",
    dataSource: [
      { text: "Medicines", value: "Medicines" },
      { text: "Supplements", value: "Supplements" },
      { text: "Cosmetics", value: "Cosmetics" },
      { text: "Equipments", value: "Equipments" },
      { text: "Other", value: "Other" }
    ],
    filter: "contains"
});
$('#wizard_sub_category').kendoComboBox({
    cascadeFrom: "wizard_category",
    cascadeFromField: "parentId",
    dataTextField: "text",
    dataValueField: "value",
    dataSource: [
        { text: "Tablets", value: "Tablets", parentId: "Medicines" },
        { text: "Capsules", value: "Capsules", parentId: "Medicines" },
        { text: "Syrup", value: "Syrup", parentId: "Medicines" },
        { text: "Gel", value: "Gel", parentId: "Medicines" },
        { text: "Cream", value: "Cream", parentId: "Medicines" },
        { text: "Powder", value: "Powder", parentId: "Medicines" },
        { text: "Liquid", value: "Liquid", parentId: "Medicines" },
        { text: "Oil", value: "Oil", parentId: "Medicines" },
        { text: "Other", value: "Other", parentId: "Medicines" },
        { text: "Supplements", value: "Supplements", parentId: "Supplements" },
        { text: "Cream", value: "Cream", parentId: "Cosmetics" },
        { text: "Powder", value: "Powder", parentId: "Cosmetics" },
        { text: "Deodrants", value: "Deodrants", parentId: "Cosmetics" },
        { text: "Oil", value: "Oil", parentId: "Cosmetics" },
        { text: "Other", value: "Other", parentId: "Cosmetics" },
        { text: "Machines", value: "Machines", parentId: "Equipments" },
        { text: "Monitors", value: "Monitors", parentId: "Equipments" },
        { text: "Warmers", value: "Warmers", parentId: "Equipments" },
        { text: "Medical Beds", value: "Medical Beds", parentId: "Equipments" },
        { text: "Medical Tables", value: "Medical Tables", parentId: "Equipments" },
        { text: "Medical Chairs", value: "Medical Chairs", parentId: "Equipments" },
        { text: "Pumps", value: "Pumps", parentId: "Equipments" },
        { text: "Stretchers", value: "Stretchers", parentId: "Equipments" },
        { text: "Surgical Lights ", value: "Surgical Lights ", parentId: "Equipments" },
        { text: "Ventilators", value: "Ventilators", parentId: "Equipments" },
        { text: "Other", value: "Other", parentId: "Other" }
    ],
    filter: "contains"
});
$('#wizard_type').kendoComboBox({
    dataTextField: "text",
    dataValueField: "value",
    dataSource: [
      { text: "Allopathic", value: "Allopathic" },
      { text: "Ayurvedic", value: "Ayurvedic" },
      { text: "Homeopathic", value: "Homeopathic" },
      { text: "Generic", value: "Generic" },
      { text: "Other", value: "Other" }
    ],
    filter: "contains"
});
$(function () {
    $.ajax({
        type: 'POST',
        url: 'AddProductModel.aspx/GetCompanyName',
        contentType: 'application/json; charset=utf-8',
        data: "{}",
        dataType: "json",
        success: function (response) {
            $('#wizard_company').kendoAutoComplete({
                dataSource: response.d,
                filter: "startswith",
                placeholder: "Company",
                separator: ", "
            });
        },
        error: function (error) {
            Notification('u');
        }
    });
});

