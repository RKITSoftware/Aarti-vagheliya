using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    public class USR01
    {
        /// <summary>
        /// User ID.
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string R01F02 { get; set; }   

        /// <summary>
        /// Password
        /// </summary>
        public string R01F03 { get; set; }   

        /// <summary>
        /// Email 
        /// </summary>
        public string R01F04 { get; set; } 
        
        /// <summary>
        /// User Role
        /// </summary>
        public enmUserRole R01F05 { get; set; }   
    }
}
