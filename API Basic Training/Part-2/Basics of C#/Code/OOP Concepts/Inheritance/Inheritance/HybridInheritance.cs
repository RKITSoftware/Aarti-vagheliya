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
            // Creating an instance of class D and calling its methods
            D objD = new D();
            objD.MethodOfD();  // Calls the MethodOfD in class D
            objD.MethodOfC();  // Calls the MethodOfC in class C (base class of D)
            objD.MethodOfA();  // Calls the MethodOfA in class A (base class of C)

            Console.WriteLine();  // Adding a line break for better readability

            // Creating an instance of class B and calling its methods
            B objB = new B();
            objB.MethodOfB();  // Calls the MethodOfB in class B
            objB.MethodOfF();  // Calls the MethodOfF in class F (derived class of B)
            Console.WriteLine();  // Adding a line break for better readability

        }
    }
}
