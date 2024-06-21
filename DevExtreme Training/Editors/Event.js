
// Event Handlers for the DevExtreme 

function handleOnChange(e) {
    alert(`onChange event triggered. Value: ${e.value}`);
}

function handleOnClosed(e) {
    alert("onClosed event triggered.");
}

function handleOnContentReady(e) {
    alert("onContentReady event triggered.");
}

function handleOnCopy(e) {
    alert("onCopy event triggered.");
}

function handleOnCut(e) {
    alert("onCut event triggered.");
}

function handleOnDisposing(e) {
    alert("onDisposing event triggered.");
}

function handleOnEnterKey(e) {
    alert("onEnterKey event triggered.");
}

function handleOnFocusIn(e) {
    console.log("onFocusIn event triggered.");
   // alert("onFocusIn event triggered.");
}

function handleOnFocusOut(e) {
    console.log("onFocusOut event triggered.");
   // alert("onFocusOut event triggered.");
}

function handleOnInitialized(e) {
    alert("onInitialized event triggered.");
}

function handleOnInput(e) {
    alert("onInput event triggered.");
}

function handleOnKeyDown(e) {
    alert("onKeyDown event triggered.");
}

function handleOnKeyUp(e) {
    alert("onKeyUp event triggered.");
}

function handleOnOpened(e) {
    alert("onOpened event triggered.");
}

function handleOnOptionChanged(e) {
    console.log(`onOptionChanged event triggered. Option: ${e.name}, Value: ${e.value}`);
    //alert(`onOptionChanged event triggered. Option: ${e.name}, Value: ${e.value}`);
}

function handleOnPaste(e) {
    alert("onPaste event triggered.");
}

function handleOnValueChanged(e) {
    alert(`onValueChanged event triggered. New value: ${e.value}`);
}


export { handleOnChange, handleOnClosed, handleOnContentReady, handleOnCopy, handleOnCut,
         handleOnDisposing, handleOnEnterKey, handleOnFocusIn, handleOnFocusOut, handleOnInitialized, handleOnInput,
         handleOnKeyDown, handleOnKeyUp, handleOnOpened, handleOnOptionChanged, handleOnPaste, handleOnValueChanged}


// // Function to handle onChange event
// function handleChange(e) {
//     alert(`onChange: Value changed to ${e.value}`);
// }

// // Function to handle onClosed event
// function handleClosed(e) {
//     alert('onClosed: Dropdown closed');
// }

// // Function to handle onContentReady event
// function handleContentReady(e) {
//     alert('onContentReady: Content is ready');
// }

// // Function to handle onCopy event
// function handleCopy(e) {
//     alert('onCopy: Content copied');
// }

// // Function to handle onCut event
// function handleCut(e) {
//     alert('onCut: Content cut');
// }

// // Function to handle onDisposing event
// function handleDisposing(e) {
//     alert('onDisposing: Widget is being disposed');
// }

// // Function to handle onEnterKey event
// function handleEnterKey(e) {
//     alert('onEnterKey: Enter key pressed');
// }

// // Function to handle onFocusIn event
// function handleFocusIn(e) {
//     alert('onFocusIn: Input received focus');
// }

// // Function to handle onFocusOut event
// function handleFocusOut(e) {
//     alert('onFocusOut: Input lost focus');
// }

// // Function to handle onInitialized event
// function handleInitialized(e) {
//     alert('onInitialized: Widget has been initialized');
// }

// // Function to handle onInput event
// function handleInput(e) {
//     alert(`onInput: User input detected, current value is ${e.event.target.value}`);
// }

// // Function to handle onKeyDown event
// function handleKeyDown(e) {
//     alert(`onKeyDown: Key down event, key: ${e.event.key}`);
// }

// // Function to handle onKeyUp event
// function handleKeyUp(e) {
//     alert(`onKeyUp: Key up event, key: ${e.event.key}`);
// }

// // Function to handle onOpened event
// function handleOpened(e) {
//     alert('onOpened: Dropdown opened');
// }

// // Function to handle onOptionChanged event
// function handleOptionChanged(e) {
//     alert(`onOptionChanged: Option '${e.name}' changed to ${e.value}`);
// }

// // Function to handle onPaste event
// function handlePaste(e) {
//     alert('onPaste: Content pasted');
// }

// // Function to handle onValueChanged event
// function handleValueChanged(e) {
//     alert(`onValueChanged: Value changed from ${e.previousValue} to ${e.value}`);
// }



// //     onChange: handleChange,
// //     onClosed: handleClosed,
// //     onContentReady: handleContentReady,
// //     onCopy: handleCopy,
// //     onCut: handleCut,
// //     onDisposing: handleDisposing,
// //     onEnterKey: handleEnterKey,
// //     onFocusIn: handleFocusIn,
// //     onFocusOut: handleFocusOut,
// //     onInitialized: handleInitialized,
// //     onInput: handleInput,
// //     onKeyDown: handleKeyDown,
// //     onKeyUp: handleKeyUp,
// //     onOpened: handleOpened,
// //     onOptionChanged: handleOptionChanged,
// //     onPaste: handlePaste,
// //     onValueChanged: handleValueChanged


// function handleChange(e) {
//     console.log("change event triggered:", e);
// }

// function handleContentReady(e) {
//     console.log("contentReady event triggered:", e);
// }

// function handleCopy(e) {
//     console.log("copy event triggered:", e);
// }

// function handleCut(e) {
//     console.log("cut event triggered:", e);
// }

// function handleDisposing(e) {
//     console.log("disposing event triggered:", e);
// }

// function handleEnterKey(e) {
//     console.log("enterKey event triggered:", e);
// }

// function handleFocusIn(e) {
//     console.log("focusIn event triggered:", e);
// }

// function handleFocusOut(e) {
//     console.log("focusOut event triggered:", e);
// }

// function handleInitialized(e) {
//     console.log("initialized event triggered:", e);
// }

// function handleInput(e) {
//     console.log("input event triggered:", e);
// }

// function handleKeyDown(e) {
//     console.log("keyDown event triggered:", e);
// }

// function handleKeyUp(e) {
//     console.log("keyUp event triggered:", e);
// }

// function handleOptionChanged(e) {
//     console.log("optionChanged event triggered:", e);
// }

// function handlePaste(e) {
//     console.log("paste event triggered:", e);
// }

// function handleValueChanged(e) {
//     console.log("valueChanged event triggered:", e);
// }


// export{ handleChange, handleContentReady, handleCopy,handleCut, handleDisposing, handleEnterKey, handleFocusIn, handleFocusOut, 
//         handleInitialized, handleInput, handleKeyDown, handleKeyUp, handleOptionChanged, handlePaste, handleValueChanged }