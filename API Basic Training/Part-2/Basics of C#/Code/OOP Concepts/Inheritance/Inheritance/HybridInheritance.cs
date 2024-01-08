using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class A
    {
        public void MethodOfA()
        {
            Console.WriteLine("Inside class A");
        }
    }

    class F
    {
        public void MethodOfF()
        {
            Console.WriteLine("Inside class F.");
        }
    }

    class B :  F
    {
        public void MethodOfB()
        {
            Console.WriteLine("Inside class B.");
        }
    }

    class C : A
    {
        public void MethodOfC()
        {
            Console.WriteLine("Inside class C.");
        }
    }

    class D : C
    {
        public void MethodOfD()
        {
            Console.WriteLine("Inside class D.");
        }
    }
    class HybridInheritance
    {
        public static void HybridInheritanceRun()
        {
            D d = new D();
            d.MethodOfD();
            d.MethodOfC();
            d.MethodOfA();

            Console.WriteLine();    

            B b = new B();  
            b.MethodOfB();
            b.MethodOfF();

            Console.WriteLine();
        }
    }
}
