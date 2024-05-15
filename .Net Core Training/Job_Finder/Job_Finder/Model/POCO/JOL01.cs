using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    public class JOL01
    {
        /// <summary>
        /// Job ID.
        /// </summary>
        public int L01F01 { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        public string L01F02 { get; set; }

        /// <summary>
        /// Company id
        /// </summary>
        public int L01F03 { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Represent Job type(Ft, Pt, Rm, Fl)
        /// </summary>
        public enmJobType L01F05 { get; set; }

        /// <summary>
        /// Requirments
        /// </summary>
        public dynamic L01F06 { get; set; }
    }
}
