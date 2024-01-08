using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Single Inheritance
            SingleInheritance.SingleInheritanceRun();
            #endregion

            #region Multilevel Inheritance
            MultiLevelInheritance.MultiLevelInheritanceRun();
            #endregion

            #region Hierarchical Inheritance
            HierarchicalInheritance.HierarchicalInheritanceRun();
            #endregion

            #region Hybrid Inheritance
            HybridInheritance.HybridInheritanceRun();
            #endregion
        }
    }
}
