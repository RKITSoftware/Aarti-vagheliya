using System;

namespace PartialClass
{
    /// <summary>
    /// Second part of the partial class representing a Student.
    /// </summary>
    partial class Student
    {
        int Age = 20;
        int RollNo = 101;
        public static void Method2()
        {
            Console.WriteLine("Hello from Method -2 ");
        }

        public void Display()
        {
            Console.WriteLine($"Age = {Age}");
            Console.WriteLine($"RollNo = {RollNo}");
        }
    }
}
