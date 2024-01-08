using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class GermanShepherd : Dog
    {
        public void Guard()
        {
            Console.WriteLine("German Shepherd is guarding.");
        }
    }

    class MultiLevelInheritance
    {
        public static void MultiLevelInheritanceRun()
        {
            GermanShepherd germanShepherd = new GermanShepherd();
            germanShepherd.Eat();
            germanShepherd.Bark();
            germanShepherd.Guard();

            Console.WriteLine();
        }
    }
}
