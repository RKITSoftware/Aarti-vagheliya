$(() => {

    const simpleButton = $("#simpleButton").dxButton({
        text: 'Click me!',
        type: "success", //'back' | 'danger' | 'default' | 'normal' | 'success'
        icon: "comment",
        hint : 'click on me..!!',
        hoverStateEnabled : true,
        stylingMode : 'outlined', //  'text' | 'outlined' | 'contained'
        useSubmitBehavior : true,
        onClick: function() {
            DevExpress.ui.notify("The button was clicked");
            appendToDisplayData("Button Clicked: " + new Date().toLocaleTimeString());
        },
        onContentReady: function(e) {
            appendToDisplayData("Content is ready for button: " + e.component.option('text'));
        },
        onDisposing: function(e) {
            appendToDisplayData("Button is being disposed: " + e.component.option('text'));
        },
        onInitialized: function(e) {
            appendToDisplayData("Button initialized with text: " + e.component.option('text'));
        },
        onOptionChanged: function(e) {
            appendToDisplayData("Option changed - " + e.name + ": " + e.value);
        }
    }).dxButton('instance');

    // Function to append data to the displayData div
    function appendToDisplayData(message) {
        const displayDiv = $("#displayData");
        displayDiv.append(`<p>${message}</p>`);
    }


    setTimeout(() => {
        // Begin update - useful when setting multiple options at once
        simpleButton.beginUpdate();
        appendToDisplayData("Begin Update - Changing stylingMode to 'contained'");
        simpleButton.option("stylingMode", "contained");

        // Revert stylingMode back after a timeout
        setTimeout(() => {
            simpleButton.option("stylingMode", "text");
            appendToDisplayData("Reverted stylingMode back to 'contained' after 5 seconds");
            simpleButton.endUpdate();
        }, 5000);
    }, 3000); // Starts 3 seconds after the page load

    setTimeout(() => {
       
        // Change the text of the button
        simpleButton.option("text", "Updated Text");
        appendToDisplayData("Button text updated to 'Updated Text'");

        // Focus the button
        simpleButton.focus();
        appendToDisplayData("Button focused");

        // Dispose the button after 5 seconds
        setTimeout(() => {
            appendToDisplayData("Button will be disposed in 2 seconds...");
            setTimeout(() => {
                simpleButton.dispose();
                appendToDisplayData("Button disposed.");
                setTimeout(() => {
                    simpleButton.repaint();
                    appendToDisplayData("Button repaint.");
                },2000);
            }, 2000);
        }, 5000);
    }, 5000);


    $("#disabledButton").dxButton({
        text: 'don\'t Click me!',
        type: "danger",
        stylingMode: "contained",
        icon: "remove",
        disabled : true
    });
});