using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    // Base class
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    // Derived class inheriting from a single base class
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }
    }
    class SingleInheritance
    {
        public static void SingleInheritanceRun()
        {
            Dog myDog = new Dog();
            myDog.Eat();  // Inherited method
            myDog.Bark(); // Method from the derived class

            Console.WriteLine();
        }
    }
}
