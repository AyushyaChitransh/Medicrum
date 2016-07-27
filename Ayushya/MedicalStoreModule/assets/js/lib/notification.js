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
            message: 'Could not connect to server! Please try again',
            status: 'danger',
            timeout: 3000,
            group: null,
            pos: 'top-center'
        });
    }
    else if (value === 'e') {
        UIkit.notify({
            message: 'Could not insert data! Please verify data entered',
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