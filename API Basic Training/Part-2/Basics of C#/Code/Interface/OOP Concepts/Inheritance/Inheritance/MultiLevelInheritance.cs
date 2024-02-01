using System;

namespace Inheritance
{
    /// <summary>
    /// Class representing a German Shepherd inheriting from Dog.
    /// </summary>
    class GermanShepherd : Dog
    {
        /// <summary>
        /// Method representing guarding behavior of a German Shepherd.
        /// </summary>
        public void Guard()
        {
            Console.WriteLine("German Shepherd is guarding.");
        }
    }

    /// <summary>
    /// Class demonstrating Multi-Level Inheritance.
    /// </summary>
    class MultiLevelInheritance
    {
        /// <summary>
        /// Method to run and demonstrate Multi-Level Inheritance.
        /// </summary>
        public static void MultiLevelInheritanceRun()
        {
            // Creating an instance of the GermanShepherd class
            GermanShepherd germanShepherd = new GermanShepherd();

            // Calling methods to display output
            germanShepherd.Eat();
            germanShepherd.Bark();
            germanShepherd.Guard();

            Console.WriteLine();
        }
    }
}
