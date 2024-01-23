using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsDemo
{
    /// <summary>
    /// This program demonstrates the usage of various generic collections in C#.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Demonstrating List<T>
            ListDemo();

            // Demonstrating Dictionary<TKey, TValue>
            DictionaryDemo();

            // Demonstrating HashSet<T>
            HashSetDemo();

            // Demonstrating Queue<T>
            QueueDemo();

            // Demonstrating Stack<T>
            StackDemo();

            // Demonstrating LinkedList<T>
            LinkedListDemo();

            // Demonstrating SortedDictionary<TKey, TValue>
            SortedDictionaryDemo();

            // Demonstrating SortedSet<T>
            SortedSetDemo();

            //DEmonstrate List iside List
            ListInList();

            // Demonstrate Dictionary inside Dictionary
            NestedDictionaryDemo();

            // Demonstrate dictionary with List
            DictionaryWithListDemo();

            // NestedDictionaryListDemo
            NestedDictionaryListDemo();

            //NestedDictionaryWithListDemo
            NestedDictionaryWithListDemo();
        }

        #region List<T> Demo

        /// <summary>
        /// Demonstrates the usage of List<T>.
        /// </summary>
        static void ListDemo()
        {
            Console.WriteLine("List<T> Demo:");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Adding elements
            numbers.Add(6);

            // Removing elements
            numbers.Remove(3);

            // Accessing elements
            Console.WriteLine("List Elements:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Number of elements in the list: {numbers.Count}");
            Console.WriteLine();
        }

        #endregion

        #region Dictionary<TKey, TValue> Demo

        /// <summary>
        /// Demonstrates the usage of Dictionary<TKey, TValue>.
        /// </summary>
        static void DictionaryDemo()
        {
            Console.WriteLine("Dictionary<TKey, TValue> Demo:");

            Dictionary<string, int> ageDictionary = new Dictionary<string, int>
            {
                { "Alice", 25 },
                { "Bob", 30 },
                { "Charlie", 22 }
            };

            // Adding elements
            ageDictionary.Add("David", 28);

            // Removing elements
            ageDictionary.Remove("Bob");

            // Accessing elements
            Console.WriteLine("Dictionary Elements:");
            foreach (var kvp in ageDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} years old");
            }

            Console.WriteLine($"Number of elements in the dictionary: {ageDictionary.Count}");
            Console.WriteLine();
        }

        #endregion

        #region HashSet<T> Demo

        /// <summary>
        /// Demonstrates the usage of HashSet<T>.
        /// </summary>
        static void HashSetDemo()
        {
            Console.WriteLine("HashSet<T> Demo:");

            HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            // Adding elements
            uniqueNumbers.Add(6);

            // Removing elements
            uniqueNumbers.Remove(3);

            // Accessing elements
            Console.WriteLine("HashSet Elements:");
            foreach (var number in uniqueNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Number of elements in the hash set: {uniqueNumbers.Count}");
            Console.WriteLine();
        }

        #endregion

        #region Queue<T> Demo

        /// <summary>
        /// Demonstrates the usage of Queue<T>.
        /// </summary>
        static void QueueDemo()
        {
            Console.WriteLine("Queue<T> Demo:");

            Queue<string> tasks = new Queue<string>();

            // Enqueue elements
            tasks.Enqueue("Task 1");
            tasks.Enqueue("Task 2");
            tasks.Enqueue("Task 3");

            // Dequeue element
            string currentTask = tasks.Dequeue();
            Console.WriteLine($"Currently processing: {currentTask}");

            Console.WriteLine($"Number of elements in the queue: {tasks.Count}");
            Console.WriteLine();
        }

        #endregion

        #region Stack<T> Demo

        /// <summary>
        /// Demonstrates the usage of Stack<T>.
        /// </summary>
        private static void StackDemo()
        {
            Console.WriteLine("Stack<T> Demo:");

            Stack<double> numbers = new Stack<double>();

            // Push elements
            numbers.Push(1.1);
            numbers.Push(2.2);
            numbers.Push(3.3);

            // Pop element
            double lastNumber = numbers.Pop();
            Console.WriteLine($"Last popped number: {lastNumber}");

            Console.WriteLine($"Number of elements in the stack: {numbers.Count}");
            Console.WriteLine();
        }

        #endregion

        #region LinkedList<T> Demo

        /// <summary>
        /// Demonstrates the usage of LinkedList<T>.
        /// </summary>
        static void LinkedListDemo()
        {
            Console.WriteLine("LinkedList<T> Demo:");

            LinkedList<char> characters = new LinkedList<char>();

            // AddFirst
            characters.AddFirst('C');
            characters.AddFirst('B');
            characters.AddFirst('A');

            // AddLast
            characters.AddLast('D');

            // RemoveFirst
            characters.RemoveFirst();

            // RemoveLast
            characters.RemoveLast();

            // Accessing elements
            Console.WriteLine("LinkedList Elements:");
            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }

            Console.WriteLine($"Number of elements in the linked list: {characters.Count}");
            Console.WriteLine();
        }

        #endregion

        #region SortedDictionary<TKey, TValue> Demo

        /// <summary>
        /// Demonstrates the usage of SortedDictionary<TKey, TValue>.
        /// </summary>
        static void SortedDictionaryDemo()
        {
            Console.WriteLine("SortedDictionary<TKey, TValue> Demo:");

            SortedDictionary<string, int> sortedAges = new SortedDictionary<string, int>
            {
                { "Alice", 25 },
                { "Bob", 30 },
                { "Charlie", 22 }
            };

            // Adding elements
            sortedAges.Add("David", 28);

            // Removing elements
            sortedAges.Remove("Bob");

            // Accessing elements
            Console.WriteLine("SortedDictionary Elements:");
            foreach (var kvp in sortedAges)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} years old");
            }

            Console.WriteLine($"Number of elements in the sorted dictionary: {sortedAges.Count}");
            Console.WriteLine();
        }

        #endregion

        #region SortedSet<T> Demo

        /// <summary>
        /// Demonstrates the usage of SortedSet<T>.
        /// </summary>
        private static void SortedSetDemo()
        {
            Console.WriteLine("SortedSet<T> Demo:");

            SortedSet<double> sortedNumbers = new SortedSet<double> { 3.3, 1.1, 2.2, 4.4 };

            // Adding elements
            sortedNumbers.Add(5.5);

            // Removing elements
            sortedNumbers.Remove(2.2);

            // Accessing elements
            Console.WriteLine("SortedSet Elements:");
            foreach (var number in sortedNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"Number of elements in the sorted set: {sortedNumbers.Count}");
            Console.WriteLine();
        }

        #endregion

        #region ListINList Demo
        static void ListInList()
        {
            // Create a list of strings
            List<string> innerList1 = new List<string> { "Apple", "Banana", "Orange" };

            // Create another list of strings
            List<string> innerList2 = new List<string> { "Carrot", "Broccoli", "Spinach" };

            // Create a list of lists of strings
            List<List<string>> listOfLists = new List<List<string>> { innerList1, innerList2 };

            // Display the contents of the outer list
            foreach (var innerList in listOfLists)
            {
                Console.WriteLine("Inner List:");
                foreach (var item in innerList)
                {
                    Console.WriteLine($" - {item}");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region NestedDictionary Demo
        static void NestedDictionaryDemo()
        {
            Console.WriteLine("Nested Dictionary<TKey, TValue> Demo:");

            // Creating a Dictionary with string keys and values as dictionaries with int keys
            Dictionary<string, Dictionary<string, int>> nestedDictionary = new Dictionary<string, Dictionary<string, int>>
    {
        {
            "Alice", new Dictionary<string, int>
            {
                { "Math", 90 },
                { "History", 85 },
                { "English", 92 }
            }
        },
        {
            "Bob", new Dictionary<string, int>
            {
                { "Math", 88 },
                { "History", 78 },
                { "English", 95 }
            }
        },
        {
            "Charlie", new Dictionary<string, int>
            {
                { "Math", 92 },
                { "History", 80 },
                { "English", 88 }
            }
        }
    };

            // Adding a new entry
            nestedDictionary.Add("David", new Dictionary<string, int>
    {
        { "Math", 85 },
        { "History", 75 },
        { "English", 80 }
    });

            // Accessing elements
            Console.WriteLine("Nested Dictionary Elements:");
            foreach (var outerKvp in nestedDictionary)
            {
                Console.WriteLine($"{outerKvp.Key}:");
                foreach (var innerKvp in outerKvp.Value)
                {
                    Console.WriteLine($"  {innerKvp.Key}: {innerKvp.Value}");
                }
            }

            Console.WriteLine($"Number of elements in the nested dictionary: {nestedDictionary.Count}");
            Console.WriteLine();
        }
        #endregion

        #region DictionaryWithList Demo
        static void DictionaryWithListDemo()
        {
            Console.WriteLine("Dictionary<TKey, List<TValue>> Demo:");

            // Creating a Dictionary with string keys and values as lists of integers
            Dictionary<string, List<int>> dictionaryWithList = new Dictionary<string, List<int>>
    {
        { "GroupA", new List<int> { 10, 20, 30 } },
        { "GroupB", new List<int> { 15, 25, 35 } },
        { "GroupC", new List<int> { 18, 28, 38 } }
    };

            // Adding a new entry
            dictionaryWithList.Add("GroupD", new List<int> { 22, 32, 42 });

            // Accessing elements
            Console.WriteLine("Dictionary with List Elements:");
            foreach (var kvp in dictionaryWithList)
            {
                Console.Write($"{kvp.Key}: ");
                foreach (var value in kvp.Value)
                {
                    Console.Write($"{value} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Number of elements in the dictionary: {dictionaryWithList.Count}");
            Console.WriteLine();
        }
        #endregion

        #region NestedDictionaryListDemo
        static void NestedDictionaryListDemo()
        {
            Console.WriteLine("Nested Dictionary Demo:");

            // Creating a Dictionary with string keys, where the value is a Dictionary<int, List<string>>
            Dictionary<string, Dictionary<int, List<string>>> nestedDictionary = new Dictionary<string, Dictionary<int, List<string>>>
    {
        {
            "Category1", new Dictionary<int, List<string>>
            {
                { 1, new List<string> { "Item1", "Item2", "Item3" } },
                { 2, new List<string> { "Item4", "Item5" } }
            }
        },
        {
            "Category2", new Dictionary<int, List<string>>
            {
                { 3, new List<string> { "Item6", "Item7" } },
                { 4, new List<string> { "Item8", "Item9", "Item10" } }
            }
        }
    };

            // Accessing elements
            foreach (var outerKvp in nestedDictionary)
            {
                Console.WriteLine($"Category: {outerKvp.Key}");
                foreach (var innerKvp in outerKvp.Value)
                {
                    Console.Write($"{innerKvp.Key}: ");
                    foreach (var value in innerKvp.Value)
                    {
                        Console.Write($"{value} ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"Number of elements in the nested dictionary: {nestedDictionary.Count}");
            Console.WriteLine();
        }
        #endregion

        #region NestedDictionaryWithListDemo
        static void NestedDictionaryWithListDemo()
        {
            Console.WriteLine("Nested Dictionary Demo:");

            // Creating a Dictionary with Dictionary key and List<int> value
            Dictionary<Dictionary<string, int>, List<int>> nestedDictionary = new Dictionary<Dictionary<string, int>, List<int>>
        {
            {
                new Dictionary<string, int>
                {
                    { "Key1", 1 },
                    { "Key2", 2 }
                },
                new List<int> { 10, 20, 30 }
            },
            {
                new Dictionary<string, int>
                {
                    { "Key3", 3 },
                    { "Key4", 4 }
                },
                new List<int> { 40, 50, 60 }
            }
        };

            // Accessing elements
            foreach (var outerKvp in nestedDictionary)
            {
                Console.WriteLine("Dictionary Key:");
                foreach (var innerKvp in outerKvp.Key)
                {
                    Console.WriteLine($"{innerKvp.Key}: {innerKvp.Value}");
                }

                Console.Write("List Values: ");
                foreach (var value in outerKvp.Value)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Number of elements in the nested dictionary: {nestedDictionary.Count}");
            Console.WriteLine();
        }
        #endregion
    }
}
