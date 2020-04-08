$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip({ delay: { "show": 200, "hide": 0 } });
    $('[data-toggle="popover"]').popover();
});


$(document).on('click', '.logger .dropdown-menu', function (e) {
    e.stopPropagation();
});

function GetButtonId(id) {
    return parseInt(this.id);
}
