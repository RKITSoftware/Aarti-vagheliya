

namespace Exception.Models
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
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the department of the student.
        /// </summary>
        public string Department { get; set; }  
    }
}