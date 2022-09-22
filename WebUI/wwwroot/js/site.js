// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function spaceTemperature(value) {
    document.getElementById('SpaceTemperature').value = value;
}


function getCollection(categoryNo, selectedValue) {
    var categoryArray = ["storeys", "spaces", "name", "mainBuildingElements", "area", "thermalResistances", "contiguousSpaces"];
    var selectedCategory = categoryArray[categoryNo];
    var selectedOption = document.getElementById(categoryArray[categoryNo - 1]).selectedIndex;

    if (selectedCategory == "name") {
        document.getElementById(selectedCategory).disabled = false;
        categoryNo++;
        selectedCategory = categoryArray[categoryNo];
    }

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

    var firstOptions = ["", "-- Priestory --", "", "-- Stena a pod. --", "", "-- Tepelný odpor --", "-- Vonkajší priestor --"];

    async function addOptions(response) {
        var firstOption = firstOptions[categoryNo];
        await $("#" + selectedCategory).empty();
        await $('<option value="">' + firstOption + '</option>').appendTo("#" + selectedCategory);
        $.each(response, function (i, v) {
            $('<option value="' + v.id + '">' + v.name + '</option>').appendTo("#" + selectedCategory);
        });

        if (selectedOption != 0) { document.getElementById(selectedCategory).disabled = false; }
        else {
            document.getElementById(selectedCategory).disabled = true;
            categoryNo--;
            if (selectedCategory == "mainBuildingElements") { categoryNo--; }
        }

        for (var i = categoryNo + 1; i < categoryArray.length; i++) {
            var elementId = categoryArray[i];
            var firstOption = firstOptions[i];
            var tag_Name = $("#" + elementId)[0].tagName;
            if (tag_Name == "INPUT") {
                $("#" + elementId).val("");
            }
            else {
                await $("#" + elementId).empty();
                $('<option value="">' + firstOption + '</option>').appendTo("#" + elementId);
            }
            document.getElementById(elementId).disabled = true;
        }
    }
}
