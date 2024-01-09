using System;


namespace Inheritance
{
    /// <summary>
    /// Main program class for demonstrating different types of inheritance.
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
            // Demonstrating Single Inheritance
            #region Single Inheritance
            SingleInheritance.SingleInheritanceRun();
            #endregion

            // Demonstrating Multilevel Inheritance
            #region Multilevel Inheritance
            MultiLevelInheritance.MultiLevelInheritanceRun();
            #endregion

            // Demonstrating Hierarchical Inheritance
            #region Hierarchical Inheritance
            HierarchicalInheritance.HierarchicalInheritanceRun();
            #endregion

            // Demonstrating Hybrid Inheritance
            #region Hybrid Inheritance
            HybridInheritance.HybridInheritanceRun();
            #endregion
        }
        #endregion
    }
}
