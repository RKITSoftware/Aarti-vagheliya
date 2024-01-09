using System;


namespace SealedClass
{
    /// <summary>
    /// Sealed class demonstrating a simple addition operation.
    /// </summary>
    sealed class Demo
    {
        /// <summary>
        /// Method to add two integers.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Main program class to demonstrate the usage of the sealed class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
      
            int ans = demo.Add(1, 2);
            Console.WriteLine(ans);
        }
    }
}
