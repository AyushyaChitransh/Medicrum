function Notification(value) {
    if (value === 's') {
        UIkit.notify({
            message: 'Successful',
            status: 'success',
            timeout: 1000,
            group: null,
            pos: 'top-center'
        });
    }
    else if (value === 'u') {
        UIkit.notify({
            message: 'Unsuccessful',
            status: 'danger',
            timeout: 3000,
            group: null,
            pos: 'top-center'
        });
    }
    else if (value === 'i') {
        UIkit.notify({
            message: 'Invalid Email or Password!',
            status: 'danger',
            timeout: 3000,
            group: null,
            pos: 'top-center'
        });
    }
}