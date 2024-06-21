$(function () {
    // Full Name
    $("#full-name").dxTextBox({
        placeholder: "Enter your full name",
        value: "",
        focusStateEnabled: true,
        hoverStateEnabled: true,
        hint: 'Enter your full name here..',
        spellcheck: true,
        showClearButton: true,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Full Name is required"
        },
        {
            type: "stringLength",
            min: 2,
            max: 200,
            message: "Full Name must be grater than 2 characters."
        },
        {
            type: "pattern",
            pattern: /^[a-zA-Z\s]+$/,
            message: "Full Name can only contain letters and spaces"
        },]
    });

    //Gender
    $('#gender').dxRadioGroup({
        items: ["Male", "Female"],
        layout: 'horizontal',
        hint: 'Select your gender.',
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Please select your gender"
            }
        ]
    });

    // Email
    $("#email").dxTextBox({
        placeholder: "Enter your email",
        value: "",
        hint: 'Enter your Email here..',
        spellcheck: true,
        showClearButton: true,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Email is required"
        }, {
            type: "pattern",
            pattern: /^[^@\s]+@[^@\s]+\.[^@\s]+$/,
            message: "Email is invalid"
        }]
    });

    // Phone Number
    $("#phone-number").dxTextBox({
        placeholder: "Enter your phone number",
        mask: "+91 00000 00000",  // Mask for Indian phone number
        value: "",
        maskChar: "*",
        maskRules: {
            'X': /[0-9]/  // Only digits allowed
        },
        maskInvalidMessage: "Phone number must be a 10-digit number",
        showClearButton: true,
        hint: 'Enter your phone number here..',
        onInput: function (e) {
            // Ensure the first 4 characters (country code) remain "+91-"
            if (!e.event.target.value.startsWith("+91-")) {
                e.component.option("value", "+91-");
            }
        }
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Phone Number is required"
            },
            {
                type: "pattern",
                pattern: /^\+91-\d{5}\s\d{5}$/,
                message: "Phone number must be in the format +91-XXXXX XXXXX"
            }
        ]
    });


    // Date of Birth
    $("#dob").dxDateBox({
        placeholder: "Select your date of birth",
        value: null,
        displayFormat: "dd/MM/yyyy"
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Date of Birth is required"
            },
            {
                type: "custom",
                validationCallback: function (e) {
                    const now = new Date();
                    const minAge = 18;
                    const maxAge = 25;
                    const minDate = new Date(now.getFullYear() - maxAge, now.getMonth(), now.getDate());
                    const maxDate = new Date(now.getFullYear() - minAge, now.getMonth(), now.getDate());
                    const dob = new Date(e.value);
                    return dob >= minDate && dob <= maxDate;
                },
                message: "You must be between 18 and 25 years old"
            }
        ]
    });

    // University
    $("#university").dxTextBox({
        placeholder: "Enter your university name",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "University is required"
        }]
    });

    //study area
    $('#study').dxSelectBox({
        items: ["B.Tech", "Diploma", "MCA"],
        placeholder: "Select your study area",
        value: null,
        showClearButton: true
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Study area is required"
            }
        ]
    });

    // Programming Language
    $("#language").dxDropDownBox({
        placeholder: "Select your programming languages",
        dataSource: ["C", "C++", "Java", "JavaScript", "Python", "Ruby", "PHP", "Swift", "Go", "Kotlin"],
        showClearButton: true,
        contentTemplate: function(e) {
            return $("<div>").dxList({
                dataSource: e.component.option("dataSource"),
                selectionMode: "single",
                showSelectionControls: true,
                selectedItemKeys: e.component.option("value"),
                onSelectionChanged: function(args) {
                    e.component.option("value", args.addedItems[0]);//args.selectedItemKeys);
                    e.component.close();
                },
                searchEditorOptions: function () {
                    return new $("div").dxTextBox({
                        showClearButton: true,
                        searchMode: 'contains', //'contains' | 'startswith' | 'equals'
                        inputAttr: { 'aria-label': 'Search' },
                    })
                },
                searchExpr: "",
                searchTimeout: 500,
                searchEnabled: true,
            });
        }
    }).dxValidator({
        validationRules: [
            {
                type: "required",
                message: "Please select one programming language"
            }
        ]
    });


    // Resume Upload
    $("#resume").dxFileUploader({
        selectButtonText: "Select Resume",
        accept: ".pdf, .doc, .docx",
        uploadMode: "useButtons",
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        minFileSize: 1024, // 1 KB
        maxFileSize: 1024 * 1024, // 1 MB
        onUploaded: function (e) {
            DevExpress.ui.notify("Resume uploaded successfully", "success", 3000);
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Resume is required"
        }]
    });


    // Accept Terms & Conditions
    $("#accept-terms").dxCheckBox({
        text: "I accept the terms and conditions",
        value: false,
    }).dxValidator({
        validationRules: [{
            type: "custom",
            validationCallback: function (e) {
                return e.value;
            },
            message: "You must accept the terms and conditions"
        }]
    });

    // Submit Button
    $("#submit-button").dxButton({
        text: "Submit Application",
        type: "success",
        onClick: function () {
            const validationGroup = DevExpress.validationEngine.getGroupConfig();
            const result = validationGroup.validate();
            if (result.isValid) {
                DevExpress.ui.notify("Application submitted successfully!", "success", 3000);
                $("#form-result").text("Application submitted successfully!");
            } else {
                DevExpress.ui.notify("Please correct the errors before submitting.", "error", 3000);
                $("#form-result").text("There are errors in the form. Please correct them and try again.");
            }
        }
    });
});