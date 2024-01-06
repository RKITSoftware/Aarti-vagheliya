using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    public static class MyCollege
    {
        static string CollegeName;
        static string City;

        static MyCollege()
        {
            CollegeName = "Darshan";
            City = "Rajkot";
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"College = {MyCollege.CollegeName}");
            Console.WriteLine(MyCollege.City);
            Console.WriteLine(MyCollege.Add(5, 6));
        }
    }
}
