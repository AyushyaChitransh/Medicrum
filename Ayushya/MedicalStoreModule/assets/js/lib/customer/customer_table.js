﻿function response() {
    $("#customer_list").jtable('load', {
        customerName: $('#search_customer').val()
    });
}

$(function () {
    // crud table
    altair_crud_table.init();
});

altair_crud_table = {
    init: function () {

        $('#customer_list').jtable({
            paging: true,
            pageSize: 10,
            sorting: true,
            defaultSorting: 'customerName ASC',
            deleteConfirmation: function (data) {
                data.deleteConfirmMessage = 'Are you sure to delete records of ' + data.record.customerName + '?';
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
                listAction: '/CustomerList.aspx/CustomerLists',
                updateAction: '/CustomerList.aspx/UpdateCustomer',
                deleteAction: '/CustomerList.aspx/DeleteCustomer'
            },
            fields: {
                customerId: {
                    key: true,
                    edit: false,
                    list: false
                },
                storeId: {
                    title: 'Store Id',
                    edit: false,
                    list: false
                },
                customerName: {
                    title: 'Customer Name',
                    width: '15%',
                    edit: true,
                    list: true
                },
                companyName: {
                    title: 'Company Name',
                    edit: true,
                    list: false
                },
                address: {
                    title: 'Address',
                    edit: true,
                    list: false
                },
                district: {
                    title: 'Cty',
                    edit: true,
                    sorting: false,
                    width: '15%'
                },
                state: {
                    title: 'State',
                    edit: true,
                    list: false
                },
                country: {
                    title: 'Country',
                    edit: true,
                    list: false
                },
                pincode: {
                    title: 'Pincode',
                    type: 'phone',
                    edit: true,
                    list: false
                },
                phoneNumber: {
                    title: 'Phone Number',
                    type: 'phone',
                    edit: true,
                    sorting: false,
                    width: '15%'
                },
                mobile: {
                    title: 'Mobile Number',
                    type: 'phone',
                    edit: true,
                    sorting: false,
                    width: '15%'
                },
                email: {
                    title: 'Email',
                    type: 'email',
                    edit: true,
                    sorting: false,
                    width: '15%'
                },
                dateOfBirth: {
                    title: 'Birth Date',
                    type: 'date',
                    displayFormat: 'dd-mm-yy',
                    edit: true,
                    list: false
                },
                height: {
                    title: 'Height',
                    type: 'phone',
                    edit: true,
                    list: false
                },
                weight: {
                    title: 'Weight',
                    edit: true,
                    list: false
                },
                bloodGroup: {
                    title: 'Blood Group',
                    edit: true,
                    list: false
                },
                status: {
                    create: false,
                    edit: false,
                    list: false
                },
                deleteStatus: {
                    create: false,
                    edit: false,
                    list: false
                },
                viewButton: {
                    width: '1%',
                    create: false,
                    edit: false,
                    sorting: false,
                    display: function (data) {
                        return '<a href="#" onclick="ViewDetailedCustomer(' + data.record.customerId + ')"><i class="material-icons md-24">&#xE8F4;</i></a>';
                    }
                }
            }
        }).jtable('load', { customerName: '' });

        // change buttons visual style in ui-dialog
        $('.ui-dialog-buttonset')
            .children('button')
            .attr('class', '')
            .addClass('md-btn md-btn-flat')
            .off('mouseenter focus');
        $('#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton').addClass('md-btn-flat-primary');
    }
};