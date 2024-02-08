namespace CalculatorClient
{
    /// <summary>
    /// Extension class to add a multiply method to the Calculator class.
    /// </summary>
    public static class ExtensionClass
    {
        /// <summary>
        /// Extension method to multiply two integers.
        /// </summary>
        /// <param name="obj">Instance of the Calculator class.</param>
        /// <param name="x">First integer operand.</param>
        /// <param name="y">Second integer operand.</param>
        /// <returns>The result of multiplying the two integers.</returns>
        public static int Multiply(this CalculatorLibrary.Calculator obj, int x, int y)
        {
            // Multiply the two integers
            return x * y;
        }
    }
}
