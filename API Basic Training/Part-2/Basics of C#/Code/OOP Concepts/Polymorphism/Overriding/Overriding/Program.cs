using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding
{
    class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Circle();
            Shape shape2 = new Rectangle();

            shape1.Draw(); // Calls Draw method in Circle class
            shape2.Draw(); // Calls Draw method in Rectangle class
        }
    }
}

