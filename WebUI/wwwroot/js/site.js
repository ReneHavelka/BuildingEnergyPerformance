// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function spaceTemperature(value) {
    document.getElementById('SpaceTemperature').value = value;
}


$("select").change(function () {
    var selectorDependencies = ["layers", "spaces", "storeys"];
    var firstOptions = ["-- Vrstvy --", "-- Priestory --", "-- Poschodia --"];

    var selectedValue = $('option:selected', this).val();
    var elementId = $(this).attr("id");
    var nextElementIdx = selectorDependencies.indexOf(elementId) - 1;
    var selectedCategory = selectorDependencies[nextElementIdx];

    if (selectedValue != "") {

        $.ajax({
            type: "GET",
            dataType: "JSON",
            url: "?handler=Collection",
            data: { selectedCategory: selectedCategory, selectedValue: selectedValue },
            success: function (response) {
                addOptions(response);
            },
            failure: function () { },
            error: function () { }
        });
        document.getElementById(selectedCategory).disabled = false;
    }
    else {
        addOptions(null);
        document.getElementById(selectedCategory).disabled = true;
    }

    async function addOptions(response) {
        var firstOption = firstOptions[nextElementIdx];
        await $("#" + selectedCategory).empty();
        await $('<option value="">' + firstOption + '</option>').appendTo("#" + selectedCategory);
        $.each(response, function (i, v) {
            $('<option value="' + v.id + '">' + v.name + '</option>').appendTo("#" + selectedCategory);
        });
    }

});


function realNumberValidation(el) {
    if (typeof el.oldValue == 'undefined') {
        el.oldValue = null;
    }
    if (!isNaN(el.value)) {
        el.oldValue = el.value;
    }
    else {
        el.value = el.oldValue;
    }
}
