using System;

namespace AccessibilityModifier
{
    #region Base Class

    /// <summary>
    /// Base class with different access modifiers.
    /// </summary>
    public class MyClass
    {
        // Public field
        public string PublicField = "I am public!";

        // Private field
        private string _privateField = "I am private!";

        // Protected field
        protected string protectedField = "I am protected!";

        // Internal field
        internal string internalField = "I am internal!";

        /// <summary>
        /// Public method of the base class.
        /// </summary>
        public void PublicMethod()
        {
            Console.WriteLine("Public method: " + PublicField);
            AccessPrivateField();
            AccessProtectedField();
            AccessInternalField();
        }

        /// <summary>
        /// Private method to access and print the value of the private field.
        /// </summary>
        private void AccessPrivateField()
        {
            Console.WriteLine("Accessing private field: " + _privateField);
        }

        /// <summary>
        /// Protected method to access and print the value of the protected field.
        /// </summary>
        protected void AccessProtectedField()
        {
            Console.WriteLine("Accessing protected field: " + protectedField);
        }

        /// <summary>
        /// Internal method to access and print the value of the internal field.
        /// </summary>
        internal void AccessInternalField()
        {
            Console.WriteLine("Accessing internal field: " + internalField);
        }
    }

    #endregion

    #region Derived Class

    /// <summary>
    /// Derived class extending MyClass.
    /// </summary>
    public class DerivedClass : MyClass
    {
        /// <summary>
        /// Constructor of the derived class.
        /// </summary>
        public DerivedClass()
        {
            // Access protected field from the base class
            Console.WriteLine("Derived class accessing protected field: " + protectedField);
        }

        /// <summary>
        /// Public method in the derived class.
        /// </summary>
        public void DerivedMethod()
        {
            Console.WriteLine("Derived method in the derived class");
            AccessProtectedField(); // Accessing protected field from the base class
        }
    }

    #endregion


    /// <summary>
    /// Main program to demonstrate access modifiers.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to execute the program.
        /// </summary>
        static void Main()
        {
            // Create an instance of MyClass
            MyClass objMyClass = new MyClass();

            // Access public members
            Console.WriteLine("Accessing public field: " + objMyClass.PublicField);
            objMyClass.PublicMethod();

            // Create an instance of DerivedClass
            DerivedClass objDerivedClass = new DerivedClass();

            // Access public members from the base class
            Console.WriteLine("Accessing public field in the derived class: " + objDerivedClass.PublicField);
            objDerivedClass.PublicMethod();

            // Uncommenting the lines below will result in compilation errors
            // because privateField and internalField are not directly accessible here.

            // Console.WriteLine("Accessing private field in the derived class: " + objDerivedClass.privateField);
            // Console.WriteLine("Accessing internal field in the derived class: " + objDerivedClass.internalField);
        }
    }
}





