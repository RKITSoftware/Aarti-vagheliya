using System;

namespace GenericListDemo
{
    /// <summary>
    /// Represents a class for demonstrating operations on a list of integers.
    /// </summary>
    class IntegerTypeList
    {
        /// <summary>
        /// Runs the integer type list demo.
        /// </summary>
        public void RunIntegerTypeList()
        {
            // Create an instance of CustomGenericList with int type
            CustomGenericList<int> list = new CustomGenericList<int>();

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add an integer to the starting of the list");
                Console.WriteLine("2. Add an integer to the end of the list");
                Console.WriteLine("3. Remove the first element from the list");
                Console.WriteLine("4. Remove the last element from the list");
                Console.WriteLine("5. Add element at specified position the list");
                Console.WriteLine("6. Remove from specified position of the list");
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
                        Console.Write("Enter an integer to add to the list: ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            list.AddFirst(value);
                            Console.WriteLine("Integer added to the list.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter an integer.");
                        }
                        break;
                    case 2:
                        Console.Write("Enter an integer to add to the list: ");
                        if (int.TryParse(Console.ReadLine(), out int item))
                        {
                            list.AddLast(item);
                            Console.WriteLine("Integer added to the list.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter an integer.");
                        }
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
                        Console.Write("Enter element to add at specified position.");
                        int element = int.Parse(Console.ReadLine());
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
