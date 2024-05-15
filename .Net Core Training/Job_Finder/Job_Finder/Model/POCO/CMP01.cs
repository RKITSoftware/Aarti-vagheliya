using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    public class CMP01
    {
        /// <summary>
        /// Company Id.
        /// </summary>
        public int P01F01 { get; set; }

        /// <summary>
        /// Represent Company Name.
        /// </summary>
        public string P01F02 { get; set; }

        /// <summary>
        /// Website.
        /// </summary>
        public string P01F03 { get; set; }

        /// <summary>
        /// Location.
        /// </summary>
        public string P01F04 { get; set; }

        /// <summary>
        /// Capacity
        /// </summary>
        public int P01F05 { get; set; }

        /// <summary>
        /// Ratings.
        /// </summary>
        public decimal P01F06 { get; set; }

        /// <summary>
        /// Represent type of Company(P,S).
        /// </summary>
        public enmCompanyType P01F07 { get; set; }
    }
}
