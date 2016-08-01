function response() {
    $("#product_list").jtable('load', {
        productModelId: $('#search_product').val()
    });
}

$(function () {
    // crud table
    altair_crud_table.init();
});

altair_crud_table = {
    init: function () {

        $('#product_list').jtable({
            paging: true,
            pageSize: 10,
            sorting: true,
            defaultSorting: 'productModelId ASC',
            deleteConfirmation: function (data) {
                data.deleteConfirmMessage = 'Are you sure to delete this record?';
            },
            formCreated: function (event, data) {
                // replace click event on some clickable elements
                // to make icheck label works
                data.form.find('.jtable-option-text-clickable').each(function () {
                    var $thisTarget = $(this).prev().attr('id');
                    $(this)
                        .attr('data-click-target', $thisTarget)
                        .off('click')
                        .on('click', function (e) {
                            e.preventDefault();
                            $('#' + $(this).attr('data-click-target')).iCheck('toggle');
                        })
                });
                // create selectize
                data.form.find('select').each(function () {
                    var $this = $(this);
                    $this.after('<div class="selectize_fix"></div>')
                    .selectize({
                        dropdownParent: 'body',
                        placeholder: 'Click here to select ...',
                        onDropdownOpen: function ($dropdown) {
                            $dropdown
                                .hide()
                                .velocity('slideDown', {
                                    begin: function () {
                                        $dropdown.css({ 'margin-top': '0' })
                                    },
                                    duration: 200,
                                    easing: easing_swiftOut
                                })
                        },
                        onDropdownClose: function ($dropdown) {
                            $dropdown
                                .show()
                                .velocity('slideUp', {
                                    complete: function () {
                                        $dropdown.css({ 'margin-top': '' })
                                    },
                                    duration: 200,
                                    easing: easing_swiftOut
                                })
                        }
                    });
                });
                // create icheck
                data.form
                    .find('input[type="checkbox"],input[type="radio"]')
                    .each(function () {
                        var $this = $(this);
                        $this.iCheck({
                            checkboxClass: 'icheckbox_md',
                            radioClass: 'iradio_md',
                            increaseArea: '20%'
                        })
                        .on('ifChecked', function (event) {
                            $this.parent('div.icheckbox_md').next('span').text('Active');
                        })
                        .on('ifUnchecked', function (event) {
                            $this.parent('div.icheckbox_md').next('span').text('Passive');
                        })
                    });
                // reinitialize inputs
                data.form.find('.jtable-input').children('input[type="text"],input[type="password"],textarea').not('.md-input').each(function () {
                    $(this).addClass('md-input');
                    altair_forms.textarea_autosize();
                });
                altair_md.inputs();
            },
            actions: {
                listAction: '/ProductList.aspx/ProductLists',
                updateAction: '/ProductList.aspx/UpdateProduct',
                deleteAction: '/ProductList.aspx/DeleteProduct'
            },
            fields: {
                productId: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                productModelId: {
                    title: 'Product Name',
                    width: '15%',
                    options: '/ProductList.aspx/GetProductModelOptions'
                },
                supplierId: {
                    title: 'Supplier Name',
                    width: '15%',
                    options: '/ProductList.aspx/GetSupplierOptions'
                },
                barcode: {
                    title: 'Barcode',
                    list: false
                },
                batchNumber: {
                    title: 'Batch Number',
                    list: false
                },
                manufactureDate: {
                    title: 'Manufacture Date',
                    type: 'date',
                    displayFormat: 'dd-mm-yy',
                    list: false
                },
                expiryDate: {
                    title: 'Expiry Date',
                    sorting: false,
                    type: 'date',
                    displayFormat: 'dd-mm-yy',
                    width: '15%',
                },
                packageQuantity: {
                    title: 'Package Quantity',
                    list: false
                },
                price: {
                    title: 'Price',
                    list: false
                },
                manufactureLicenceNumber: {
                    title: 'Manufacture Licence Number',
                    list: false
                },
                weight: {
                    title: 'Weight',
                    list: false
                },
                volume: {
                    title: 'Volume',
                    list: false
                },
                quantity: {
                    title: 'Quantity',
                    sorting: false,
                    width: '15%',
                },
                tax: {
                    title: 'Tax',
                    list: false
                },
                shelf: {
                    title: 'Shelf',
                    sorting: false,
                    width: '15%',
                },
                status: {
                    title: 'Status',
                    edit: false,
                    list: false
                },
                inStock: {
                    title: 'Stock',
                    width: '1%',
                    sorting: false,
                    edit: false,
                    options: { '2': '<span class="uk-badge uk-badge-warning">Emergency Stock</span>', '1': '<span class="uk-badge uk-badge-success">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspIn Stock&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</span>', '0': '<span class="uk-badge uk-badge-danger">&nbsp&nbsp&nbsp&nbspOut of Stock&nbsp&nbsp&nbsp&nbsp&nbsp</span>' }
                },
                viewButton: {
                    width: '1%',
                    create: false,
                    edit: false,
                    sorting: false,
                    display: function (data) {
                        return '<a href="#" onclick="ViewDetailedProduct(' + data.record.productId + ')"><i class="material-icons md-24">&#xE8F4;</i></a>';
                    }
                }
            }
        }).jtable('load', { productModelId: '' });

        // change buttons visual style in ui-dialog
        $('.ui-dialog-buttonset')
            .children('button')
            .attr('class', '')
            .addClass('md-btn md-btn-flat')
            .off('mouseenter focus');
        $('#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton').addClass('md-btn-flat-primary');

    }
};