using System;

namespace CalculatorLibrary
{
    /// <summary>
    /// Represents a basic calculator with arithmetic operations.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="x">The first integer.</param>
        /// <param name="y">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Subtracts one integer from another.
        /// </summary>
        /// <param name="x">The first integer (minuend).</param>
        /// <param name="y">The second integer (subtrahend).</param>
        /// <returns>The result of subtracting the second integer from the first.</returns>
        public int Subtract(int x, int y)
        {
            return x - y;
        }

        /// <summary>
        /// Divides one integer by another.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor (must not be zero).</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="y"/> is zero.</exception>
        public int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return x / y;
        }
    }
}
