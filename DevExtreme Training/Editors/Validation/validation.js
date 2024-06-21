$(function() {
    // TextBox for Name
    $("#text-box").dxTextBox({
        placeholder: "Enter your name",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required", //'required' | 'numeric' | 'range' | 'stringLength' | 'custom' | 'compare' | 'pattern' | 'email' | 'async'
            message: "Name is required"
        }]
    });

    // TextBox for Email with pattern validation
    $("#email-box").dxTextBox({
        placeholder: "Enter your email",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "pattern",
            pattern: /^[^@\s]+@[^@\s]+\.[^@\s]+$/,
            message: "Email is invalid"
        }]
    });

    // DateBox for Date of Birth
    $("#date-box").dxDateBox({
        type: "date",
        placeholder: "Enter your date of birth",
        value: new Date(),
    }).dxValidator({
        validationRules: [{
            type: "range",
            min: new Date(1900, 0, 1),
            max: new Date(),
            message: "Date must be between 1900 and today"
        }]
    });

    // NumberBox for Age with range and required validation
    $("#number-box").dxNumberBox({
        placeholder: "Enter your age",
        value: null,
        min: 1,
        max: 120,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Age is required"
        }, {
            type: "range",
            min: 1,
            max: 120,
            message: "Age must be between 1 and 120"
        }]
    });

    // SelectBox for Country with required validation
    $("#select-box").dxSelectBox({
        items: ["India","USA", "Canada", "UK", "Australia"],
        placeholder: "Select your country",
        value: null,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Country is required"
        }]
    });

    // CheckBox for Terms Agreement with custom validation
    $("#check-box").dxCheckBox({
        text: "I agree to the terms and conditions",
        value: false,
    }).dxValidator({
        validationRules: [{
            type: "custom",
            validationCallback: function(e) {
                return e.value;
            },
            message: "You must agree to the terms"
        }]
    });

    // Button to validate all editors
    $("#validate-button").dxButton({
        text: "Validate All",
        type: "success",
        onClick: function() {
            const validationGroup = DevExpress.validationEngine.getGroupConfig();
            const result = validationGroup.validate();
            if (result.isValid) {
                DevExpress.ui.notify("All data is valid!", "success", 3000);
            } else {
                DevExpress.ui.notify("Some data is invalid. Please check again.", "error", 3000);
            }
        }
    });

    // Assign a validation group to all editors
    $(".container .editor-container").each(function() {
        $(this).find(".dx-validatebox").dxValidationGroup({
            validationGroup: "validationGroup"
        });
    });
});
