
const apiBaseUrl = "https://6543d51f01b5e279de2107e4.mockapi.io/contact";


class AddressBook {
    constructor() {
        this.contacts = [];
    }

    // Fetch data from the API
    async fetchDataFromApi() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: apiBaseUrl,
                method: 'GET',
                dataType: 'json',
                success: (data) => {
                    //console.log(data);
                    this.contacts = data; // Assign the data to the contacts list
                    this.displayContacts();
                    resolve(data);
                },
                error: (error) => {
                    //console.error(`Failed to fetch data from the API: ${status}`);
                    console.error(`Failed to fetch data from the API: ${error}`);
                    reject(error);
                }
            });
        });
    }
    
    // Add a contact to the API
    async addContactToAPI(contact) {
        try {
            const response = await fetch(apiBaseUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(contact),
            });

            if (response.ok) {
                const addedContact = await response.json();
                this.contacts.push(addedContact);
                this.displayContacts();
                alert("new data added");
                $("#add-data-modal").modal("hide");
            } else {
                console.error("Failed to add contact:", response.status);
            }
        } catch (error) {
            console.error("Error:", error);
        }
    }

    // Delete a contact from  the API
    async deleteContactFromAPI(contactId) {
        try {
            const response = await fetch(`${apiBaseUrl}/${contactId}`, {
                method: "DELETE",
            });

            if (response.ok) {
                const index = this.contacts.findIndex((c) => c.contactId === contactId.toString());
                console.log("index in api call:",index);
                if (index !== -1) {
                    this.contacts.splice(index, 1);
                    this.displayContacts();
                    alert("data deleted");
                }
            } else {
                console.error("Failed to delete contact:", response.status);
            }
        } catch (error) {
            console.error("Error:", error);
        }
    }

    // Edit a contact in the API
    async editContactInAPI(contactId, updatedData) {
        try {
            const response = await fetch(`${apiBaseUrl}/${contactId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedData),
            });

            if (response.ok) {
                const updatedContact = await response.json();
                const index = this.contacts.findIndex((c) => c.contactId === contactId.toString());
                //console.log("index in api call:",index);
                if (index !== -1) {
                    this.contacts[index] = updatedContact;
                    this.displayContacts();
                    $("#edit-data-modal").modal("hide");
                    //console.log("Contact updated successfully:", updatedContact);
                    alert("data upadated");
                }
            } else {
                console.error("Failed to edit contact:", response.status);
            }
        } catch (error) {
            console.error("Error:", error);
        }
    }

    
    // Display contacts in the table
    displayContacts() {
        const contactsTable = document.getElementById("contacts");
        contactsTable.innerHTML = ""; // Clear the table
        this.contacts.forEach((contact) => {
            const contactRow = `
                <tr>
                    <td>${contact.name}</td>
                    <td>${contact.email}</td>
                    <td>${contact.phone}</td>
                    <td>${contact.city}</td>
                    <td>${contact.state}</td>
                    <td>${contact.country}</td>
                    <td>
                        <button class="btn btn-danger delete-contact mr-2" data-contact-id="${contact.contactId}">Delete</button>
                        <button class="btn btn-primary edit-contact" data-contact-id="${contact.contactId}">Edit</button>
                    </td>
                </tr>
            `;
            contactsTable.insertAdjacentHTML("beforeend", contactRow);
        });
    }
}

// create object of AddressBook
const addressBook = new AddressBook();

// Fetch data from the API when the document is ready
$(document).ready(function () {
    addressBook.fetchDataFromApi();
    
    // Add contact form and hadler for add contact
    $("#contact-form button[type='submit']").on("submit", function (e) {
        e.preventDefault();
        if ($("#contact-form").valid()) {
            const name = $("#name").val();
            const email = $("#email").val();
            const phone = $("#phone").val();
            const city = $("#city").val();
            const state = $("#state").val();
            const country = $("#country").val();
            const contact = { name, email, phone, city, state, country };
            addressBook.addContactToAPI(contact);
            $("#name, #email, #phone, #city, #state, #country").val("");
        }
    });
    
    // Delete contact button click
    $("#contacts").on("click", ".delete-contact", function () {
        const contactId = $(this).data("contact-id");
        //console.log(contactId);
        //console.log(addressBook.contacts);
        addressBook.deleteContactFromAPI(contactId);
    });
    
    // Edit contact button click
    $("#contacts").on("click", ".edit-contact", function () {
        const contactId = $(this).data("contact-id");
        //console.log(contactId);
        openEditModal(contactId);
    });


    // Function to open the edit modal with contact data
    function openEditModal(contactId) {
        const contact = addressBook.contacts.find((c) => c.contactId === contactId.toString());
        // console.log(contact);
        // console.log(contactId);
        if(contact){
            $("#edit-name").val(contact.name);
            $("#edit-email").val(contact.email);
            $("#edit-phone").val(contact.phone);
            $("#edit-city").val(contact.city);
            $("#edit-state").val(contact.state);
            $("#edit-country").val(contact.country);
            $("#edit-contact-id").val(contact.contactId); 
           //console.log(contact.contactId);
           //console.log("model open...");
            $("#edit-data-modal").modal("show");
        }else{
            console.log("contact not found..")
        }
    }

    // upadated contact form submission code
    $("#edit-contact-form").on("submit",function (e) {
        //console.log("Edit Contact Form Submitted");
        e.preventDefault();
        if($(this).valid()){
            const contactId = $("#edit-contact-id").val();
            //console.log(contactId);
            const updatedData = {
                name: $("#edit-name").val(),
                email: $("#edit-email").val(),
                phone: $("#edit-phone").val(),
                city: $("#edit-city").val(),
                state: $("#edit-state").val(),
                country: $("#edit-country").val(),
            };
            //console.log("Contact ID:", contactId);
            //console.log("Updated Data:", updatedData);
            addressBook.editContactInAPI(contactId, updatedData);
            $("#edit-data-modal").modal("hide");
        }
    });
});
