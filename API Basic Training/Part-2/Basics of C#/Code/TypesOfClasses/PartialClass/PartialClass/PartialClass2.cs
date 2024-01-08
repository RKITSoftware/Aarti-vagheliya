using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
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
