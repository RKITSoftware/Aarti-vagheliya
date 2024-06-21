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
        #region Private member

        //Private instance of List<T>
        private List<T> _stack;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStack{T}"/> class.
        /// </summary>  
        public CustomStack()
        {
            _stack = new List<T>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="item">The item to push onto the stack.</param> 
        public void Push(T item)
        {
            _stack.Add(item);
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        public T Pop()
        {
            if (_stack.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T item = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            return item;
        }

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        public T Peek()
        {
            if (_stack.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _stack[_stack.Count - 1];
        }

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count
        {
            get { return _stack.Count; }
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        public void Clear()
        {
            _stack.Clear();
        }

        #endregion
    }
}


