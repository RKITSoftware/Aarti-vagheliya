namespace SerializationDemo
{
    /// <summary>
    /// Represents a program for demonstrating serialization and deserialization.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            //Instace of Serialization class.
            Serialization objSerialization = new Serialization();

            objSerialization.JSONSerialization();

            objSerialization.JSONDeserialization();

            objSerialization.XMLSerialization();

            objSerialization.XMLDeserialization();

        }

       
    }
}
