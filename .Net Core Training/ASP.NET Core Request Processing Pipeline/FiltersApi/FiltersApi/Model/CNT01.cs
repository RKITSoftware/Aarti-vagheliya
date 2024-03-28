namespace FiltersApi.Model
{
    /// <summary>
    /// This class represent properties of Country class.
    /// </summary>
    public class CNT01
    {
        /// <summary>
        /// Contry Id .
        /// </summary>
        public int T01F01 { get; set; }

        /// <summary>
        /// Country Name.
        /// </summary>
        public string T01F02 { get; set; }

        /// <summary>
        /// Country Code.
        /// </summary>
        public int T01F03 { get; set; }

        /// <summary>
        /// Population
        /// </summary>
        public long  T01F04 { get; set; }

        /// <summary>
        /// No. of States
        /// </summary>
        public int T01F05 { get; set; }

        /// <summary>
        /// Continent.
        /// </summary>
        public string T01F06 { get; set; }
    }
}
