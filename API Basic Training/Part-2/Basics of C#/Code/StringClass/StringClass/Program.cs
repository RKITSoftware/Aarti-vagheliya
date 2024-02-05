using System;
using System.Collections.Generic;

namespace StringClass
{
    /// <summary>
    /// This program demonstrate all the methods of String class
    /// </summary>
    class Program
    {
        #region Length Demo
        /// <summary>
        /// Demonstrates the Length property of the String class.
        /// </summary>
        static void LengthDemo()
        {
            Console.WriteLine("Length Demo:");
            string text = "Hello, World!";
            Console.WriteLine($"Length of the string: {text.Length}");
            Console.WriteLine();
        }
        #endregion

        #region Concatenation Demo
        /// <summary>
        /// Demonstrates string concatenation using the Concat method.
        /// </summary>
        static void ConcatenationDemo()
        {
            Console.WriteLine("Concatenation Demo:");
            string str1 = "Hello";
            string str2 = "World";
            string result = string.Concat(str1, "- ", str2, "!");
            Console.WriteLine($"Concatenated String: {result}");
            Console.WriteLine();
        }
        #endregion

        #region Remove Demo
        /// <summary>
        /// Demonstrates the Remove method of the String class.
        /// </summary>
        static void RemoveDemo()
        {
            Console.WriteLine("Remove Demo:");
            string original = "This is a sample text.";
            int startIndex = 5;
            int lengthToRemove = 7;

            string result = original.Remove(startIndex, lengthToRemove);

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"After Remove: {result}");
            Console.WriteLine();
        }
        #endregion

        #region Substring Demo
        /// <summary>
        /// Demonstrates the Substring method of the String class.
        /// </summary>
        static void SubstringDemo()
        {
            Console.WriteLine("Substring Demo:");
            string original = "Hello, World!";
            int startIndex = 7;
            int length = 5;

            string result = original.Substring(startIndex, length);

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Substring: {result}");
            Console.WriteLine();
        }
        #endregion

        #region ToUpper/ToLower Demo
        /// <summary>
        /// Demonstrates the ToUpper and ToLower methods of the String class.
        /// </summary>
        static void ToUpperToLowerDemo()
        {
            Console.WriteLine("ToUpper/ToLower Demo:");
            string text = "Hello, World!";
            string upperCase = text.ToUpper();
            string lowerCase = text.ToLower();

            Console.WriteLine($"Original: {text}");
            Console.WriteLine($"Upper Case: {upperCase}");
            Console.WriteLine($"Lower Case: {lowerCase}");
            Console.WriteLine();
        }
        #endregion

        #region Trim Demo
        /// <summary>
        /// Demonstrates the Trim method of the String class.
        /// </summary>
        static void TrimDemo()
        {
            Console.WriteLine("Trim Demo:");
            string text = "   Trim Me   ";
            string trimmed = text.Trim();

            Console.WriteLine($"Original: '{text}'");
            Console.WriteLine($"Trimmed: '{trimmed}'");
            Console.WriteLine();
        }
        #endregion

        #region Replace Demo
        /// <summary>
        /// Demonstrates the Replace method of the String class.
        /// </summary>
        static void ReplaceDemo()
        {
            Console.WriteLine("Replace Demo:");
            string original = "C# is fun!";
            string replaced = original.Replace("fun", "awesome");

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Replaced: {replaced}");
            Console.WriteLine();
        }
        #endregion

        #region Split Demo
        /// <summary>
        /// Demonstrates the Split method of the String class.
        /// </summary>
        static void SplitDemo()
        {
            Console.WriteLine("Split Demo:");
            string data = "apple,orange,banana";
            string[] fruits = data.Split(',');

            Console.WriteLine($"Original: {data}");
            Console.WriteLine("Split Result:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
            Console.WriteLine();
        }
        #endregion

        #region Format Demo
        /// <summary>
        /// Demonstrates the Format method of the String class.
        /// </summary>
        static void FormatDemo()
        {
            Console.WriteLine("Format Demo:");
            string formatted = string.Format("The value is: {0}", 42);

            Console.WriteLine($"Formatted: {formatted}");
            Console.WriteLine();
        }
        #endregion

        #region Join Demo
        /// <summary>
        /// Demonstrates the Join method of the String class.
        /// </summary>
        static void JoinDemo()
        {
            Console.WriteLine("Join Demo:");
            string[] words = { "Hello", "World", "C#" };
            string joined = string.Join(" ", words);

            Console.WriteLine($"Original Array: {string.Join(", ", words)}");
            Console.WriteLine($"Joined String: {joined}");
            Console.WriteLine();
        }
        #endregion

        #region PadLeft/PadRight Demo
        /// <summary>
        /// Demonstrates the PadLeft and PadRight methods of the String class.
        /// </summary>
        static void PadLeftRightDemo()
        {
            Console.WriteLine("PadLeft/PadRight Demo:");
            string original = "123";
            string paddedLeft = original.PadLeft(5, '0');
            string paddedRight = original.PadRight(5, '*');

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Padded Left: {paddedLeft}");
            Console.WriteLine($"Padded Right: {paddedRight}");
            Console.WriteLine();
        }
        #endregion

        #region Insert Demo
        /// <summary>
        /// Demonstrates the Insert method of the String class.
        /// </summary>
        static void InsertDemo()
        {
            Console.WriteLine("Insert Demo:");
            string original = "C# programming";
            string inserted = original.Insert(2, "Sharp ");

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Inserted: {inserted}");
            Console.WriteLine();
        }
        #endregion


        static void StringToListAndListToString()
        {
            // Convert string to list of strings
            string inputString = "apple,orange,banana";
            List<string> stringList = ConvertStringToList(inputString);

            // Display the list elements
            Console.WriteLine("List elements:");
            foreach (var item in stringList)
            {
                Console.WriteLine(item);
            }

            // Convert list of strings to a single string
            string outputString = ConvertListToString(stringList);

            // Display the concatenated string
            Console.WriteLine("\nConcatenated String:");
            Console.WriteLine(outputString);

            Console.ReadLine();
        }

        // Function to convert a string to a list of strings
        static List<string> ConvertStringToList(string input)
        {
            return new List<string>(input.Split(','));
        }

        // Function to convert a list of strings to a single string
        static string ConvertListToString(List<string> inputList)
        {
            return string.Join(":", inputList);
        }
    

        static void Main(string[] args)
        {
            #region Length Demo
            LengthDemo();
            #endregion

            #region Concatenation Demo
            ConcatenationDemo();
            #endregion

            #region Substring Demo
            SubstringDemo();
            #endregion

            #region ToUpper/ToLower Demo
            ToUpperToLowerDemo();
            #endregion

            #region Trim Demo
            TrimDemo();
            #endregion

            #region Replace Demo
            ReplaceDemo();
            #endregion

            #region Split Demo
            SplitDemo();
            #endregion

            #region Format Demo
            FormatDemo();
            #endregion

            #region Join Demo
            JoinDemo();
            #endregion

            #region PadLeft/PadRight Demo
            PadLeftRightDemo();
            #endregion

            #region Insert Demo
            InsertDemo();
            #endregion

            #region Remove Demo
            RemoveDemo();
            #endregion

            StringToListAndListToString();
        }
    
    }
}
