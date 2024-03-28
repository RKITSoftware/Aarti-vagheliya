namespace FiltersApi.Model
{
    /// <summary>
    /// Enum for User role.
    /// </summary>
    public enum enmUserRole
    {
        Admin = 0,
        Guest = 1
    }

    /// <summary>
    /// This class represent properties of User Model.
    /// </summary>
    public class USR01
    {
        /// <summary>
        /// UserId 
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// PassWord
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>
        public enmUserRole R01F04 { get; set; }
    }
}
