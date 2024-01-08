using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    // Abstract class definition
    public abstract class Shape
    {
        // Abstract method (no implementation in the base class)
        public abstract void Draw();

        // Concrete method (has an implementation in the base class)
        public void DisplayInfo()
        {
            Console.WriteLine("This is a shape.");
        }
    }

    // Derived class 1
    public class Circle : Shape
    {
        // Implementation of the abstract method in the derived class
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    // Derived class 2
    public class Rectangle : Shape
    {
        // Implementation of the abstract method in the derived class
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle();
            Shape rectangle = new Rectangle();

            // Calling methods on objects
            circle.Draw();        // Calls the Draw method in the Circle class
            circle.DisplayInfo(); // Calls the DisplayInfo method in the base class

            rectangle.Draw();        // Calls the Draw method in the Rectangle class
            rectangle.DisplayInfo(); // Calls the DisplayInfo method in the base class
        }
    }
}


