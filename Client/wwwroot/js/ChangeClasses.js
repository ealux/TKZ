$(document).ready(function () {
    $('html').on('click', '#Ch', function () {
        $("select").removeClass("custom-select").addClass("choose-grid transparent")
        $("input").removeClass("custom-control-input").addClass("checkbox__input")
        $("label").removeClass("custom-control-label").addClass("checkbox__label")

    });
});