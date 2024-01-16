using System;

namespace AccessibilityModifier
{
    public class BaseClass
    {
        #region All Fields
        // Public field can be accessed from anywhere
        public int PublicField = 10;

        // Private field can only be accessed within the same class
        private int _privateField = 20;

        // Protected field can be accessed within the same class or its derived classes
        protected int ProtectedField = 30;

        // Internal field can be accessed within the same assembly (project)
        internal int InternalField = 40;

        // Protected internal field can be accessed within the same assembly or its derived classes
        protected internal int ProtectedInternalField = 50;

        // Private protected field can be accessed within the same assembly and its derived classes
        private protected int PrivateProtectedField = 60;
        #endregion

        #region Methods
        /// <summary>
        /// PublicMethod: Accessible from anywhere.
        /// </summary>
        public void PublicMethod()
        {
            Console.WriteLine("Public Method");
        }

        /// <summary>
        /// PrivateMethod: Accessible only within the same class.
        /// </summary>
        private void PrivateMethod()
        {
            Console.WriteLine("Private Method");
        }

        /// <summary>
        /// ProtectedMethod: Accessible within the same class and its derived classes.
        /// </summary>
        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected Method");
        }

        /// <summary>
        /// InternalMethod: Accessible within the same assembly (project).
        /// </summary>
        internal void InternalMethod()
        {
            Console.WriteLine("Internal Method");
        }

        /// <summary>
        /// ProtectedInternalMethod: Accessible within the same assembly and its derived classes.
        /// </summary>
        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("Protected Internal Method");
        }

        /// <summary>
        /// PrivateProtectedMethod: Accessible within the same assembly and its derived classes, but not in other assemblies.
        /// </summary>
        private protected void PrivateProtectedMethod()
        {
            Console.WriteLine("Private Protected Method");
        }

        #endregion
    }


    /// <summary>
    /// Derived class inheriting from BaseClass
    /// </summary>

    public class DerivedClass : BaseClass
    {
        #region Access BaseClass Members
        /// <summary>
        /// Example method in the derived class
        /// </summary>

        public void AccessBaseClassMembers()
        {
            // Accessing public member from the base class
            Console.WriteLine($"Public Field: {PublicField}");

            // Private members are not accessible in the derived class
            //Console.WriteLine($"Private Field: {_privateField}"); // Uncommenting this line will result in a compilation error

            // Accessing protected member from the base class
            Console.WriteLine($"Protected Field: {ProtectedField}");

            // Accessing internal member from the base class
            Console.WriteLine($"Internal Field: {InternalField}");

            // Accessing protected internal member from the base class
            Console.WriteLine($"Protected Internal Field: {ProtectedInternalField}");

            // Accessing private protected member from the base class
            Console.WriteLine($"Private Protected Field: {PrivateProtectedField}");
        }
        #endregion
    }

    /// <summary>
    /// Main class Program
    /// </summary>
   public class Program
    {
        #region Main method
        /// <summary>
        /// Main method for calling base class and derived class's method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region methods call of BaseClass 
            // Creating an instance of the base class
            BaseClass baseObject = new BaseClass();

            // Accessing public method from the base class
            baseObject.PublicMethod();

            // Private method is not accessible from outside the class
            //baseObject.PrivateMethod(); // Uncommenting this line will result in a compilation error

            //// Accessing protected method from the base class
            //baseObject.ProtectedMethod();

            // Accessing internal method from the base class
            baseObject.InternalMethod();

            // Accessing protected internal method from the base class
            baseObject.ProtectedInternalMethod();

            // Private protected method is not accessible from outside the class
            // baseObject.PrivateProtectedMethod(); // Uncommenting this line will result in a compilation error

            #endregion

            Console.WriteLine();

            #region Methods call of Derived Class
            // Creating an instance of the derived class
            DerivedClass derivedObject = new DerivedClass();

            // Accessing public method from the base class using the derived class object
            derivedObject.PublicMethod();

            // Private method is not accessible from outside the class
            // derivedObject.PrivateMethod(); // Uncommenting this line will result in a compilation error

            //// Accessing protected method from the base class using the derived class object
            //derivedObject.ProtectedMethod();

            // Accessing internal method from the base class using the derived class object
            derivedObject.InternalMethod();

            // Accessing protected internal method from the base class using the derived class object
            derivedObject.ProtectedInternalMethod();

            // Private protected method is not accessible from outside the class
            // derivedObject.PrivateProtectedMethod(); // Uncommenting this line will result in a compilation error

            Console.WriteLine();

            // Using the derived class method to access members of the base class
            derivedObject.AccessBaseClassMembers();

            #endregion
        }

        #endregion

    }
}



