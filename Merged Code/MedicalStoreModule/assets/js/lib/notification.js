function Notification(value) {
    if (value == 's')
        UIkit.notify({
            message: 'Successful',
            status: 'success',
            timeout: 1000,
            group: null,
            pos: 'top-center'
        });
    else
        UIkit.notify({
            message: 'Unsuccessful',
            status: 'danger',
            timeout: 3000,
            group: null,
            pos: 'top-center'
        });
}