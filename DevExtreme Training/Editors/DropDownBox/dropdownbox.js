import fruitList from './items.js';

import {
    handleOnChange, handleOnClosed, handleOnCopy, handleOnCut,
    handleOnDisposing, handleOnEnterKey, handleOnFocusIn, handleOnFocusOut, handleOnInitialized,
    handleOnInput, handleOnKeyDown, handleOnKeyUp, handleOnOpened, handleOnOptionChanged,
    handleOnPaste, handleOnValueChanged
} from "../Event.js";

$(function () {

    $('#dropdown').dxDropDownBox({
        items: fruitList,  // Use the imported fruit list
        value: fruitList[0],  // Default selected value
        placeholder: "Select a fruit",
        acceptCustomValue: true,
        showClearButton: true,
        openOnFieldClick: true,
        stylingMode: 'filled', // 'outlined' | 'underlined' | 'filled'
        hint: 'Select fruit',
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                dataSource: e.component.option("items"),
                selectionMode: "single",
                showSelectionControls: true,
                searchEditorOptions: function () {
                    return new $("div").dxTextBox({
                        showClearButton: true,
                        searchMode: 'contains', //'contains' | 'startswith' | 'equals'
                        inputAttr: { 'aria-label': 'Search' },
                    })
                },
                searchExpr: "",
                searchTimeout: 500,
                searchEnabled: true,
                onSelectionChanged: function (arg) {
                    e.component.option("value", arg.addedItems[0]);
                    e.component.close();
                }
            });
            return $list;
        },
        onChange: handleOnChange,
        onClosed: handleOnClosed,
        onCopy: handleOnCopy,
        onCut: handleOnCut,
        onDisposing: handleOnDisposing,
        onEnterKey: handleOnEnterKey,
        onFocusIn: handleOnFocusIn,
        onFocusOut: handleOnFocusOut,
        onInitialized: handleOnInitialized,
        onInput: handleOnInput,
        onKeyDown: handleOnKeyDown,
        onKeyUp: handleOnKeyUp,
        onOpened: handleOnOpened,
        onOptionChanged: handleOnOptionChanged,
        onPaste: handleOnPaste,
        onValueChanged: handleOnValueChanged,

    });

    // Fetch JSON data and initialize the DropDownBox
    $.getJSON("product.json")
        .done(function (data) {
            console.log("JSON data loaded successfully", data);
            initializeDropDown(data);
        })
        .fail(function (textStatus, error) {
            console.error("Failed to load JSON data: ", textStatus, error);
        });

//  var multipleSelectionDropDown = $('#multipledropdown').dxDropDownBox('instance');

    // Function to initialize the DropDownBox after fetching JSON
    function initializeDropDown(data) {
        const multipleSelectionDropDown = $("#multipledropdown").dxDropDownBox({
            placeholder: "Select a product",
            valueExpr: "id",
            hint: 'Select multiple Products',
            contentTemplate: function (e) {
                var $list = $("<div>").dxList({
                    dataSource: data,
                    displayExpr: "name",
                    selectionMode: "multiple",
                    selectByClick: true,
                    showSelectionControls: true,
                    onSelectionChanged: function (args) {
                        let arr = args.component.option('selectedItems').map(val => val.name);
                        e.component.option("value", arr);
                        console.log(e.component.option("value"));

                    },

                });
                return $list;
            },
            acceptCustomValue: true,
            showClearButton: true,
            displayValueFormatter: function (value) {
                return value.join(", ");
            },
            onValueChanged() {
                setTimeout(() => {
                    console.log("beginUpdate : ", multipleSelectionDropDown.beginUpdate());
                    console.log(multipleSelectionDropDown.getButton('clear'));
                    console.log("Element : ", multipleSelectionDropDown.element());
                    console.log("Content : ", multipleSelectionDropDown.content());
                    console.log("Field : ", multipleSelectionDropDown.field());
                    console.log("datasource : ", multipleSelectionDropDown.getDataSource());
                    setTimeout(()=>{
                        console.log("Blur : ", multipleSelectionDropDown.blur());
                        console.log( "Dispose : ", multipleSelectionDropDown.dispose());
                        setTimeout(()=>{
                            multipleSelectionDropDown.reset();
                            console.log("repaint", multipleSelectionDropDown.repaint());
                            console.log("endUpdate : ", multipleSelectionDropDown.endUpdate());
                        }, 1000)
                    }, 2000)
                }, 5000);
            }
        }).dxDropDownBox('instance');

        
    } 

});


// itemTemplate: function(item) {
//     // Create a container for each item
//     const $item = $("<div>").addClass("product-item");

//     // Append product details
//     $item.append($("<div>").addClass("product-name").text(`Name: ${item.name}`));
//     $item.append($("<div>").addClass("product-description").text(`Description: ${item.description}`));
//     $item.append($("<div>").addClass("product-price").text(`Price: $${item.price.toFixed(2)}`));
//     $item.append($("<div>").addClass("product-category").text(`Category: ${item.category}`));
//     $item.append($("<div>").addClass("product-stock").text(`Stock: ${item.stock}`));
//     $item.append($("<div>").addClass("product-rating").text(`Rating: ${item.rating}`));

//     return $item;
// },