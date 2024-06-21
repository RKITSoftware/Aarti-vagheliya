import { handleOnChange, handleOnClosed, handleOnContentReady, handleOnCopy, handleOnCut,
    handleOnDisposing, handleOnEnterKey, handleOnFocusIn, handleOnFocusOut, handleOnInitialized, 
    handleOnInput, handleOnKeyDown, handleOnKeyUp, handleOnOpened, handleOnOptionChanged, 
    handleOnPaste, handleOnValueChanged } from "../Event.js";


$(() => {

    const now = new Date();
    const millisecondsInDay = 24 * 60 * 60 * 1000;

    $('#datebox').dxDateBox({
        type: "date",
        height: 50,
        width: 1200,
        max: "2025/12/31", //now,
        min: new Date(1960, 0, 5), // Date | Number | String
        value: now,  //"2025/12/31",
        displayFormat: "EEEE, d 'of' MMM", // "Tuesday, 16 of Oct" || shortdate || longdate
        useMaskBehavior: true,
        applyValueMode: "instantly", // "instantly" | "useButtons"
        pickerType: "Calendar",
        showClearButton: true,
        placeholder: "Tuesday, 16 of Oct",
        onValueChanged: function (e) {
            console.log(e.value);
            console.log(e.previousValue);
        },
        disabledDates: [
            new Date("06/5/2024"),
            new Date("06/6/2024"),
            new Date("06/7/2024")
        ]
    });



    $('#date').dxDateBox({
        pickerType: "rollers", // "Calendar -> date/datetime" , "rollers -> date/datetime/time" , "list -> time"
        type: "date",
        height: 50,
        width: 1200,
        displayFormat: 'shortdate',
        placeholder: '10/16/2018',
        deferRendering: false,
    });



    const dateEditor = $('#date1').dxDateBox({
        pickerType: "calendar",
        type: 'datetime',
        height: 50,
        width: 1200,
        max: "2024/6/15", //now,
        min: "2024/6/02",
        acceptCustomValue: true,
        accessKey: 'a',
        adaptivityEnabled: true,
        applyButtonText: 'done',
        value: new Date().getTime(),
        buttons: [{
            name: 'today',
            location: 'before',
            options: {
                text: 'Today',
                stylingMode: 'text',
                onClick() {
                    dateEditor.option('value', new Date().getTime());
                },
            },
        }, {
            name: 'prevDate',
            location: 'before',
            options: {
                icon: 'spinprev',
                stylingMode: 'text',
                onClick() {
                    const currentDate = dateEditor.option('value');
                    dateEditor.option('value', currentDate - millisecondsInDay);
                },
            },
        },
        {
            name: 'nextDate',
            location: 'after',
            options: {
                icon: 'spinnext',
                stylingMode: 'text',
                onClick() {
                    const currentDate = dateEditor.option('value');
                    dateEditor.option('value', currentDate + millisecondsInDay);
                },
            },
        }, 'dropDown'],
        cancelButtonText: 'Remove',
        dateOutOfRangeMessage: 'Date is out of range',
        acceptCustomValue : true,
        //dateSerializationFormat : "yyyy-MM-ddTHH:mm:ss"
        invalidDateMessage: 'value must be date or time',
        maxLength: 10,
        onChange:function (e) {
            handleOnChange(e);
        },
        onClosed: handleOnClosed,
        onContentReady: handleOnContentReady,
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


    }).dxDateBox('instance');



    $('#disable').dxDateBox({
        type: 'datetime',
        name: 'disable',
        height: 50,
        width: 1200,
        disabled: true,
        value: now,
        inputAttr: { 'aria-label': 'Disabled' },
    });



    const dateBoxInstance = $('#date2').dxDateBox({
        height: 50,
        width: 1200,
        pickerType: "list",
        type: 'time',
        interval: 60,
        placeholder: "select time",
    }).dxDateBox("instance");


    // Functions to handle the DateBox methods
    window.triggerMethod = function(method, param) {
        switch(method) {
            case 'beginUpdate':
                dateBoxInstance.beginUpdate();
                alert('beginUpdate called');
                break;
            case 'blur':
                dateBoxInstance.blur();
                alert('blur called');
                break;
            case 'close':
                dateBoxInstance.close();
                alert('close called');
                break;
            case 'content':
                let content = dateBoxInstance.content();
                alert('content retrieved');
                console.log('content:', content);
                break;
            case 'dispose':
                dateBoxInstance.dispose();
                alert('dispose called');
                break;
            case 'element':
                let element = dateBoxInstance.element();
                alert('element retrieved');
                console.log('element:', element);
                break;
            case 'endUpdate':
                dateBoxInstance.endUpdate();
                alert('endUpdate called');
                break;
            case 'field':
                let field = dateBoxInstance.field();
                alert('field retrieved');
                console.log('field:', field);
                break;
            case 'focus':
                dateBoxInstance.focus();
                alert('focus called');
                break;
            case 'getButton':
                let button = dateBoxInstance.getButton(param);
                alert(`getButton called for: ${param}`);
                console.log('button:', button);
                break;
            case 'instance':
                let instance = dateBoxInstance.instance();
                alert('instance retrieved');
                console.log('instance:', instance);
                break;
            case 'open':
                dateBoxInstance.open();
                alert('open called');
                break;
            case 'option':
                let options = dateBoxInstance.option();
                alert('option retrieved');
                console.log('options:', options);
                break;
            case 'repaint':
                dateBoxInstance.repaint();
                alert('repaint called');
                break;
            case 'reset':
                dateBoxInstance.reset();
                alert('reset called');
                break;
            case 'resetOption':
                dateBoxInstance.resetOption(param);
                alert(`resetOption called for: ${param}`);
                break;
            default:
                alert('Method not implemented');
        }
    }

     // Trigger repaint after 1 minut as an example
     setTimeout(function() {
        dateBoxInstance.repaint();
        alert("Repaint method called after 1 minut.");
    }, 60000);
});