using System;


namespace DateTimeClass
{

    class Program
    {
        #region DateTime Basics Demo
        /// <summary>
        /// Demonstrates basic usage of DateTime class.
        /// </summary>
        static void DateTimeBasicsDemo()
        {
            Console.WriteLine("DateTime Basics Demo:");

            // Current date and time
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current DateTime: {now}");

            // Specific date and time
            DateTime specificDate = new DateTime(2022, 5, 15, 12, 30, 0);
            Console.WriteLine($"Specific DateTime: {specificDate}");

            // Date and time components
            Console.WriteLine($"Year: {now.Year}, Month: {now.Month}, Day: {now.Day}");
            Console.WriteLine($"Hour: {now.Hour}, Minute: {now.Minute}, Second: {now.Second}");

            Console.WriteLine();
        }
        #endregion

        #region DateTime Formatting Demo
        /// <summary>
        /// Demonstrates formatting DateTime to a string.
        /// </summary>
        static void DateTimeFormattingDemo()
        {
            Console.WriteLine("DateTime Formatting Demo:");

            DateTime now = DateTime.Now;

            // Standard date and time formats
            Console.WriteLine($"Short Date String: {now.ToShortDateString()}");
            Console.WriteLine($"Long Date String: {now.ToLongDateString()}");
            Console.WriteLine($"Short Time String: {now.ToShortTimeString()}");
            Console.WriteLine($"Long Time String: {now.ToLongTimeString()}");

            // Custom date and time format
            string customFormat = now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"Custom Format: {customFormat}");

            Console.WriteLine();
        }
        #endregion

        #region DateTime Arithmetic Demo
        /// <summary>
        /// Demonstrates DateTime arithmetic.
        /// </summary>
        static void DateTimeArithmeticDemo()
        {
            Console.WriteLine("DateTime Arithmetic Demo:");

            //Add 10 days in today
            DateTime today = DateTime.Today;
            DateTime futureDate = today.AddDays(10);

            Console.WriteLine($"Today: {today}");
            Console.WriteLine($"Date after 10 days: {futureDate}");

            // Calculate age
            DateTime birthdate = new DateTime(2002, 9, 25);
            TimeSpan age = today - birthdate;
            Console.WriteLine($"Age: {age.Days / 365} years");

            Console.WriteLine();
        }
        #endregion

        #region DateTime Methods Demo
        /// <summary>
        /// Demonstrates additional methods of the DateTime class.
        /// </summary>
        static void DateTimeMethodsDemo()
        {
            Console.WriteLine("DateTime Methods Demo:");

            // Creating DateTime objects
            DateTime now = DateTime.Now;
            DateTime today = DateTime.Today;
            DateTime specificDate = new DateTime(2022, 5, 15, 12, 30, 0);

            // Adding and subtracting time intervals
            DateTime futureDate = now.AddHours(48);
            DateTime pastDate = now.AddMonths(-1);

            // Comparing dates
            bool isSameDate = (today == specificDate);
            bool isBefore = (now < futureDate);
            bool isAfter = (now > pastDate);

            // Extracting components
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            // Getting date and time components separately
            DateTime datePart = now.Date;
            TimeSpan timePart = now.TimeOfDay;

            // Checking for leap year
            bool isLeapYear = DateTime.IsLeapYear(year);

            // Parsing strings to DateTime
            string dateString = "2023-08-21";
            DateTime parsedDate = DateTime.Parse(dateString);

            Console.WriteLine($"Now: {now}");
            Console.WriteLine($"Future Date: {futureDate}");
            Console.WriteLine($"Past Date: {pastDate}");
            Console.WriteLine($"Is Same Date: {isSameDate}");
            Console.WriteLine($"Is Before: {isBefore}");
            Console.WriteLine($"Is After: {isAfter}");
            Console.WriteLine($"Year: {year}, Month: {month}, Day: {day}");
            Console.WriteLine($"Hour: {hour}, Minute: {minute}, Second: {second}");
            Console.WriteLine($"Date Part: {datePart}, Time Part: {timePart}");
            Console.WriteLine($"Is Leap Year: {isLeapYear}");
            Console.WriteLine($"Parsed Date: {parsedDate}");

            Console.WriteLine();
        }
        #endregion

        static void Main(string[] args)
        {
            #region DateTime Basics Demo
            DateTimeBasicsDemo();
            #endregion

            #region DateTime Formatting Demo
            DateTimeFormattingDemo();
            #endregion

            #region DateTime Arithmetic Demo
            DateTimeArithmeticDemo();
            #endregion

            #region DateTime Methods Demo
            DateTimeMethodsDemo();
            #endregion
        }
    }
}
