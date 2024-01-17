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

    }
}
