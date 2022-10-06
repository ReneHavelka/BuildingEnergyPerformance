// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function fSpaceTemperature(value) {
    $("#spaceTemperature").val(value);
    //document.getElementById('spaceTemperature').value = value;
    //document.getElementById('spaceTemperature').text = value;
}


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
    .attr("required", true)
    .on('invalid', function () {
        return this.setCustomValidity('Výber je povinný.');
    })
    .on('input', function () {
        return this.setCustomValidity('');
    });


$("input")
    .attr("required", true)
    .on('invalid', function () {
        return this.setCustomValidity('Toto pole je povinné.');
    })
    .on('input', function () {
        return this.setCustomValidity('');
    });

$("#spaceTemperatures").attr("required", false);


$("#thickness")
    .attr("required", true)
    .on('invalid', function () {
        //if ($("#thermalResistance").value != "") {
        //    await $("#thickness").removeAttr('required');
        //    await $("#thermalConductivity").removeAttr('required');
        //}
        return this.setCustomValidity('Aspoň jeden z údajov tep. vlastností je povinný.');
    })
    .on('input', function () {
        return this.setCustomValidity('');
    });


$("#thickness")
    .on('change', function () {
        if (this.value != "") {
            $("#thermalResistance").val(null);
            $("#thermalConductivity").attr("required", true);
            $("#thermalResistance").attr("required", false);
        }
        else {
            $("#thickness").attr("required", true);
            $("#thermalResistance").attr("required", true);
        }
    });


$("#thermalConductivity")
    .on('change', function () {
        if (this.value != "") {
            $("#thermalResistance").val(null);
            $("#thickness").attr("required", true);
        }
    });


$("#thermalResistance")
    .on('change', function () {
        if (this.value != "") {
            $("#thickness").val(null);
            $("#thermalConductivity").val(null);
            $("#thickness").attr("required", false);
            $("#thermalConductivity").attr("required", false);
        }
        else {
            $("#thickness").attr("required", true);
            $("#thermalConductivity").attr("required", true);
        }
    });