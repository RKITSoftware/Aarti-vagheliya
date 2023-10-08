
class Validation {
	
  // Validate the employee name
  validateName(name) {
    if (!name) {
      return "Name is required.";
    }

    const regex = /^[A-Za-z\s]+$/;
    if (!regex.test(name)) {
      return "Invalid name format.";
    }

    return null; // No error
  }

  // Validate the employee email
  validateEmail(email) {
    if (!email) {
      return "Email is required.";
    }

    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!regex.test(email)) {
      return "Invalid email format.";
    }

    return null; // No error
  }

  // Validate the employee salary
  validateSalary(salary) {
    if (!salary) {
      return "Salary is required.";
    }

    const regex = /^[0-9]+([,.][0-9]+)?$/;
    if (!regex.test(salary)) {
      return "Invalid salary format.";
    }

    return null; // No error
  }
}

export default Validation;