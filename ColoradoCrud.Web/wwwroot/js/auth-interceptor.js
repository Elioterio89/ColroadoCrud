$(document).ajaxSend(function (event, xhr, settings) {
    var token = localStorage.getItem('jwt');
    if (token) {
        xhr.setRequestHeader('Authorization', 'Bearer ' + token);
    }
});