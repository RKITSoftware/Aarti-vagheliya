using System;


namespace PartialClass
{
    /// <summary>
    /// Main program class to demonstrate partial class usage.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the partial class
            Student objStudent = new Student();

            // Calling methods from different parts of the partial class
            objStudent.Method1();
            Student.Method2();
            objStudent.DisplayData();
            objStudent.Display();
        }
    }
}
