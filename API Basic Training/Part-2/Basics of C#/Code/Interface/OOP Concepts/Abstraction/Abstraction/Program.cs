using System;

namespace Abstraction
{
    /// <summary>
    /// Abstract class representing a generic shape.
    /// </summary>
    public abstract class Shape
    {
        #region Abstract Method
        /// <summary>
        /// Abstract method for drawing a shape.
        /// </summary>
        public abstract void Draw();
        #endregion

        #region Concrete Method
        /// <summary>
        /// Concrete method with an implementation in the base class.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine("This is a shape.");
        }
        #endregion
    }

    /// <summary>
    /// Derived class representing a circle.
    /// </summary>
    public class Circle : Shape
    {
        #region Implementation of Abstract Method

        /// <summary>
        /// Implementation of the abstract method for drawing a circle.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
        #endregion
    }

    /// <summary>
    /// Derived class representing a rectangle.
    /// </summary>
    public class Rectangle : Shape
    {
        #region Implementation of Abstract Method

        /// <summary>
        /// Implementation of the abstract method for drawing a rectangle.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }
        #endregion
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program
    {
        #region Main Method

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Creating instances of shapes
            Shape objcircle = new Circle();
            Shape objrectangle = new Rectangle();

            // Calling methods on objects
            objcircle.Draw();        // Calls the Draw method in the Circle class
            objcircle.DisplayInfo(); // Calls the DisplayInfo method in the base class

            objrectangle.Draw();        // Calls the Draw method in the Rectangle class
            objrectangle.DisplayInfo(); // Calls the DisplayInfo method in the base class
        }
        #endregion
    }
}


