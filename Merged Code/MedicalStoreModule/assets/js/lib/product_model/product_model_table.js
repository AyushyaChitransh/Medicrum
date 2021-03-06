﻿function response() {
    $("#product_model_list").jtable('load', {
        productName: $('#search_product_model').val()
    });
}

$(function () {
    // crud table
    altair_crud_table.init();
});

altair_crud_table = {
    init: function () {

        $('#product_model_list').jtable({
            paging: true,
            pageSize: 10,
            sorting: true,
            defaultSorting: 'productName ASC',
            deleteConfirmation: function (data) {
                data.deleteConfirmMessage = 'Are you sure to delete records of ' + data.record.productName + '?';
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
                listAction: '/ProductModelList.aspx/ProductModelLists',
                updateAction: '/ProductModelList.aspx/UpdateProductModel',
                deleteAction: '/ProductModelList.aspx/DeleteProductModel'
            },
            fields: {
                productModelId: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                productName: {
                    title: 'Product Name',
                    width: '20%'
                },
                tradeName: {
                    title: 'Trade Name',
                    list: false
                },
                company: {
                    title: 'Company',
                    sorting: false,
                    width: '20%'
                },
                category: {
                    title: 'Category',
                    sorting: false,
                    width: '20%'
                },
                subCategory: {
                    title: 'Sub Category',
                    list: false
                },
                type: {
                    title: 'Type',
                    sorting: false,
                    width: '20%'
                },
                schedule: {
                    title: 'Schedule',
                    list: false
                },
                composition: {
                    title: 'Composition',
                    list: false,
                    type: 'textarea'
                },
                description: {
                    title: 'Description',
                    list: false,
                    type: 'textarea'
                },
                purpose: {
                    title: 'Purpose',
                    list: false,
                    type: 'textarea'
                },
                dosageInstruction: {
                    title: 'Dosage Instruction',
                    list: false,
                    type: 'textarea'
                },
                storageInstruction: {
                    title: 'Storage Instruction',
                    list: false,
                    type: 'textarea'
                },
                indications: {
                    title: 'Indications',
                    list: false,
                    type: 'textarea'
                },
                warning: {
                    title: 'Warning',
                    list: false,
                    type: 'textarea'
                },
                otherInformation: {
                    title: 'Other Information',
                    list: false,
                    type: 'textarea'
                },
                viewButton: {
                    width: '1%',
                    create: false,
                    edit: false,
                    sorting: false,
                    display: function (data) {
                        return '<a href="#" onclick="ViewDetailedProductModel(' + data.record.productModelId + ')"><i class="material-icons md-24">&#xE8F4;</i></a>';
                    }
                }
            }
        }).jtable('load', { productName: '' });

        // change buttons visual style in ui-dialog
        $('.ui-dialog-buttonset')
            .children('button')
            .attr('class', '')
            .addClass('md-btn md-btn-flat')
            .off('mouseenter focus');
        $('#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton').addClass('md-btn-flat-primary');

    }
};