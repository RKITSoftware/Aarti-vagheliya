using System;


namespace Inheritance
{
    /// <summary>
    /// Base class representing an Animal.
    /// </summary>
    class Animal
    {
        /// <summary>
        /// Method representing eating behavior of an animal.
        /// </summary>
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    /// <summary>
    /// Derived class (Dog) inheriting from a single base class (Animal).
    /// </summary>
    class Dog : Animal 
    {
        /// <summary>
        /// Method representing barking behavior of a dog.
        /// </summary>
        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }
    }

    /// <summary>
    /// Class demonstrating Single Inheritance.
    /// </summary>
    class SingleInheritance
    {
        /// <summary>
        /// Method to run and demonstrate Single Inheritance.
        /// </summary>
        public static void SingleInheritanceRun()
        {
            // Creating an instance of the Dog class
            Dog myDog = new Dog();
            myDog.Eat();  // Inherited method
            myDog.Bark(); // Method from the derived class

            Console.WriteLine();
        }
    }
}
