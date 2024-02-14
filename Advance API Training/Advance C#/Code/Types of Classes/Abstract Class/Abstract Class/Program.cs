using System;


namespace Abstract_Class
{
    #region Abstract Class

    /// <summary>
    /// Abstract class representing a generic vehicle.
    /// </summary>
    public abstract class Vehicle
    {
        // Abstract method
        /// <summary>
        /// Abstract method to start the vehicle.
        /// </summary>
        public abstract void Start();

        // Non-abstract property
        /// <summary>
        /// Model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        // Abstract property
        /// <summary>
        /// Manufacturer of the vehicle.
        /// </summary>
        public abstract string Manufacturer { get; }

        // Constructor
        /// <summary>
        /// Constructor for the vehicle class.
        /// </summary>
        /// <param name="model">Model of the vehicle.</param>
        public Vehicle(string model)
        {
            Model = model;
            Console.WriteLine("Vehicle constructor called.");
        }

        // Destructor
        /// <summary>
        /// Destructor for the vehicle class.
        /// </summary>
        ~Vehicle()
        {
            Console.WriteLine("Vehicle destructor called.");
        }

        // Non-abstract method
        /// <summary>
        /// Displays information about the vehicle.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model}, Manufacturer: {Manufacturer}");
        }
    }

    #endregion

    #region  Derived class car

    // Derived class 1
    /// <summary>
    /// Concrete class representing a car.
    /// </summary>
    public class Car : Vehicle
    {
        // Constructor
        /// <summary>
        /// Constructor for the Car class.
        /// </summary>
        /// <param name="model">Model of the car.</param>
        /// <param name="manufacturer">Manufacturer of the car.</param>
        public Car(string model, string manufacturer) : base(model)
        {
            Manufacturer = manufacturer;
            Console.WriteLine("Car constructor called.");
        }

        // Implementation of abstract method
        /// <summary>
        /// Starts the car.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Car is starting.");
        }

        // Implementation of abstract property
        /// <summary>
        /// Manufacturer of the car.
        /// </summary>
        public override string Manufacturer { get; }
    }
    #endregion

    #region Derived class Motorcycle

    // Derived class 2
    /// <summary>
    /// Concrete class representing a motorcycle.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        // Constructor
        /// <summary>
        /// Constructor for the Motorcycle class.
        /// </summary>
        /// <param name="model">Model of the motorcycle.</param>
        /// <param name="manufacturer">Manufacturer of the motorcycle.</param>
        public Motorcycle(string model, string manufacturer) : base(model)
        {
            Manufacturer = manufacturer;
            Console.WriteLine("Motorcycle constructor called.");
        }

        // Implementation of abstract method
        /// <summary>
        /// Starts the motorcycle.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Motorcycle is starting.");
        }

        // Implementation of abstract property
        /// <summary>
        /// Manufacturer of the motorcycle.
        /// </summary>
        public override string Manufacturer { get; }
    }
    #endregion


    class Program
    {

        static void Main(string[] args)
        {
            // Creating instances of derived classes
            Car myCar = new Car("Civic", "Honda");
            Motorcycle myMotorcycle = new Motorcycle("Ninja", "Kawasaki");

            // Calling abstract method and non-abstract method
            myCar.Start();
            myCar.DisplayInfo();

            Console.WriteLine();

            myMotorcycle.Start();
            myMotorcycle.DisplayInfo();

            // Note: Destructors are automatically called by the garbage collector, so we don't explicitly call them here.

            Console.ReadLine();
        }
    }
}
