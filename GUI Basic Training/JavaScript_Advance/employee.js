import Validation from './validation.js';


class Employee {
  constructor(name, email, salary) {
    this.name = name;
    this.email = email;
    this.salary = salary;
  } 

  //Method for add new employee to the list and localStorage
  static addEmployee(name, email, salary){ 
    let employee = new Employee(name, email, salary);
    employeeList = JSON.parse(localStorage.getItem("employeeList"));
    if(employeeList == null){
      employeeList = [];
    }

    //Add employee to the list
    employeeList.push(employee);

    // Store the employee list in local storage
    localStorage.setItem('employeeList', JSON.stringify(employeeList));

    swal('Employee added successfully!');
    displayEmployeeList();
  }


  //Method for delete employee from the list and localStorage
  static deleteEmployee(name){
    const employeeIndex = employeeList.findIndex(employee => employee.name === name);
    if (employeeIndex !== -1) {
      employeeList.splice(employeeIndex, 1);

      localStorage.setItem('employeeList', JSON.stringify(employeeList));

      displayEmployeeList();

      swal('Employee deleted successfully!');
    } else {
      swal('Employee not found.');
    }
  }

};
 
let employeeList = [];


//Arrow function for create and display EmployeeList
let displayEmployeeList = () => {
  const employeeListElement = document.querySelector('#employee-list');
  employeeListElement.innerHTML = '';

  employeeList = JSON.parse(localStorage.getItem("employeeList"));

  for (const employee of employeeList) {
    const employeeRowElement = document.createElement('tr');

    const nameElement = document.createElement('td');
    nameElement.textContent = employee.name;
    employeeRowElement.appendChild(nameElement);

    const emailElement = document.createElement('td');
    emailElement.textContent = employee.email;
    employeeRowElement.appendChild(emailElement);

    const salaryElement = document.createElement('td');
    salaryElement.textContent = employee.salary;
    employeeRowElement.appendChild(salaryElement);

    employeeListElement.appendChild(employeeRowElement);
  }
}


//EventListener for add employee button
var form = document.querySelector('#add-employee-form');
form.addEventListener("submit", (e) => {
  e.preventDefault();

  const nameInput = document.querySelector('#name');
  const emailInput = document.querySelector('#email');
  const salaryInput = document.querySelector('#salary');

  var validation = new Validation();

    //Validate the name
    const name = nameInput.value.trim();
    const nameError = validation.validateName(name);
    if (nameError) {
      displayError('name-error', nameError);
      nameInput.focus();
      return;
    }else {
      clearError('name-error');
    }


    //validate the email
    const email = emailInput.value.trim();
    const emailError = validation.validateEmail(email);
    if (emailError) {
      displayError('email-error', emailError);
      emailInput.focus();
      return;
    } else {
        clearError('email-error');
    }


    //validate the salary
    const salary = salaryInput.value.trim();
    const salaryError = validation.validateSalary(salary);
    if (salaryError) {
      displayError('salary-error', salaryError);
      salaryInput.focus();
      return;
    } else {
      clearError('salary-error');
    }

  Employee.addEmployee(name, email, salary); //Call addEmployee method Of Employee class

 
  $('#exampleModal').modal('hide');//Dismiss the modal after submitting

  form.reset();//Clear the input field
});


//Function for display error
function displayError(id, message) {
  const errorDiv = document.querySelector(`#${id}`);
  errorDiv.textContent = message;
  errorDiv.style.display = 'block';
  errorDiv.style.borderColor = 'red';
}


//Function for clear error
function clearError(id) {
  const errorDiv = document.querySelector(`#${id}`);
  errorDiv.textContent = '';
  errorDiv.style.display = 'none';
}


//EventListner for delete employee button
document.querySelector('#delete-employee-button').addEventListener('click', () =>{
  const name = prompt("Enter Employee name to delete.")

  Employee.deleteEmployee(name);//Call deleteEmployee method Of Employee class
});


// Load the employee list from local storage
const storedEmployeeList = JSON.parse(localStorage.getItem('employeeList'));
if (storedEmployeeList) { 
  employeeList = storedEmployeeList;
}

displayEmployeeList();



