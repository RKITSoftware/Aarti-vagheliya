using System;
using System.Collections.Generic;

namespace CustomStackLibrary
{
    /// <summary>
    /// Represents a generic stack data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public class CustomStack<T>
    {
        #region Fields

        private List<T> stack;

        #endregion

        #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomStack{T}"/> class.
            /// </summary>  
            public CustomStack()
            {
                stack = new List<T>();
            }

            #endregion

        #region Public Methods

            #region Push

            /// <summary>
            /// Pushes an item onto the stack.
            /// </summary>
            /// <param name="item">The item to push onto the stack.</param> 
            public void Push(T item)
            {
                stack.Add(item);
            }

             #endregion

            #region Pop

            /// <summary>
            /// Removes and returns the item at the top of the stack.
            /// </summary>
            /// <returns>The item at the top of the stack.</returns>
            public T Pop()
            {
                if (stack.Count == 0)
                {
                    throw new InvalidOperationException("The stack is empty.");
                }

                T item = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return item;
            }
            #endregion

            #region Peek

            /// <summary>
            /// Returns the item at the top of the stack without removing it.
            /// </summary>
            /// <returns>The item at the top of the stack.</returns>
            public T Peek()
            {
                if (stack.Count == 0)
                {
                    throw new InvalidOperationException("The stack is empty.");
                }

                return stack[stack.Count - 1];
            }

            #endregion

            #region Count
            /// <summary>
            /// Gets the number of elements contained in the stack.
            /// </summary>
            public int Count
            {
                get { return stack.Count; }
            }
             #endregion

            #region Clear
            /// <summary>
            /// Removes all elements from the stack.
            /// </summary>
            public void Clear()
            {
                stack.Clear();
            }

            #endregion

        #endregion
    }
}


