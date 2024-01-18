using System;


namespace HttpResponseMethod.Models
{
    /// <summary>
    /// Represents a student entity with basic information.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the student.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the mobile number of the student.
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the student.
        /// </summary>
        public string Email { get; set; }
    }
}