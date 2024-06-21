import { handleOnChange, handleOnClosed, handleOnContentReady, handleOnCopy, handleOnCut,
         handleOnDisposing, handleOnEnterKey, handleOnFocusIn, handleOnFocusOut, handleOnInitialized, handleOnInput,
         handleOnKeyDown, handleOnKeyUp, handleOnOpened, handleOnOptionChanged, handleOnPaste, handleOnValueChanged } from '../Event.js';

$(() => {

    const simpleTextArea =  $('#simpleTextArea').dxTextArea({
        value: "The text that should be edited",
        height: 50,
        width: 1500,
        autoResizeEnabled: false,
        minHeight: 100,
        maxHeight: 200,
       // maxLength: 100,
       accessKey : 'a',
       activeStateEnabled : true,
       focusStateEnabled : true,
       hint : 'Enter text here....',
       name : 'SimpleTextBox',
       placeholder : 'Enter Text',
       readOnly: false,
       spellcheck : true,
       stylingMode :  'filled', //'outlined' | 'underlined' | 'filled'
       buttons: [{
            name: "myCustomButton",
            location: "after",
            options: {
                onClick: function(e) {
                    alert("button clicked");
                },
                disabled: false
            }
        }],
        onOptionChanged: function(e) {
            if(e.name == "readOnly") {
                const myButton = e.component.getButton("myCustomButton");
                myButton.option("visible", !e.value); // Hide the button when readOnly: true
                
            }
        },
        onChange: handleOnChange,
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
        onOptionChanged: handleOnOptionChanged,
        onPaste: handleOnPaste,
        onValueChanged: handleOnValueChanged,

    }).dxTextArea('instance');

    // // Apply methods to the instance within a setTimeout function

    // Begin Update
    setTimeout(() => {
        console.log("Begin Update");
        simpleTextArea.beginUpdate();
        console.log("Value after beginUpdate:", simpleTextArea.option("value"));
    }, 1000);

    // Focus the TextArea
    setTimeout(() => {
        console.log("Focus the TextArea");
        simpleTextArea.focus();
        console.log("TextArea focused");
    }, 2000);

    // Blur the TextArea
    setTimeout(() => {
        console.log("Blur the TextArea");
        simpleTextArea.blur();
        console.log("TextArea blurred");
    }, 3000);

    // Get Button (Clear) Element
    setTimeout(() => {
        console.log("Get Button (Clear) Element");
        const clearButton = simpleTextArea.getButton("clear");
        console.log(clearButton ? clearButton : "No clear button exists or it's not configured.");
    }, 4000);

    // Off and On Event (focus)
    setTimeout(() => {
        console.log("Off 'focus' Event");
        simpleTextArea.off('focus');
        console.log("Focus event off");

        console.log("On 'focus' Event");
        simpleTextArea.on('focus', function() {
            console.log('TextArea focused');
        });
        console.log("Focus event on");
    }, 5000);

    

    // Reset Options
    setTimeout(() => {
        console.log("Reset Options");
        simpleTextArea.reset();
        console.log("Value after reset:", simpleTextArea.option("value"));
    }, 7000);

    // Register Key Handler
    setTimeout(() => {
        console.log("Register a Key Handler for Enter key");
        simpleTextArea.registerKeyHandler('enter', function() {
            console.log('Enter key pressed');
        });
        console.log("Key handler registered for Enter key");
    }, 8000);

    // Reset a Specific Option
    setTimeout(() => {
        console.log("Reset a Specific Option (placeholder)");
        simpleTextArea.resetOption('placeholder');
        console.log("Placeholder after resetOption:", simpleTextArea.option('placeholder'));
    }, 9000);

    // Get Element
    setTimeout(() => {
        console.log("Get Element");
        console.log(simpleTextArea.element());
    }, 10000);

    
    // Dispose TextArea
    setTimeout(() => {
        console.log("Dispose TextArea");
        simpleTextArea.dispose();
        console.log("TextArea disposed");
        }, 11000);
        
    // Repaint TextArea
    setTimeout(() => {
        console.log("Repaint TextArea");
        simpleTextArea.repaint();
            console.log("TextArea repainted");
    }, 13000);

    // End Update
    setTimeout(() => {
        console.log("End Update");
        simpleTextArea.endUpdate();
        console.log("End update completed");
    }, 13000);


    
    $('#disabledTextArea').dxTextArea({
        value: "The text that should not be edited",
        readOnly: true,
        disabled : true,
        stylingMode :  'outlined',
    });
});