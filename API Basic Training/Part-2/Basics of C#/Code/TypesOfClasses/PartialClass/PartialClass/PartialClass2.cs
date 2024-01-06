using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    public partial class Student
    {
        public int Age { get; set; };
        public int RollNo { get; set; };


        public void DisplayInformation2()
        {
            Console.WriteLine($"Age = {Age}");
            Console.WriteLine($"RollNo = {RollNo}");
        }
    }
}
