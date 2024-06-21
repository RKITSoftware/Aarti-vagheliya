import { handleChange, handleContentReady, handleCopy,handleCut, handleDisposing, handleEnterKey, handleFocusIn, handleFocusOut, 
    handleInitialized, handleInput, handleKeyDown, handleKeyUp, handleOptionChanged, handlePaste, handleValueChanged } from './textboxEvent.js';

$(function(){

    $('#textbox').dxTextBox({
        accessKey : 'a',
        activeStateEnabled : true,
        placeholder: "Enter text",
        focusStateEnabled : true,
        hoverStateEnabled: true,
        hint : 'Enter text here..',
        showClearButton : true,
        inputAttr: { 'aria-label': 'Name' },
        mode : 'search' , // email' | 'password' | 'search' | 'tel' | 'text' | 'url'
        maxLength : 50,
        spellcheck : true,
        stylingMode : 'filled',// 'outlined' | 'underlined' | 'filled'
        onChange: handleChange,
        onContentReady: handleContentReady,
        onCopy: handleCopy,
        onCut: handleCut,
        onDisposing: handleDisposing,
        onEnterKey: handleEnterKey,
        onFocusIn: handleFocusIn,
        onFocusOut: handleFocusOut,
        onInitialized: handleInitialized,
        onInput: handleInput,
        onKeyDown: handleKeyDown,
        onKeyUp: handleKeyUp,
        onOptionChanged: handleOptionChanged,
        onPaste: handlePaste,
        onValueChanged: handleValueChanged,
    });


    $('#disable').dxTextBox({
        disabled : true,
        value : 'Hiii RKITians...',
        readOnly : true,
        

    });

    $('#mask').dxTextBox({
        placeholder : 'Enter number..',
        name : 'textBox',
         // Mask Options
         mask: "00000 LC", // 0,9,#,L,C,c,A,a  Example: A phone number mask -> 00000-00000   
         maskChar: "*", // Custom character for empty positions in the mask
         maskInvalidMessage: "Please enter a valid phone number (e.g., 12345-67890).", // Custom message for invalid input
         maskRules: { "X": /[02-9]/ }, // Custom rule (example: Only digits 0-9, excluding 1)
         showMaskMode : 'onFocus',// 'always' | 'onFocus'
         useMaskedValue : false,
         visible: true

    });

    const textBoxInstance = $("#textbox").dxTextBox("instance");

    // Method: beginUpdate
     $("#beginUpdateBtn").on("click", function() {
        textBoxInstance.beginUpdate();
        console.log("beginUpdate called");
    });

    // Method: blur
    $("#blurBtn").on("click", function() {
        textBoxInstance.blur();
        console.log("blur called");
    });

    // Method: defaultOptions
    $("#defaultOptionsBtn").on("click", function() {
        DevExpress.ui.dxTextBox.defaultOptions({
            options: {
                placeholder: "Default placeholder"
            }
        });
        console.log("defaultOptions set");
    });

    // Method: dispose
    $("#disposeBtn").on("click", function() {
        textBoxInstance.dispose();
        console.log("dispose called");
    });

    // Method: element
    $("#elementBtn").on("click", function() {
        const element = textBoxInstance.element();
        console.log("element:", element);
    });

    // Method: endUpdate
    $("#endUpdateBtn").on("click", function() {
        textBoxInstance.endUpdate();
        console.log("endUpdate called");
    });

    // Method: focus
    $("#focusBtn").on("click", function() {
        textBoxInstance.focus();
        console.log("focus called");
    });

    // Method: getButton
    $("#getButtonBtn").on("click", function() {
        const button = textBoxInstance.getButton("clear");
        console.log("getButton (clear):", button);
    });

    // Method: getInstance
    $("#getInstanceBtn").on("click", function() {
        const instance = DevExpress.ui.dxTextBox.getInstance(document.getElementById("textbox"));
        console.log("getInstance:", instance);
    });

    // Method: instance
    $("#instanceBtn").on("click", function() {
        const instance = textBoxInstance.instance();
        console.log("instance:", instance);
    });

    // Method: off (eventName)
    $("#offEventBtn").on("click", function() {
        textBoxInstance.off("focusIn");
        console.log("off (focusIn) called");
    });

    // Method: off (eventName, eventHandler)
    $("#offEventHandlerBtn").on("click", function() {
        function customHandler() {
            alert("Custom event handler");
        }
        textBoxInstance.on("customEvent", customHandler);
        textBoxInstance.off("customEvent", customHandler);
        console.log("off (customEvent, handler) called");
    });

    // Method: on (eventName, eventHandler)
    $("#onEventBtn").on("click", function() {
        textBoxInstance.on("focusIn", function() {
            console.log("on (focusIn) event triggered");
        });
        console.log("on (focusIn) handler added");
    });

    // Method: option
    $("#optionBtn").on("click", function() {
        const placeholder = textBoxInstance.option("placeholder");
        console.log("option (get placeholder):", placeholder);
    });

    // Method: option (optionName, optionValue)
    $("#setOptionBtn").on("click", function() {
        textBoxInstance.option("placeholder", "New placeholder");
        console.log("option (set placeholder) called");
    });

    // Method: option (options)
    $("#setOptionsBtn").on("click", function() {
        textBoxInstance.option({
            placeholder: "Updated placeholder",
            value: "Updated value"
        });
        console.log("option (set multiple options) called");
    });

    // Method: registerKeyHandler
    $("#registerKeyHandlerBtn").on("click", function() {
        textBoxInstance.registerKeyHandler("enter", function() {
            console.log("Enter key pressed");
        });
        console.log("registerKeyHandler (enter) called");
    });

    // Method: repaint
    $("#repaintBtn").on("click", function() {
        textBoxInstance.repaint();
        console.log("repaint called");
    });

    // Method: reset
    $("#resetBtn").on("click", function() {
        textBoxInstance.reset();
        console.log("reset called");
    });

    // Method: resetOption (optionName)
    $("#resetOptionBtn").on("click", function() {
        textBoxInstance.resetOption("value");
        console.log("resetOption (value) called");
    });
});