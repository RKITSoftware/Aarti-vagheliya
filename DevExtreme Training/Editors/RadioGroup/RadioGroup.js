
$(() => {

    const dataItems = [
        { text: "Low", color: "grey" },
        { text: "Normal", color: "green" },
        { text: "Urgent", color: "yellow" },
        { text: "High", color: "red" }
    ];

    // $('#simpleRadioGroup').dxRadioGroup({
    //     dataSource: dataItems,
    //     displayExpr: "text",
    //     //valueExpr: "color",
    //     value: dataItems[1],
    //     layout: "horizontal" // or "vertical"
    // });



    const signals = ['Red', 'Green', 'Yellow'];
    let currentIndex = 0;

    // Update traffic light button styling based on the selected signal
    function updateTrafficLight(selectedSignal) {
        $("#red-light").dxButton("instance").option('type', selectedSignal === 'Red' ? 'danger' : 'default');
        $("#yellow-light").dxButton("instance").option('elementAttr', { style: selectedSignal === 'Yellow' ? 'background-color: #fcb603' : 'background-color: default' });
        $("#green-light").dxButton("instance").option('type', selectedSignal === 'Green' ? 'success' : 'default');
    }

    // Initialize the DevExtreme RadioGroup
    $('#signal-selector').dxRadioGroup({
        items: signals,
        value: signals[0], // Default selected value
        layout: 'horizontal', // Arrange buttons horizontally
        onValueChanged(e) {
            updateTrafficLight(e.value);
        },
        onContentReady() {
            // Change dot colors programmatically
            const signalSelector = $('.dx-radiobutton');
            signalSelector.each(function(index) {
                const dotElement = $(this).find('.dx-radiobutton-icon-dot');
                switch (index) {
                    case 0:
                        dotElement.css('background-color', '#fc0b03'); // Red
                        break;
                    case 1:
                        dotElement.css('background-color', '#179140'); // Green
                        break;
                    case 2:
                        dotElement.css('background-color', '#fcb603'); // Yellow
                        break;
                    default:
                        break;
                }
            });
        }
    });

    // Initialize the traffic light buttons
    $("#red-light").dxButton({
        text: '',
        stylingMode: 'contained',
        type: 'danger',  // Red
        width: '80px',
        height: '80px',
        onClick() {
            DevExpress.ui.notify("Red Light On", "error", 1000);
        }
    });

    $("#yellow-light").dxButton({
        text: '',
        stylingMode: 'contained',
        type: 'default',  // Default/Gray (off state)
        width: '80px',
        height: '80px',
        onClick() {
            DevExpress.ui.notify("Yellow Light On", "warning", 1000);
        }
    });

    $("#green-light").dxButton({
        text: '',
        stylingMode: 'contained',
        type: 'default', // Default/Gray (off state)
        width: '80px',
        height: '80px',
        onClick() {
            DevExpress.ui.notify("Green Light On", "success", 1000);
        }
    });

    // Function to cycle through the signals automatically
    function autoCycleSignals() {
        setTimeout(() => {
            currentIndex = (currentIndex + 1) % signals.length;
            const nextSignal = signals[currentIndex];

            // Begin update to prevent multiple updates
            $("#signal-selector").dxRadioGroup("instance").beginUpdate();
            
            // Update the RadioGroup selection
            $("#signal-selector").dxRadioGroup("instance").option('value', nextSignal);

            // End update after updating
            $("#signal-selector").dxRadioGroup("instance").endUpdate();

            // Automatically cycle to the next signal after 30 seconds
            autoCycleSignals();
        }, 3000);
    }

    // Start automatic signal cycling
    autoCycleSignals();

});

 