using System;

namespace GenericListDemo
{
    /// <summary>
    /// Represents a class for demonstrating operations on a list of strings.
    /// </summary>
    class StringTypeList
    {
        /// <summary>
        /// Runs the string type list demo.
        /// </summary>
        public void RunStringTypeList()
        {
            // Create an instance of CustomGenericList with string type
            CustomGenericList<string> list = new CustomGenericList<string>();

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add a string to the starting of the list");
                Console.WriteLine("2. Add a string to the end of the list");
                Console.WriteLine("3. Remove the first element from the list");
                Console.WriteLine("4. Remove the last element from the list");
                Console.WriteLine("5. Add element at specified position in the list");
                Console.WriteLine("6. Remove from specified position in the list");
                Console.WriteLine("7. Traverse the list");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a string to add to the list: ");
                        string valueToAdd = Console.ReadLine();
                        list.AddFirst(valueToAdd);
                        Console.WriteLine("String added to the list.");
                        break;
                    case 2:
                        Console.Write("Enter a string to add to the list: ");
                        string stringToAdd = Console.ReadLine();
                        list.AddLast(stringToAdd);
                        Console.WriteLine("String added to the list.");
                        break;
                    case 3:
                        list.RemoveFirst();
                        Console.WriteLine("First element removed from the list.");
                        break;
                    case 4:
                        list.RemoveLast();
                        Console.WriteLine("Last element removed from the list.");
                        break;
                    case 5:
                        Console.Write("Enter string to add at specified position: ");
                        string element = Console.ReadLine();
                        Console.Write("Enter position: ");
                        int position = int.Parse(Console.ReadLine());
                        list.AddPosition(position, element);
                       
                        break;
                    case 6:
                        Console.Write("Enter position to remove element from there: ");
                        int pos = int.Parse(Console.ReadLine());
                        list.RemoveAt(pos);
                       
                        break;
                    case 7:
                        Console.WriteLine("List elements:");
                        list.Traverse();
                        break;
                    case 8:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                        break;
                }

                Console.WriteLine(); // Add a newline for readability
            }
        }
    }
}
