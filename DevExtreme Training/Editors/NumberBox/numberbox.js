$(() => {
    var numberBoxInstance;

     $('#simpleNumberBox').dxNumberBox({
        value: 10,
        min: 0,
        max: 10000000,
        accessKey : 'a',
        stylingMode: "filled",
        placeholder : 'Number..',
        mode : 'tel',
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
        onValueChanged: handleValueChanged
    });

    setTimeout(() => {
        console.log("Disposing NumberBox after 10 seconds...");
        $("#simpleNumberBox").dxNumberBox("instance").dispose();
    }, 10000);

    

     // Fixed-point NumberBox configuration
     $("#fixedPoint").dxNumberBox({
        value: 1234.56, // Initial value
        format: "fixedPoint", // Fixed-point format
        placeholder: "Enter a number",
        label: "Fixed-Point",
        showSpinButtons: true,
        onValueChanged: function(e) {
            console.log(`Fixed-Point value changed to: ${e.value}`);
        }
    });

     // Decimal NumberBox configuration
     $("#decimal").dxNumberBox({
        value: 1234.56, // Initial value
        format: "#0.00", // Decimal format
        placeholder: "Enter a decimal number",
        label: "Decimal",
        showSpinButtons: true,
        onValueChanged: function(e) {
            console.log(`Decimal value changed to: ${e.value}`);
        }
    });

    // Percent NumberBox configuration
    $("#percent").dxNumberBox({
        value: 0.12, // Initial value
        format: "percent", // Percent format
        placeholder: "Enter a percentage",
        label: "Percent",
        showSpinButtons: true,
        onValueChanged: function(e) {
            console.log(`Percent value changed to: ${e.value}`);
        }
    });

    // Currency NumberBox configuration
    $("#currency").dxNumberBox({
        value: 1234.56, // Initial value
        format: "currency", // Currency format
        placeholder: "Enter an amount",
        label: "Currency",
        showSpinButtons: true,
        onValueChanged: function(e) {
            console.log(`Currency value changed to: ${e.value}`);
        }
    });

  

    // Function to handle onChange event
function handleChange(e) {
    console.log(`onChange: Value changed to ${e.value}`);
}

// Function to handle onContentReady event
function handleContentReady(e) {
    console.log('onContentReady: Content is ready');
}

// Function to handle onCopy event
function handleCopy(e) {
    console.log('onCopy: Content copied');
}

// Function to handle onCut event
function handleCut(e) {
    console.log('onCut: Content cut');
}

// Function to handle onDisposing event
function handleDisposing(e) {
    console.log('onDisposing: Widget is being disposed');
}

// Function to handle onEnterKey event
function handleEnterKey(e) {
    console.log('onEnterKey: Enter key pressed');
}

// Function to handle onFocusIn event
function handleFocusIn(e) {
    console.log('onFocusIn: Input received focus');
}

// Function to handle onFocusOut event
function handleFocusOut(e) {
    console.log('onFocusOut: Input lost focus');
}

// Function to handle onInitialized event
function handleInitialized(e) {
    console.log('onInitialized: Widget has been initialized');
}

// Function to handle onInput event
function handleInput(e) {
    console.log(`onInput: User input detected, current value is ${e.event.target.value}`);
}

// Function to handle onKeyDown event
function handleKeyDown(e) {
    console.log(`onKeyDown: Key down event, key: ${e.event.key}`);
}

// Function to handle onKeyUp event
function handleKeyUp(e) {
    console.log(`onKeyUp: Key up event, key: ${e.event.key}`);
}

// Function to handle onOptionChanged event
function handleOptionChanged(e) {
    console.log(`onOptionChanged: Option '${e.name}' changed to ${e.value}`);
}

// Function to handle onPaste event
function handlePaste(e) {
    console.log('onPaste: Content pasted');
}

// Function to handle onValueChanged event
function handleValueChanged(e) {
    console.log(`onValueChanged: Value changed from ${e.previousValue} to ${e.value}`);
}




// setTimeout(() => {
//     console.log("Disposing NumberBox after 7 seconds...");
//     numberBoxInstance.dispose();

//     // Repaint the NumberBox after disposing
//     setTimeout(() => {
//         console.log("Recreating NumberBox...");
//         $("#simpleNumberBox").dxNumberBox("repaint");
//     }, 1000); // Delay for 1 second before repainting
// }, 7000);


});