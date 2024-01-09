using System;

namespace EnumDemo
{
    /// <summary>
    /// Represents different types of weather with a creative twist.
    /// </summary>
    public enum CreativeWeather
    {
        Sunny,
        Rainy,
        Snowy,
        Thunderstorm,
        Foggy,
        Windy
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Enum Demo
            EnumDemo();
            #endregion
        }

        /// <summary>
        /// Demonstrates the usage of the CreativeWeather enum.
        /// </summary>
        static void EnumDemo()
        {
            Console.WriteLine("Enum Demo:");

            // Get today's creative weather
            CreativeWeather todayWeather = GetCreativeWeather();

            Console.WriteLine($"Today's weather is {todayWeather}!");

            // Plan activities based on the weather
            PlanForTheWeather(todayWeather);

            Console.WriteLine();
        }

        /// <summary>
        /// Simulates selecting creative weather randomly.
        /// </summary>
        /// <returns>A randomly selected creative weather.</returns>
        static CreativeWeather GetCreativeWeather()
        {
            Random random = new Random();
            int weatherIndex = random.Next(0, Enum.GetNames(typeof(CreativeWeather)).Length);
            return (CreativeWeather)weatherIndex;
        }

        /// <summary>
        /// Plans activities based on the creative weather.
        /// </summary>
        /// <param name="weather">The creative weather.</param>
        static void PlanForTheWeather(CreativeWeather weather)
        {
            switch (weather)
            {
                case CreativeWeather.Sunny:
                    Console.WriteLine("Perfect day for outdoor activities under the sun!");
                    break;
                case CreativeWeather.Rainy:
                    Console.WriteLine("A rainy day, ideal for cozy indoor activities.");
                    break;
                case CreativeWeather.Snowy:
                    Console.WriteLine("Enjoy the snowy landscape and build a snowman!");
                    break;
                case CreativeWeather.Thunderstorm:
                    Console.WriteLine("Stay indoors and enjoy the sound of thunderstorms.");
                    break;
                case CreativeWeather.Foggy:
                    Console.WriteLine("A mysterious and foggy day – perfect for reflection.");
                    break;
                case CreativeWeather.Windy:
                    Console.WriteLine("Embrace the wind and fly a kite!");
                    break;
                default:
                    Console.WriteLine("No specific plans for today. Enjoy the creative weather!");
                    break;
            }
        }
    }
}
