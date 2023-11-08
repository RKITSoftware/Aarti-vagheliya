// User class
class User {
    constructor(username, password,confirmPassword) {
        this.username = username;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
}

// array to store user objects in local Storage
let users = JSON.parse(localStorage.getItem("users")) || []; 

// Function to save the users in local storage
function saveUsersToLocalStorage() {
    localStorage.setItem("users", JSON.stringify(users));
}

// Function to push a user object to the users array and save to local storage
function createUser(username, password,confirmPassword) {
    const newUser = new User(username, password,confirmPassword);
    users.push(newUser);
    saveUsersToLocalStorage();
}

// Function to check if a user exists in the users array
function userExists(username) {
    return users.some((user) => user.username === username);
}

// Function to log in a user and set username in session storage
function loginUser(username, password,confirmPassword) {
    const user = users.find((user) => user.username === username && user.password === password && user.confirmPassword === confirmPassword);
    if (user) {
        sessionStorage.setItem("user", JSON.stringify({ username: user.username }));
        return true;
    }
    return false;
}

// Function to log out the current user from session storage
function logoutUser() {
    sessionStorage.removeItem("user");
}

// Functions to show/hide the login and address book sections
 function showLoginForm() {
    $("#login-form").show();
    $("#create-account-form").hide();
    $("#address-book").hide();
    $("#user-info").text("");
    $("#user-info").hide();
    $("#logout").hide();
}

//Functions to show/hide the login and address book sections
function showAddressBook(username) {
    $("#login-form").hide();
    $("#create-account-form").hide();
    $("#address-book").show();
    $("#user-info").show();
    $("#logout").show();
    $("#user-info").text("Logged in as: " + username);
}

$(document).ready(function () {

    // Handle login form submission
    $("#login").submit(function (e) {
        e.preventDefault();
        const username = $("#username").val();
        const password = $("#password").val();
        const confirmPassword = $("#confirm-password").val(); 

        if (loginUser(username, password,confirmPassword)) {
            showAddressBook(username);
        } else {
            alert("Authentication failed. Try again.");
        }
    });

    // Handle create account form submission
    $("#create-account").submit(function (e) {
        e.preventDefault();
        const newUsername = $("#new-username").val();
        const newPassword = $("#new-password").val();
        const confirmPassword = $("#confirm-password").val(); 

        if (userExists(newUsername)) {
            alert("User already exists. Try a different username.");
        } else {
            createUser(newUsername, newPassword,confirmPassword);
            if (loginUser(newUsername, newPassword,confirmPassword)) {
                showAddressBook(newUsername);
            }
        }
    });

    // Handle logout
    $("#logout").click(function () {
        logoutUser();
        showLoginForm();
    });

    // Handle create account link
    $("#create-account-link").click(function (e) {
        e.preventDefault();
        $("#login-form").hide();
        $("#create-account-form").show();
    });

    // Handle login link
    $("#login-link").click(function (e) {
        e.preventDefault();
        $("#create-account-form").hide();
        $("#login-form").show();
    });

    // Check if the user is already logged in
    const loggedInUser = sessionStorage.getItem("user");
    if (loggedInUser) {
        showAddressBook(JSON.parse(loggedInUser).username);
    } else {
        showLoginForm();
    } 
});

