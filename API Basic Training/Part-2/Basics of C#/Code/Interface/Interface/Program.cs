using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IVehicle
    {
        string model { get; set; }
        void Start();
        void Stop();
        void Drive();
    }

    class Car : IVehicle
    {
        private string _model;

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

        public void Start()
        {
            Console.WriteLine("Car is starting.");
        }

        public void Stop()
        {
            Console.WriteLine("Car is stopped.");
        }

        public void Drive()
        {
            Console.WriteLine("Car's Drive method is calling.");
        }
    }

    class Bike : IVehicle
    {
        private string _model;

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
        public void Start()
        {
            Console.WriteLine("Bike is starting.");
        }

        public void Stop()
        {
            Console.WriteLine("Bike is stopped.");
        }

        public void Drive()
        {
            Console.WriteLine("Bike's Drive method is calling.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car();
            IVehicle bike = new Bike();

            car.Start();
            car.Stop();
            car.Drive();
            Console.Write("Enter model of car: ");
            car.model = Console.ReadLine();
            Console.WriteLine($"Model : {car.model}");

            Console.WriteLine();

            bike.Start();
            bike.Drive();
            bike.Stop();
            Console.Write("Enter model of Bike: ");
            car.model = Console.ReadLine();
            Console.WriteLine($"Model : {bike.model}");

        }
    }
}
