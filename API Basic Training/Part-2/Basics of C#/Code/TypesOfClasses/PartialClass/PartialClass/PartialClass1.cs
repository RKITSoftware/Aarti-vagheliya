using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    partial class Student
    {
        string FirstName = "Arti";
        string LastName = "Vagheliya";

        public void Method1()
        {
            Console.WriteLine("Hello from method -1 ");
            
        }
        public void DisplayData()
        {
            Console.WriteLine($"FirstName = {FirstName}");
            Console.WriteLine($"LastName = {LastName}");
        }
    }
}
