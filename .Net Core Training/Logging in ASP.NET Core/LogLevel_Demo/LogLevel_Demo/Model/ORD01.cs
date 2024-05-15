using LogLevel_Demo.Enum;

namespace LogLevel_Demo.Model
{
    /// <summary>
    /// Contains details of Order.
    /// </summary>
    public class ORD01
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        public int D01F01 { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string D01F02 { get; set; }

        /// <summary>
        /// Pizza Type
        /// </summary>
        public enmPizzaType D01F03 { get; set; }

        /// <summary>
        /// Contact Number
        /// </summary>
        public long D01F04 { get; set; }

        /// <summary>
        /// Address details.
        /// </summary>
        public string D01F05 { get; set; }
    }
}
