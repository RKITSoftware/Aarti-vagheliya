using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedClass
{
    sealed class Demo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
      
            int ans = demo.Add(1, 2);
            Console.WriteLine(ans);
        }
    }
}
