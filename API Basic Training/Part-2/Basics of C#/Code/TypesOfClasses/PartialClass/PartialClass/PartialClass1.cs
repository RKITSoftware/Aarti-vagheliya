using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    public partial class Student
    {
        public string FirstName { get; set; };
        public string LastName { get; set; };


        public void DisplayInformation1()
        {
            Console.WriteLine($"Firstname = {FirstName}");
            Console.WriteLine($"LastName = {LastName}");
        }
    }
}
