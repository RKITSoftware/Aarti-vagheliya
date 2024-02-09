using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging_Demo
{
    /// <summary>
    /// Demonstrate debugging in visual studio
    /// </summary>
    class Program
    {
       
        /// <summary>
        /// This method calculates the factorial of a given number.
        /// </summary>
        /// <param name="num">The number for which to calculate the factorial.</param>
        /// <returns>The factorial of the input number.</returns>
  
        public static int Factorial(int num)
        {
            int fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            //return type statement
            return fact;
        }


        static void Main(string[] args)
        {
            //Calling method Factorial
            Console.Write("Enter number for find factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("factorial = {0}", Factorial(num));
        }
    }
}
