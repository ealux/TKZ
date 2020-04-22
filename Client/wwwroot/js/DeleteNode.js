$(document).ready(function () {
    $('html').on('click','.icon-delete', function () {                               
        $(this).parent().remove();    
    });
});