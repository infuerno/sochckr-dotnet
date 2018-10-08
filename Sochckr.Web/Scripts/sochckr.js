$(function () {

    function submitAutocompleteForm(event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        $form.submit();
    }

    function createAutocomplete() {
        var $input = $(this);
        var options = {
            source: $input.attr("data-sochckr-autocomplete"),
            select: submitAutocompleteForm
        };
        $input.autocomplete(options);
    }

    $("input[data-sochckr-autocomplete]").each(createAutocomplete);

});


function pulsate(result) {


}

