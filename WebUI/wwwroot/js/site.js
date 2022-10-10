// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#spaceTemperatures")
    .on('change', function () {
        $("#spaceTemperature").val(this.value);
    })
    .on('click', function () {
        $("#spaceTemperature").val(this.value);
    })
    .on('mouseout', function () {
        $("#spaceTemperature").focus();
    });


function addOptions(response, firstOption, nextCategory) {
    $("#" + nextCategory).empty();
    $('<option value="">' + firstOption + '</option>').appendTo("#" + nextCategory);
    $.each(response, function (i, v) {
        $('<option value="' + v.id + '">' + v.name + '</option>').appendTo("#" + nextCategory);
    });
}


function collection(nextCategory, selectedValue, firstOption) {
    if (selectedValue != "") {
        $.ajax({
            type: "GET",
            dataType: "JSON",
            url: "?handler=Collection",
            data: { nextCategory: nextCategory, selectedValue: selectedValue },
            success: function (response) {
                addOptions(response, firstOption, nextCategory);
            },
            failure: function () { },
            error: function () { }
        });
        document.getElementById(nextCategory).disabled = false;
    }
    else {
        addOptions(null, firstOption, nextCategory);
        document.getElementById(nextCategory).disabled = true;
    }
}


function getSpaceTemperature(listCategoryId, spaceValue) {
    if ($("#temperature").length > 0) {
        if (listCategoryId == "spaces" && spaceValue != "") {
            $.ajax({
                type: "GET",
                dataType: "JSON",
                url: "?handler=Temperature",
                data: { spaceValue: spaceValue },
                success: function (response) {
                    $("#temperature").html(response + " °C");
                },
                failure: function () { },
                error: function () { }
            });
        }
        if ($("#spaces").length > 0 && spaceValue == "") { $("#temperature").html(""); }
    }
}


function getBuildingElementArea(listCategoryId, buildingElementValue) {
    if ($("#buildingElementArea").length > 0) {
        if (listCategoryId == "buildingElements" && buildingElementValue != "") {
            $.ajax({
                type: "GET",
                dataType: "JSON",
                url: "?handler=BuildingElementArea",
                data: { buildingElementValue: buildingElementValue },
                success: function (response) {
                    $("#buildingElementArea").html(response + " m<sup>2</sup>");
                },
                failure: function () { },
                error: function () { }
            });
        }
        if ($("#buildingElementArea").length > 0 && spaceValue == "") { $("#buildingElementArea").html(""); }
    }
}


$("select").change(function () {
    var categories = ["layers", "buildingElements", "spaces", "storeys"];
    var firstOptions = ["-- Vrstvy --", "-- Stavebné konštrukcie --", "-- Priestory --", "-- Poschodia --"];

    var selectedValue = $('option:selected', this).val();
    var listCategoryId = $(this).attr("id");
    var nextCategoryId = categories.indexOf(listCategoryId) - 1;
    var nextCategory = categories[nextCategoryId];
    var firstOption = firstOptions[nextCategoryId];

    if ($("#" + nextCategory).length > 0) { collection(nextCategory, selectedValue, firstOption); }

    var spaceValue = document.getElementById('spaces').value;
    getSpaceTemperature(listCategoryId, spaceValue);

    if ($("#buildingElementArea").length > 0) {
        var buildingElementValue = document.getElementById('buildingElements').value;
        getBuildingElementArea(listCategoryId, buildingElementValue)
    }
});


function realNumberValidation(el) {
    el.value = el.value.replace(",", ".");
    if (typeof el.oldValue == 'undefined') {
        el.oldValue = null;
    }
    if (!isNaN(el.value)) {
        el.value = el.value.replace(".", ",");
        el.oldValue = el.value;
    }
    else {
        el.value = el.oldValue;
    }
}


$("select")
    .attr("required", function () {
        if (this.id == "spaceTemperatures") { return false }
        else { return true }
    })
    .on('invalid', function () {
        return this.setCustomValidity('Výber je povinný.');
    })
    .on('input', function () {
        return this.setCustomValidity('');
    });


$("input").attr("required",
    function () {
        if ($("#thermalResistance").val() != "" && this.id == "thickness") { return false }
        else if ($("#thermalResistance").val() != "" && this.id == "thermalConductivity") { return false }
        else if ($("#thermalConductivity").val() != "" && this.id == "thermalResistance") { return false }
        else { return true }
    });


$("input")
    .on('invalid', function () {
        if (this.id == "thickness") { return this.setCustomValidity('Aspoň jeden z údajov tep. vlastností je povinný.'); }
        else if (this.id == "spaceTemperature" && this.value != "") { return this.setCustomValidity(''); }
        else { return this.setCustomValidity('Toto pole je povinné.'); }
    })
    .on('input', function () {
        if (this.id == "thickness" && this.value != "") {
            $("#thermalConductivity").attr("required", true);
            $("#thermalResistance").val(null);
            $("#thermalResistance").attr("required", false);
        }
        if (this.id == "thermalConductivity" && this.value != "") {
            $("#thermalResistance").val(null);
            $("#thickness").attr("required", true);
        }
        if (this.id == "thermalResistance" && this.value != "") {
            $("#thickness").val(null);
            $("#thickness").attr("required", false);
            $("#thermalConductivity").val(null);
            $("#thermalConductivity").attr("required", false);
        }
        return this.setCustomValidity('');
    });
