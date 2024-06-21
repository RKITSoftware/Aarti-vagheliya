import {
    handleOnChange, handleOnClosed, handleOnCopy, handleOnCut,
    handleOnEnterKey, handleOnFocusIn, handleOnFocusOut, handleOnInitialized,
    handleOnInput, handleOnKeyDown, handleOnKeyUp, handleOnOpened, handleOnOptionChanged,
    handleOnPaste, handleOnValueChanged
} from "../Event.js";


$(function () {

    const data = [{
        ID: 1,
        Name: 'Banana',
        Category: 'Fruits'
    }, {
        ID: 2,
        Name: 'Cucumber',
        Category: 'Vegetables'
    }, {
        ID: 3,
        Name: 'Apple',
        Category: 'Fruits'
    }, {
        ID: 4,
        Name: 'Tomato',
        Category: 'Vegetables'
    }, {
        ID: 5,
        Name: 'Apricot',
        Category: 'Fruits'
    }]

    const preGroupedData = [{
        Category: 'Fruits',
        Products: [{
            ID: 1,
            Name: 'Banana',
        }, {
            ID: 3,
            Name: 'Apple',
        }, {
            ID: 5,
            Name: 'Apricot',
        }],
    }, {
        Category: 'Vegetables',
        Products: [{
            ID: 2,
            Name: 'Cucumber',
        }, {
            ID: 4,
            Name: 'Tomato',
        }],
    }];

    const fromUngroupedData = new DevExpress.data.DataSource({
        store: {
            type: 'array',
            data: data,
            key: 'ID',
        },
        group: 'Category',
    });

    const fromPregroupedData = new DevExpress.data.DataSource({
        store: {
            type: 'array',
            data: preGroupedData,
            key: 'ID',
        },
        map(item) {
            item.key = item.Category;
            item.items = item.Products;
            return item;
        },
    });

    fromPregroupedData.load();

    const selectBox = $("#selectBox").dxSelectBox({
        dataSource: {
            store: data,
            paginate: true,
            pageSize: 1,
        },
        valueExpr: "ID",
        displayExpr: "Name",
        searchEnabled: true,
        searchExpr: 'Name',
        searchMode: 'startswith', // 'contains' | 'startswith'
        searchTimeout: 1000,
        minSearchLength: 1,
        acceptCustomValue : true,
        deferRendering :true,
        disabled : false,
        openOnFieldClick : true,
        showClearButton : true,
        showDataBeforeSearch : true,
        showSelectionControls : false,
        useItemTextAsTitle : true,
        wrapItemText : true,
        // displayValue(){
        //     console.log("dispalyValue",value);
        //     return value;
        // },
        dropDownButtonTemplate() {
            return $('<img>', {
            alt: 'Custom icon',
            src: './download.png',
            class: 'custom-icon',
            css: {
                height: '30px', // Set the desired height
                width: '30px'   // Set the desired width
            }
            });
        },
        // onCustomItemCreating(data) {
        //     if (!data.text) {
        //       data.customItem = null;
        //       return;
        //     }
        //     const productIds = data.map((item) => item.ID);
        //     const incrementedId = Math.max.apply(null, productIds) + 1;
        //     const newItem = {
        //       Name: data.text,
        //       ID: incrementedId,
        //     };
        //     data.customItem = fromUngroupedData.store().insert(newItem)
        //       .then(() => fromUngroupedData.load())
        //       .then(() => newItem)
        //       .catch((error) => {
        //         throw error;
        //       });
        //   },
        dropDownOptions: {
            height: 200
        },
        onItemClick(){
            console.log("item clicked.");
        },
        onSelectionChanged(){
            console.log("selection changed.");
        },
        //valueChangeEvent: 'keyup',

        onValueChanged: function (e) {
            console.log(e.value);
            console.log(e.previousValue);
        },
        onChange: handleOnChange,
        onClosed: handleOnClosed,
        onCopy: handleOnCopy,
        onCut: handleOnCut,
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

    }).dxSelectBox("instance");

    selectBox.registerKeyHandler("backspace", function(e) {
        console.log("backspace.");
    });

    const unGroupedData = $('#unGroup').dxSelectBox({
        dataSource: fromUngroupedData,
        inputAttr: { 'aria-label': 'Data' },
        valueExpr: 'ID',
        grouped: true,
        displayExpr: 'Name',
        value: 1,
        showDropDownButton : false,
        showSelectionControls : true,
        onValueChanged() {
            setTimeout(() => {
                console.log("beginUpdate : ", unGroupedData.beginUpdate());
                console.log("Element : ", unGroupedData.element());
                console.log("Content : ", unGroupedData.content());
                console.log("Field : ", unGroupedData.field());
                console.log("datasource : ", unGroupedData.getDataSource());
                setTimeout(()=>{
                    console.log("Blur : ", unGroupedData.blur());
                    console.log( "Dispose : ", unGroupedData.dispose());
                    setTimeout(()=>{
                        unGroupedData.reset();
                        //unGroupedData.load();
                        console.log("repaint ", unGroupedData.repaint());
                        console.log("endUpdate : ", unGroupedData.endUpdate());
                    }, 3000)
                }, 2000)
            }, 5000);
        }
    
    }).dxSelectBox("instance");

    $('#preGroup').dxSelectBox({
        dataSource: fromPregroupedData,
        inputAttr: { 'aria-label': 'Pregrouped Data' },
        valueExpr: 'ID',
        grouped: true,
        groupTemplate(data) {
            return $(`<div class='custom-icon'><span class='dx-icon-box icon'></span> ${data.key}</div>`);
        },
        displayExpr: 'Name',
        value: 1,
    });
});
