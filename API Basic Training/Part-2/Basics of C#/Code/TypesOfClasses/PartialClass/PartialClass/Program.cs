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
            Student s = new Student();

            // Calling methods from different parts of the partial class
            s.Method1();
            Student.Method2();
            s.DisplayData();
            s.Display();
        }
    }
}
