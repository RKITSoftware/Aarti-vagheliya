using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    static class MyCollege
    {
        public static string CollegeName;
        public static string City;

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
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"College = {MyCollege.CollegeName}");
            Console.WriteLine($"City = {MyCollege.City}");
            Console.WriteLine($"Calling Static method: {MyCollege.Add(5, 6)}");
        }
    }
}
