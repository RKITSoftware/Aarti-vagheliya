$(()=>{
    $('#checked').dxCheckBox({
        value: null,
        text: 'checked',
        // iconSize: 25,
        accessKey : 'a',
        focusStateEnabled : true,
        hoverStateEnabled : false,
        //readOnly : true
        rtlEnabled : true,
        tabIndex : 1
    });

    $('#disabled').dxCheckBox({
        disabled : true,
        text: 'disabled'
    });

    $('#check1').dxCheckBox({
        value : undefined,
        text: 'checkbox-1',
        enableThreeStateBehavior : true,
        accessKey : 'b',
        focusStateEnabled : false,
        onValueChanged: function(e){
            // Display the new value of the checkbox
            alert("Checkbox value changed to: " + e.value);
        },
        tabIndex : 3 // not work in this because focusStateEnabled property.
    });

    $('#check2').dxCheckBox({
        value : false,
        text: 'checkbox-2',
        height: 120,
        width: 120,
        hint : 'This is 4th checkbox.',
        hoverStateEnabled : true,
        tabIndex : 2,
        // name : 'checkbox'
        onContentReady: function(e) {
            // This function is called when the content is ready
            console.log("CheckBox content is ready.");
            // You can manipulate the DOM or perform other actions here
            $("#check2").css("border", "2px solid green");
        }, 
        onInitialized: function(e) {
            // This function is called when the widget is initialized
            console.log("CheckBox widget initialized.");
            var instance = e.component; // Get the widget instance
            console.log("Initialized with value:", instance.option("value"));
            
            // Example: Modify the checkbox container
            $("#check2").css("background-color", "#f0f0f0");
        },
        onDisposing: function(e) {
            // This function is called when the widget is about to be destroyed
            console.log("CheckBox widget is being disposed.");
            // Perform any cleanup actions here
            $("#check2").css("background-color", ""); // Reset the background color
        }

        
    });

     // Get the CheckBox instance
      var checkBoxInstance = $("#check2").dxCheckBox("instance");

      // Destroy the CheckBox using the button
      $("#destroyButton").on("click", function() {
          checkBoxInstance.dispose();
          alert("CheckBox destroyed");
      });


    var checkBoxInstance = $('#check3').dxCheckBox({
        value: false,  // Initial value
        text: 'Check me',
       // text: 'checkbox-3',
        visible : true,
        onValueChanged: function(e) {
            // Handle valueChanged event
            console.log("value changed.",e);
            $('#eventStatus').text("valueChanged: CheckBox value changed to: " + checkBoxInstance.option("value"));
        },
        onOptionChanged: function(e) {
            console.log("option changed.",e);
            // Handle optionChanged event
            $('#eventStatus').text("optionChanged: " + e.name + " changed to " + e.value);
        }
    }).dxCheckBox("instance");

     // Change the text of the CheckBox when the button is clicked
     $('#changeTextButton').on('click', function() {
        checkBoxInstance.option("text", "New CheckBox Text");
    });

     
      //element() method
      var checkbox = $('#checked').dxCheckBox("instance");
      var element = checkbox.element();
      console.log(element);

      //focus() method
      var checkbox = $('#check3').dxCheckBox("instance");
      checkbox.focus();

      //getInstance() method
      var element = document.getElementById('check3');
      let instance = DevExpress.ui.dxCheckBox.getInstance(element);
      console.log(instance);



      var checkBox4 = $('#check4').dxCheckBox({
        value : false,
        text : 'new checkbox',
        onValueChanged: function (e) {
            console.log("New CheckBox value changed to: " + e.value);
        }
      }).dxCheckBox("instance");

       // Reset CheckBox to initial state
    $('#resetButton').on('click', function () {
        checkBox4.reset();
        console.log("Reset: New CheckBox value after reset:", checkBox4.option("value"));
        $('#eventStatus').text("New CheckBox reset to initial state.");
    });

      // Repaint the new CheckBox
      $('#repaintButton').on('click', function () {
        checkBox4.repaint();
        console.log("Repaint: New CheckBox repainted.");
        $('#eventStatus').text("New CheckBox repainted.");
    });

    // Begin Update
    $('#beginUpdateButton').on('click', function () {
        checkBox4.beginUpdate();
        console.log("Begin Update: Started batch update on New CheckBox.");
        $('#eventStatus').text("Begin Update called.");
    });

    // End Update
    $('#endUpdateButton').on('click', function () {
        checkBox4.endUpdate();
        console.log("End Update: Ended batch update on New CheckBox.");
        $('#eventStatus').text("End Update called.");
    });

    // Attach Event
    $('#onButton').on('click', function () {
        checkBox4.on('valueChanged', function (e) {
            console.log("On: Attached valueChanged event. New CheckBox value changed to: " + e.value);
            $('#eventStatus').text("Event attached. New CheckBox value changed to: " + e.value);
        });
        console.log("On: Event handler attached to New CheckBox.");
    });

    // Detach Event
    $('#offButton').on('click', function () {
        checkBox4.off('valueChanged');
        console.log("Off: Detached valueChanged event from New CheckBox.");
        $('#eventStatus').text("Event detached from New CheckBox.");
    });
});  