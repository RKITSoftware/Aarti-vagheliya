using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Method1();
            Student.Method2();
            s.DisplayData();
            s.Display();
        }
    }
}
