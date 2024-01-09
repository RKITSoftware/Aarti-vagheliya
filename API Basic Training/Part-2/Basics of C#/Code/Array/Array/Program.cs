using System;

namespace Array
{
    /// <summary>
    /// This program demonstrates different types of arrays and array methods in C#.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Single-Dimentional Array
            //Single-dimensional Array
            string[] cars = { "Volvo", "BMW", "Ford", "KIA" };
            Console.WriteLine("Output of 1D Array..");
            Console.WriteLine(cars[0]);
            Console.WriteLine(cars[1]);
            Console.WriteLine(cars[2]);
            Console.WriteLine(cars[3]);
            Console.WriteLine();
            #endregion

            #region Two-Dimentional Array
            //Two-dimensional Array
            int[,] a = new int[3, 4] 
            {   {1,2,3,4 },
                {2,3,4,5},
                {3,4,5,6},
            };

            Console.WriteLine("Output of 2D Array..");
            Console.WriteLine(a[0,0]);
            Console.WriteLine(a[2,0]);
            Console.WriteLine(a[2,3]);
            Console.WriteLine();
            #endregion

            #region Three-Dimentional Array
            //Three-dimensional array
            int[,,] b = new int[3, 3, 2]
            {
                { {1,2}, { 2,3}, { 3,4} },
                { {4,5 },{5,6 },{6,7 } },
                { {7,8 },{8,9 },{9,10 } }
            };

            Console.WriteLine("Output of 3D Array..");
            Console.WriteLine(b[0,0,0]);
            Console.WriteLine(b[1,1,1]);
            Console.WriteLine(b[2,2,1]);
            Console.WriteLine(b[2,1,0]);
            Console.WriteLine();
            #endregion

            #region Jagged Array
            //Jagged array
            int[][] c = new int[3][];

            c[0] = new int[] { 1, 2, 3, 4,5 };
            c[1] = new int[] { 2, 3, 4 };
            c[2] = new int[] { 10, 12 };

            Console.WriteLine("Output of Jagged Array..");
            int ele1 = c[1][0];
            Console.WriteLine(ele1);
            Console.WriteLine(c[0][3]);
            Console.WriteLine(c[2][1]);
            Console.WriteLine();
            #endregion

            #region Array Methods
            //Array methods

            //length method
            Console.WriteLine("length of array 'a' = "+a.Length);

            //IndexOf method
            int index = System.Array.IndexOf(cars, "Ford");
            Console.WriteLine("Index of FOrd = "+index);

            //sort method 
            System.Array.Sort(cars);
            Console.WriteLine("Sorted elemnts..");
            foreach(string i in cars)
                Console.WriteLine(i);

            //reverse method
            System.Array.Reverse(cars);
            Console.WriteLine("Reversed elemnts..");
            foreach (string i in cars)
                Console.WriteLine(i);

            //copy method
            string[] d = new string[4];
            System.Array.Copy(cars,0,d,0,cars.Length);
            Console.WriteLine("Copied element in d array..");
            foreach(string i in d)
            {
                Console.WriteLine(i);
            }

            //clone method
            int[] p = new int[4] { 10,20,30,40};
            int[] cloneArray = (int[])p.Clone();

            foreach(int i in cloneArray)
            {
                Console.WriteLine(i);
            }
            #endregion
        }
    }
}
