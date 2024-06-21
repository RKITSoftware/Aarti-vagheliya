using System;

namespace GenericListDemo
{
    /// <summary>
    /// Represents a custom generic list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    class CustomGenericList<T> 
    {
        #region Private Node Class
        
        /// <summary>
        /// Inner class representing a node in the list
        /// </summary>
        private class Node
        {
            #region Constructor

            /// <summary>
            /// Constructor initialize Node, data and null pointer.
            /// </summary>
            /// <param name="data"></param>
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
            #endregion

            #region Public Member

            /// <summary>
            /// Represents the data stored in the node.
            /// </summary>
            public T Data { get; }

            /// <summary>
            /// Represents the reference to the next node in the linked list.
            /// </summary>
            public Node Next { get; set; }

            #endregion
        }

        #endregion

        #region  Private Member

        // Private instance of Node class.
        private Node head;

        #endregion

        #region Constructors

        // Constructor
        /// <summary>
        /// Initializes a new instance of the CustomGenericList class.
        /// </summary>
        public CustomGenericList()
        {
            head = null;
        }

        #endregion

        #region Public Methods

        #region AddFirst

        /// <summary>
        /// Adds an element to the beginning of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        public void AddFirst(T data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        #endregion

        #region AddLast

        /// <summary>
        /// Adds an element to the end of the list.
        /// </summary>
        /// <param name="data">The data to add.</param>
        public void AddLast(T data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        #endregion

        #region RemoveFirst

        /// <summary>
        /// Removes the first element from the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }

        #endregion

        #region RemoveLast

        /// <summary>
        /// Removes the last element from the list.
        /// </summary>
        public void RemoveLast()
        {
            if (head == null)
            {
                return;
            }
            else if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        #endregion

        #region Traverse

        /// <summary>
        /// Traverses the list and prints its elements.
        /// </summary>
        public void Traverse()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        #endregion

        #region AddPosition

        /// <summary>
        /// Adds an element at a specific position in the list.
        /// </summary>
        /// <param name="position">The position at which to add the element.</param>
        /// <param name="data">The data to add.</param>
        public void AddPosition(int position, T data)
        {
            try
            {
                if (position < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");
                }

                if (position == 0)
                {
                    // Add at the beginning of the list
                    AddFirst(data);
                }
                else
                {
                    // Traverse to the position before the insertion point
                    Node current = head;
                    for (int i = 0; i < position - 1 && current != null; i++)
                    {
                        current = current.Next;
                    }

                    if (current == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                    }

                    // Insert the new node after the current position
                    Node newNode = new Node(data);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Console.WriteLine("{0} added to the list.", data);
                }
            
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region RemoveAt

        /// <summary>
        /// Removes an element at a specific position from the list.
        /// </summary>
        /// <param name="position">The position of the element to remove.</param>
        public void RemoveAt(int position)
        {
            try
            {

                if (position < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");
                }

                if (head == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }

                if (position == 0)
                {
                    // Remove the first element
                    head = head.Next;
                }
                else
                {
                    // Traverse to the position before the node to be removed
                    Node current = head;
                    for (int i = 0; i < position - 1 && current.Next != null; i++)
                    {
                        current = current.Next;
                    }

                    if (current.Next == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                    }

                    // Remove the node at the specified position
                    current.Next = current.Next.Next;
                    Console.WriteLine("Element removed from the list.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}
