using System;


namespace Interface
{
    /// <summary>
    /// Interface representing a general vehicle.
    /// </summary>
    interface IVehicle
    {
        #region Property and Methods
        string model { get; set; }
        void Start();
        void Stop();
        void Drive();
        #endregion
    }

    /// <summary>
    /// Car class implementing the IVehicle interface.
    /// </summary>
    class Car : IVehicle
    {
        #region Private Members
        private string _model;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the model of the car.
        /// </summary>
        public string model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;
                }
                else
                {
                    Console.WriteLine("Invalid model name..!!");
                }
            }
        }
        #endregion

        #region Public Methods
        //Implement Start method
        public void Start()
        {
            Console.WriteLine("Car is starting.");
        }

        //Implement Stop method
        public void Stop()
        {
            Console.WriteLine("Car is stopped.");
        }

        //Implement Drive method
        public void Drive()
        {
            Console.WriteLine("Car's Drive method is calling.");
        }
        #endregion
    }

    /// <summary>
    /// Bike class implementing the IVehicle interface.
    /// </summary>
    class Bike : IVehicle
    {
        #region Private Members
        private string _model;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the model of the bike.
        /// </summary>
        public string model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;
                }
                else
                {
                    Console.WriteLine("Invalid model name..!!");
                }
            }
        }
        #endregion

        #region Public Properties
        //Implement Start method
        public void Start()
        {
            Console.WriteLine("Bike is starting.");
        }

        //Implement Stop method
        public void Stop()
        {
            Console.WriteLine("Bike is stopped.");
        }

        //Implement Drive method
        public void Drive()
        {
            Console.WriteLine("Bike's Drive method is calling.");
        }
        #endregion
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program
    {
        #region Main Method
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Creating instances of vehicles
            IVehicle objCar = new Car();
            IVehicle objBike = new Bike();

            // Using methods and properties of the interface
            objCar.Start();
            objCar.Stop();
            objCar.Drive();
            Console.Write("Enter model of car: ");
            objCar.model = Console.ReadLine();
            Console.WriteLine($"Model : {objCar.model}");

            Console.WriteLine();

            objBike.Start();
            objBike.Drive();
            objBike.Stop();
            Console.Write("Enter model of Bike: ");
            objBike.model = Console.ReadLine();
            Console.WriteLine($"Model : {objBike.model}");

        }
        #endregion
    }
}
