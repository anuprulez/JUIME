$(function () {
    // creates accordion control
    $("div[data-control-type='accordion']").each(function () {
        //gets the attributes
        var attributes = $(this).data('control-options');
        //creates accordion
        $(this).accordion(attributes);
    });

    // creates datepicker control
    $("input[data-control-type='datepicker']").each(function () {
        //gets the attributes
        var attributes = $(this).data('control-options');
        //creates datepicker
        $(this).datepicker(attributes);
    });

    // creates autocomplete control
    $("input[data-control-type='autocomplete']").each(function () {
        //gets the attributes
        var optionAttributes = $(this).data('control-options');
        var bindAttributes = $(this).data('control-bind-source');

        if (optionAttributes && bindAttributes) {
            if (optionAttributes.length > 2) {
                bindAttributes = bindAttributes.slice(0, bindAttributes.length - 1) + ',' + optionAttributes.slice(1, optionAttributes.length);
            }
        }
        //creates autocomplete
        $(this).autocomplete(bindAttributes);
    });

    // creates tab control
    $("div[data-control-type='tab']").each(function () {
        //gets the attributes
        var attributes = $(this).data('control-options');
        //creates tabs
        $(this).tabs(attributes);
    });
});