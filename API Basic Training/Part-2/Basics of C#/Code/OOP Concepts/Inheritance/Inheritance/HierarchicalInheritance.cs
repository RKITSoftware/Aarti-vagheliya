using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class GrandFather
    {
        public void GrandFatherName()
        {
            Console.WriteLine("I am Grand Father. My name is ABC");
        }
    }

    class Father : GrandFather
    {
        public void FatherName() 
        {
            Console.WriteLine("I am Father. My name XYZ. i am child of ABC");

        }
    }

    class Uncle : GrandFather
    {
        public void UncleName()
        {
            Console.WriteLine("I am Uncle. My name is PQR. i am child of ABC");

        }
    }

    class FirstChild : Father
    {
        public void FirstChildName()
        {
            Console.WriteLine("I am child of XYZ. who is son of ABC.");
        }
    }

    class SecondChild : Uncle
    {
        public void SecondChildName()
        {
            Console.WriteLine("I am child Of PQR. who is son of ABC. ");
        }
    }
    class HierarchicalInheritance
    {
        public static void HierarchicalInheritanceRun()
        {
            FirstChild firstChild = new FirstChild();
            firstChild.FirstChildName();
            firstChild.FatherName();
            firstChild.GrandFatherName();

            Console.WriteLine();

            SecondChild secondChild = new SecondChild();
            secondChild.GrandFatherName();
            secondChild.UncleName();
            secondChild.SecondChildName();

            Console.WriteLine() ;
        }
    }
}
