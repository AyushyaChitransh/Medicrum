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
            defaultSorting: 'product_name ASC',
            deleteConfirmation: function (data) {
                data.deleteConfirmMessage = 'Are you sure to delete student ' + data.record.product_name + '?';
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
                listAction: '/ViewProduct.aspx/ProductList',
                updateAction: '/ViewProduct.aspx/UpdateProduct',
                deleteAction: '/ViewProduct.aspx/DeleteProduct'
            },
            fields: {
                product_model_id: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                product_name: {
                    title: 'Product Name',
                    width: '50%'
                },
                trade_name: {
                    title: 'trade_name',
                    list: false
                },
                company: {
                    title: 'company',
                    list: false
                },
                category: {
                    title: 'category',
                    list: false
                },
                sub_category: {
                    title: 'sub_category',
                    list: false
                },
                type: {
                    title: 'type',
                    list: false
                },
                schedule: {
                    title: 'schedule',
                    list: false
                },
                composition: {
                    title: 'composition',
                    list: false,
                    type: 'textarea'
                },
                description: {
                    title: 'description',
                    list: false,
                    type: 'textarea'
                },
                purpose: {
                    title: 'purpose',
                    list: false,
                    type: 'textarea'
                },
                dosage_instruction: {
                    title: 'dosage_instruction',
                    list: false,
                    type: 'textarea'
                },
                storage_instruction: {
                    title: 'storage_instruction',
                    list: false,
                    type: 'textarea'
                },
                indications: {
                    title: 'indications',
                    list: false,
                    type: 'textarea'
                },
                warning: {
                    title: 'warning',
                    list: false,
                    type: 'textarea'
                },
                other_information: {
                    title: 'other_information',
                    list: false,
                    type: 'textarea'
                },
                view_button: {
                    width: '1%',
                    create: false,
                    edit: false,
                    sorting: false,
                    display: function (data) {
                        return '<a href="#" onclick="ViewDetailedProduct(' + data.record.product_model_id + ')"><i class="material-icons md-24">&#xE8F4;</i></a>';
                    }
                }
            }
        });

        //Re-load records when user click 'load records' button.
        $('#search_button').click(function (e) {
            e.preventDefault();
            $('#product_list').jtable('load', {
                productName: $('#search_product').val()
            });
        });

        //Load all records when page is first shown
        $('#search_button').click();

        // change buttons visual style in ui-dialog
        $('.ui-dialog-buttonset')
            .children('button')
            .attr('class', '')
            .addClass('md-btn md-btn-flat')
            .off('mouseenter focus');
        $('#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton').addClass('md-btn-flat-primary');

    }
};