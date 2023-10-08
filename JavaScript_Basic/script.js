var form = document.querySelector("form");

form.addEventListener("submit", function(event) {
  event.preventDefault();

  // Validate the name field
  var name = document.querySelector("input[name='name']").value;
  if (name.trim() === "") {
    alert("Please enter your name.");
    return;
  }

  // Validate the email field
  var email = document.querySelector("input[name='email']").value;
  if (!/\S+@\S+\.\S+/.test(email)) {
    alert("Please enter a valid email address.");
    return;
  }

  // Validate the password field
  var password = document.querySelector("input[name='password']").value;
  if (password.length < 6) {
    alert("Please enter a password with at least 6 characters.");
    return;
  }

  // Submit the form
  form.submit();
});

// Select the country dropdown box
var countrySelect = document.querySelector("select[name='country']");

// Get the array of countries
var countries = ["United States", "Canada", "United Kingdom", "India", "China"];
    countries.push("UK");

// Add the countries to the dropdown box
for (var i = 0; i < countries.length; i++) {
  var option = document.createElement("option");
  option.value = countries[i];
  option.textContent = countries[i];
  countrySelect.appendChild(option);
}
