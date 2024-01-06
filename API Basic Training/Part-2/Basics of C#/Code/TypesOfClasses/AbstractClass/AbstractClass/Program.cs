using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    //Abstract class
    abstract class Shape
    {

        //Abstract method
        public abstract void Draw();

        //Non abstact Method
        public void Display()
        {
            Console.WriteLine("This is a shape.");
        }
    }

    class Circle : Shape
    {
        //Override abstract method
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    class Square : Shape
    {
        //Override Absract method
        public override void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle();    
            Square s = new Square();

            c.Draw();
            c.Display();

            s.Draw();
            s.Display();    
        }
    }
}
