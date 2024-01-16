using System;

namespace Inheritance
{
    #region Base class GrandFather
    /// <summary>
    /// Base class representing a GrandFather.
    /// </summary>
    class GrandFather
    {
        /// <summary>
        /// Method representing the name of the GrandFather.
        /// </summary>
        public void GrandFatherName()
        {
            Console.WriteLine("I am Grand Father. My name is ABC");
        }
    }
    #endregion

    #region Derived class Father
    /// <summary>
    /// Class representing a Father inheriting from GrandFather.
    /// </summary>
    class Father : GrandFather
    {
        /// <summary>
        /// Method representing the name of the Father.
        /// </summary>
        public void FatherName() 
        {
            Console.WriteLine("I am Father. My name XYZ. i am child of ABC");

        }
    }
    #endregion

    #region Derived class Uncle
    /// <summary>
    /// Class representing an Uncle inheriting from GrandFather.
    /// </summary>
    class Uncle : GrandFather
    {
        /// <summary>
        /// Method representing the name of the Uncle.
        /// </summary>
        public void UncleName()
        {
            Console.WriteLine("I am Uncle. My name is PQR. i am child of ABC");

        }
    }
    #endregion

    #region Derived class FirstChild
    /// <summary>
    /// Class representing the first child inheriting from Father.
    /// </summary>
    class FirstChild : Father
    {
        /// <summary>
        /// Method representing the name of the first child.
        /// </summary>
        public void FirstChildName()
        {
            Console.WriteLine("I am child of XYZ. who is son of ABC.");
        }
    }
    #endregion

    #region Derived class SecondChild
    /// <summary>
    /// Class representing the second child inheriting from Uncle.
    /// </summary>
    class SecondChild : Uncle
    {
        /// <summary>
        /// Method representing the name of the second child.
        /// </summary>
        public void SecondChildName()
        {
            Console.WriteLine("I am child Of PQR. who is son of ABC. ");
        }
    }
    #endregion

    /// <summary>
    /// Class demonstrating Hierarchical Inheritance.
    /// </summary>
    class HierarchicalInheritance
    {
        #region HierarchicalInheritanceRun Method
        /// <summary>
        /// Method to run and demonstrate Hierarchical Inheritance.
        /// </summary>
        public static void HierarchicalInheritanceRun()
        {
            // Creating an instance of the FirstChild class
            FirstChild objFirstChild = new FirstChild();

            // Calling methods to display names
            objFirstChild.FirstChildName();
            objFirstChild.FatherName();
            objFirstChild.GrandFatherName();

            Console.WriteLine();

            // Creating an instance of the SecondChild class
            SecondChild objSecondChild = new SecondChild();

            // Calling methods to display names
            objSecondChild.GrandFatherName();
            objSecondChild.UncleName();
            objSecondChild.SecondChildName();

            Console.WriteLine() ;
        }
        #endregion
    }
}
