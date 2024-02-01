using System;

namespace Overriding
{
    /// <summary>
    /// Base class representing a shape.
    /// </summary>
    class Shape
    {
        /// <summary>
        /// Virtual method to draw a shape.
        /// </summary>
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape");
        }
    }

    /// <summary>
    /// Class representing a circle, inheriting from Shape.
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// Overridden method to draw a circle.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    /// <summary>
    /// Class representing a rectangle, inheriting from Shape.
    /// </summary>
    class Rectangle : Shape
    {
        /// <summary>
        /// Overridden method to draw a rectangle.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to run the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Shape objShape1 = new Circle();
            Shape objShape2 = new Rectangle();

            objShape1.Draw(); // Calls Draw method in Circle class
            objShape2.Draw(); // Calls Draw method in Rectangle class
        }
    }
}

