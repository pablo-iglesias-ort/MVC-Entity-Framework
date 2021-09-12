function alternarBoton() {
    var submitButtons = document.getElementsByClassName('btn-parpadeo');
    if (submitButtons != null && submitButtons.length > 0) {
        setInterval(function () {
            //var submitButtons = document.getElementsByClassName('btn-parpadeo');
            if (submitButtons != null && submitButtons.length > 0) {
                if (submitButtons[0].classList.contains('btn-danger')) {
                    submitButtons[0].classList.replace('btn-danger', 'btn-light');
                } else {
                    if (submitButtons[0].classList.contains('btn-light')) {
                        submitButtons[0].classList.replace('btn-light', 'btn-danger');
                    }
                }
            }
        }, 400);
    }    
}

if (document.readyState == 'complete') {
    alternarBoton();
} else {
    document.onreadystatechange = function () {
        if (document.readyState == 'complete') {
            alternarBoton();
        }
    }
}