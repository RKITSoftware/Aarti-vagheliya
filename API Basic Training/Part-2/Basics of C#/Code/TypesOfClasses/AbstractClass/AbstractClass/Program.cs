using System;


namespace AbstractClass
{
    /// <summary>
    /// Abstract class representing a shape.
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// Abstract method for drawing a shape.
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Non-abstract method for displaying information about a shape.
        /// </summary>
        public void Display()
        {
            Console.WriteLine("This is a shape.");
        }
    }

    /// <summary>
    /// Derived class representing a circle.
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// Override of the abstract method to draw a circle.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    /// <summary>
    /// Derived class representing a square.
    /// </summary>
    class Square : Shape
    {
        /// <summary>
        /// Override of the abstract method to draw a square.
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle objCircle = new Circle();    
            Square oblSquare = new Square();

            objCircle.Draw();
            objCircle.Display();

            oblSquare.Draw();
            oblSquare.Display();    
        }
    }
}
