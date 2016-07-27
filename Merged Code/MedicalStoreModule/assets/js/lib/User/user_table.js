function response() {
    $("#user_list").jtable('load', {
        userName: $('#search_user').val()
    });
}

$(function () {
    // crud table
    altair_crud_table.init();
});

altair_crud_table = {
    init: function () {

        $('#user_list').jtable({
            paging: true,
            pageSize: 10,
            sorting: true,
            defaultSorting: 'name ASC',
            deleteConfirmation: function (data) {
                data.deleteConfirmMessage = 'Are you sure to delete records of ' + data.record.userName + '?';
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
                            $this.parent('div.icheckbox_md').next('span').text('Suspended');
                        })
                        .on('ifUnchecked', function (event) {
                            $this.parent('div.icheckbox_md').next('span').text('Not Suspended');
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
                listAction: '/UserList.aspx/UserLists',
                updateAction: '/UserList.aspx/UpdateUser',
                deleteAction: '/UserList.aspx/DeleteUser'
            },
            fields: {
                name: {
                    title: 'Name',
                    width: '20%',
                    edit: true,
                    list: true
                },
                userName: {
                    key: true,
                    title: 'User Name',
                    width: '20%',
                    edit: false,
                    sorting: false,
                    list: true
                },
                role: {
                    title: 'Role',
                    edit: true,
                    list: false
                },
                storeId: {
                    title: 'Store Id',
                    edit: false,
                    list: false
                },
                password: {
                    title: 'Password',
                    edit: true,
                    list: false
                },
                email: {
                    title: 'Email',
                    type: 'email',
                    edit: true,
                    list: false
                },
                phoneNumber: {
                    title: 'Phone Number',
                    type: 'phone',
                    edit: true,
                    list: false
                },
                address: {
                    title: 'Address',
                    edit: true,
                    list: false
                },
                storeStatus: {
                    create: false,
                    edit: false,
                    list: false
                },
                status: {
                    title: 'Suspension',
                    width: '1%',
                    sorting: false,
                    options: { '0': '<span class="uk-badge uk-badge-danger">&nbsp&nbsp&nbsp&nbspSuspended&nbsp&nbsp&nbsp&nbsp</span>', '1': '<span class="uk-badge uk-badge-success">Not Suspended</span>' },

                },
                viewButton: {
                    width: '1%',
                    create: false,
                    edit: false,
                    sorting: false,
                    display: function (data) {
                        return '<a href="#" onclick="ViewDetailedUser(\'' + data.record.userName + '\')"><i class="material-icons md-24">&#xE8F4;</i></a>';
                    }
                }
            }
        }).jtable('load', { userName: '' });

        // change buttons visual style in ui-dialog
        $('.ui-dialog-buttonset')
            .children('button')
            .attr('class', '')
            .addClass('md-btn md-btn-flat')
            .off('mouseenter focus');
        $('#AddRecordDialogSaveButton,#EditDialogSaveButton,#DeleteDialogButton').addClass('md-btn-flat-primary');
    }
};