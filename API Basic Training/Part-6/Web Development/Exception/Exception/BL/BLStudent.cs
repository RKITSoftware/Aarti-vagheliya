using Exception.Models;
using System.Collections.Generic;

namespace Exception.BL
{
    /// <summary>
    /// BLStudent class for managing Student related data.
    /// </summary>
    public class BLStudent
    {
        // Student data collection
        public List<Student> student = new List<Student>
        {
            new Student { Id = 1, Name = "ABC", Department = "CE"},
            new Student { Id = 2, Name = "PQR", Department = "ME"},
            new Student { Id = 3, Name = "XYZ", Department = "Pharmacy" },
        };
  
        // for Exception filter
        // Exception collection for demonstration purposes
        public List<Student> studentException = null;

    }
}