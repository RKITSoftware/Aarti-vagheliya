using System;

namespace GenericListDemo
{
    /// <summary>
    /// Represents the main program class for the generic list demo.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Create instances of StringTypeList and IntegerTypeList
            StringTypeList objStringList = new StringTypeList();
            IntegerTypeList objIntegerList = new IntegerTypeList();

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Work with Integer Type.");
                Console.WriteLine("2. Work with String type.");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Work with Integer Type
                        Console.WriteLine("\nWelcome to the Integer Type demo...!!");
                        objIntegerList.RunIntegerTypeList();
                        break;
                    case 2: // Work with String Type
                        Console.WriteLine("\nWelcome to the String Type demo...!!");
                        objStringList.RunStringTypeList();
                        break;
                    case 3: // Exit the program
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
        }
    }
}
