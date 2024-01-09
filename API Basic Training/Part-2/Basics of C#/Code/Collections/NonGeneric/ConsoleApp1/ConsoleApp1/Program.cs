using System;
using System.Collections;

namespace NonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList Demo
            ArrayListDemo();
            #endregion

            #region Queue Demo
            QueueDemo();
            #endregion

            #region Stack Demo
            StackDemo();
            #endregion

            #region Hashtable Demo
            HashtableDemo();
            #endregion
        }

        #region ArrayList Demo
        /// <summary>
        /// Demonstration of ArrayList.
        /// </summary>
        static void ArrayListDemo()
        {
            Console.WriteLine("ArrayList Demo:");
            ArrayList arrayList = new ArrayList();

            // Adding elements
            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.14);

            // Displaying elements
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        #endregion

        #region Queue Demo
        /// <summary>
        /// Demonstration of Queue.
        /// </summary>
        static void QueueDemo()
        {
            Console.WriteLine("Queue Demo:");
            Queue queue = new Queue();

            // Enqueue elements
            queue.Enqueue(10);
            queue.Enqueue("World");

            // Dequeue and display elements
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine();
        }
        #endregion

        #region Stack Demo
        /// <summary>
        /// Demonstration of Stack.
        /// </summary>
        static void StackDemo()
        {
            Console.WriteLine("Stack Demo:");
            Stack stack = new Stack();

            // Push elements
            stack.Push(5);
            stack.Push("C#");

            // Pop and display elements
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine();
        }
        #endregion

        #region Hashtable Demo
        /// <summary>
        /// Demonstration of Hashtable.
        /// </summary>
        static void HashtableDemo()
        {
            Console.WriteLine("Hashtable Demo:");
            Hashtable hashtable = new Hashtable();

            // Add key-value pairs
            hashtable.Add("Name", "John");
            hashtable.Add("Age", 25);
            hashtable.Add("City", "New York");

            // Display key-value pairs
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine();
        }
        #endregion
    }
}
