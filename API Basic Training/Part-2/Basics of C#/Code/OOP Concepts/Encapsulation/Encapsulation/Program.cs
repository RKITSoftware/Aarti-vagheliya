using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Student
    {
        private string _name;
        private string _email;  
        private int _age;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }

            set { _email = value; }
        }

        public int Age
        {
            get { return _age; } 

            set {  _age = value; } 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            Console.Write("Enter student's Name : ");
            student.Name = Console.ReadLine();
            Console.Write("Enter student's Email : ");
            student.Email = Console.ReadLine();
            Console.Write("Enter student's Age : ");
            student.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Name : {student.Name}");
            Console.WriteLine($"Email : {student.Email}");
            Console.WriteLine($"Age : {student.Age}");
        }
    }
}
