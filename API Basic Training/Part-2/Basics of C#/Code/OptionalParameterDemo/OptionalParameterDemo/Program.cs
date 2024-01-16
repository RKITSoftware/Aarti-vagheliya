using System;


namespace OptionalParameterDemo
{
    class BaseClass
    {
        public new void InheritedMethod(int requiredParam, string optionalParam1 = "Default1", int optionalParam2 = 10)
        {
            Console.WriteLine($"Required Parameter: {requiredParam}");
            Console.WriteLine($"Optional Parameter 1: {optionalParam1}");
            Console.WriteLine($"Optional Parameter 2: {optionalParam2}");
        }
    }

    class DerivedClass : BaseClass
    {
        // You can choose to override the method if needed
        //public new void InheritedMethod(int requiredParam, string optionalParam1 = "DerivedDefault1", int optionalParam2 = 20)
        //{
        //    // Additional logic for the derived class
        //}

        // Or you can add new methods with optional parameters
        public new void NewMethod(int requiredParam, string optionalParam1 = "NewDefault1", int optionalParam2 = 30)
        {
            Console.WriteLine($"Required Parameter: {requiredParam}");
            Console.WriteLine($"Optional Parameter 1: {optionalParam1}");
            Console.WriteLine($"Optional Parameter 2: {optionalParam2}");
        }
    }

    class Program
    {
        static void Main()
        {
            DerivedClass derivedInstance = new DerivedClass();

            // Inherited Method with default values
            derivedInstance.InheritedMethod(5);

            Console.WriteLine();

            // Inherited Method with custom values
            derivedInstance.InheritedMethod(15, "CustomValue");

            Console.WriteLine();

            // New Method with default values
            derivedInstance.NewMethod(25);

            Console.WriteLine();

            // New Method with custom values
            derivedInstance.NewMethod(35, "CustomNewValue");
        }
    }




}
