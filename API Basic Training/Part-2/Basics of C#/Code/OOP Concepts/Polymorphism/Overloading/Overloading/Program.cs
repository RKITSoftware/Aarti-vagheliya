using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MathOperations math = new MathOperations();

            int resultInt = math.Add(5, 3);
            double resultDouble = math.Add(2.5, 3.7);

            Console.WriteLine($"Result (int): {resultInt}");
            Console.WriteLine($"Result (double): {resultDouble}");
        }
    }
}



