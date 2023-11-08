$(document).ready(function () {

    // validation rules for the login form
    $("#login").validate({
        rules: {
            username: {
                required: true,
                minlength:3,
            },
            password: {
                required: true,
            },
            "confirm-password": {
                required: true,
                equalTo: "#password", 
            },
        },
        messages: {
            username: {
                required: "Please enter your username.",
                minlength: "username must be at least 3 characters long.",
            },
            password: {
                required: "Please enter your password.",
            },
            "confirm-password": {
                required: "Please confirm your password.",
                equalTo: "Passwords do not match.",
            },
        },
    });

    // validation rules for the create account form
    $("#create-account").validate({
        rules: {
            "new-username": {
                required: true,
                minlength:3,
            },
            "new-password": {
                required: true,
            },
            "new-confirm-password": {
                required: true,
                equalTo: "#new-password", // Ensure that "new-confirm-password" matches "new-password"
            },
        },
        messages: {
            "new-username": {
                required: "Please enter a username.",
                minlength: "username must be at least 3 characters long.",
            },
            "new-password": {
                required: "Please enter a password.",
            },
            "new-confirm-password": {
                required: "Please confirm your password.",
                equalTo: "Passwords do not match.",
            },
        },
    });

    // Validation rules for Contact Form 
    $("#contact-form").validate({
        rules: {
            name: {
                required: true,
                minlength: 2,
            },
            email: {
                required: true,
                email: true,
            },
            phone: {
                required: true,
                phoneNumber: true,
            },
            city: {
                required: true,
            },
            state: {
                required: true,
            },
            country: {
                required: true,
            },
        },
        messages: {
            name: {
                required: "Please enter a name.",
                minlength: "Name must be at least 2 characters long.",
            },
            email: {
                required: "Please enter an email address.",
                email: "Please enter a valid email address.",
            },
            phone: {
                required: "Please enter a phone number.",
                phoneNumber: "Please enter a valid phone number (10 digits starting with 6-9).",
            },
            city: {
                required: "Please enter a city.",
            },
            state: {
                required: "Please enter a state.",
            },
            country: {
                required: "Please enter a country.",
            },
        },
    });

    // Validation rules for Edit Contact Form 
    $("#edit-contact-form").validate({
        rules: {
            "edit-name": {
                required: true,
                minlength: 2,
            },
            "edit-email": {
                required: true,
                email: true,
            },
            "edit-phone": {
                required: true,
                phoneNumber: true, // Use the custom rule for Indian phone numbers
            },
            "edit-city": "required",
            "edit-state": "required",
            "edit-country": "required",
        },
        messages: {
            "edit-name": {
                required: "Please enter a name.",
                minlength: "Name must be at least 2 characters long.",
            },
            "edit-email": {
                required: "Please enter an email address.",
                email: "Please enter a valid email address.",
            },
            "edit-phone": {
                required: "Please enter a valid phone number.",
                phoneNumber: "Please enter a valid Indian phone number (10 digits starting with 6-9).",
            },
            "edit-city": "Please enter a city.",
            "edit-state": "Please enter a state.",
            "edit-country": "Please enter a country.",
        },
    });
});

// Custom rule for a valid Indian phone number
$.validator.addMethod("phoneNumber", function (phone_number) {
    return phone_number.length === 10 && phone_number.match(/^[6-9]\d{9}$/);
});
