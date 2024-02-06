using System;

namespace Static_Class
{
    /// <summary>
    /// Static class for converting temperatures between Celsius and Fahrenheit scales.
    /// </summary>
    public static class TemperatureConverter
    {
        /// <summary>
        /// Converts temperature from Celsius to Fahrenheit.
        /// </summary>
        /// <param name="temperatureCelsius">The temperature in Celsius.</param>
        /// <returns>The temperature in Fahrenheit.</returns>
        public static double CelsiusToFahrenheit(string temperatureCelsius)
        {
            // Convert argument to double for calculations.
            double celsius = Double.Parse(temperatureCelsius);

            // Convert Celsius to Fahrenheit.
            double fahrenheit = (celsius * 9 / 5) + 32;

            return fahrenheit;
        }


        /// <summary>
        /// Converts temperature from Fahrenheit to Celsius.
        /// </summary>
        /// <param name="temperatureFahrenheit">The temperature in Fahrenheit.</param>
        /// <returns>The temperature in Celsius.</returns>
        public static double FahrenheitToCelsius(string temperatureFahrenheit)
        {
            // Convert argument to double for calculations.
            double fahrenheit = Double.Parse(temperatureFahrenheit);

            // Convert Fahrenheit to Celsius.
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }
    }


    // Define the Program class
    /// <summary>
    /// Class containing the Main method, serving as the entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Please select the convertor direction");
            Console.WriteLine("1. From Celsius to Fahrenheit.");
            Console.WriteLine("2. From Fahrenheit to Celsius.");
            Console.Write(":");

            // Read user selection
            string selection = Console.ReadLine();
            double F, C = 0;

            switch (selection)
            {
                case "1": // Convert from Celsius to Fahrenheit
                    Console.Write("Please enter the Celsius temperature: ");
                    F = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine());
                    Console.WriteLine("Temperature in Fahrenheit: {0:F2}", F);
                    break;

                case "2": // Convert from Fahrenheit to Celsius
                    Console.Write("Please enter the Fahrenheit temperature: ");
                    C = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine());
                    Console.WriteLine("Temperature in Celsius: {0:F2}", C);
                    break;

                default: // Invalid selection
                    Console.WriteLine("Please select a convertor.");
                    break;
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
  
}
