using System;

namespace Inheritance
{
    #region Class A
    /// <summary>
    /// Base class A.
    /// </summary>
    class A
    {
        public void MethodOfA()
        {
            Console.WriteLine("Inside class A");
        }
    }
    #endregion

    #region Class F
    /// <summary>
    /// Class F representing another class in the hierarchy.
    /// </summary>
    class F
    {
        public void MethodOfF()
        {
            Console.WriteLine("Inside class F.");
        }
    }
    #endregion

    #region Class B
    /// <summary>
    /// Class B inheriting from class F.
    /// </summary>
    class B :  F
    {
        public void MethodOfB()
        {
            Console.WriteLine("Inside class B.");
        }
    }
    #endregion

    #region Class C
    /// <summary>
    /// Class C inheriting from class A.
    /// </summary>
    class C : A
    {
        public void MethodOfC()
        {
            Console.WriteLine("Inside class C.");
        }
    }
    #endregion

    #region Class D
    /// <summary>
    /// Class D inheriting from class C.
    /// </summary>
    class D : C
    {
        public void MethodOfD()
        {
            Console.WriteLine("Inside class D.");
        }
    }
    #endregion

    /// <summary>
    /// Class demonstrating Hybrid Inheritance.
    /// </summary>
    class HybridInheritance
    {
        /// <summary>
        /// Method to run and demonstrate Hybrid Inheritance.
        /// </summary>
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
