namespace Dependency_Injection.Model
{
    /// <summary>
    /// this enum for gender.
    /// </summary>
    public enum enmGender
    {
        Male,
        Female
    }

    /// <summary>
    /// This enum for different dance types.
    /// </summary>
    public enum enmDanceType
    {
        Bharatanatyam,
        Kathak,
        Odissi,
        Kuchipudi,
        Kathakali,
        Mohiniyattam,
        Manipuri,
        Carnatic_Dance,
        Salsa,
        Ballet,
        Japanese_Traditional_Dance,
        Chinese_Classical_Dance,
    }

    /// <summary>
    /// This class describe properties of the dancer.
    /// </summary>
    public class DCR01
    {
        #region Public Properties

        /// <summary>
        /// Id of the Dancer
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// Name of the dancer
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Gender of the dancer
        /// </summary>
        public enmGender R01F03 { get; set; }

        /// <summary>
        /// Joining date of the dancer
        /// </summary>
        public DateTime R01F04 { get; set; }

        /// <summary>
        /// Dance type
        /// </summary>
        public enmDanceType R01F05 { get; set; }

        /// <summary>
        /// Duration of the learning.
        /// </summary>
        public double R01F06 { get; set; }

        #endregion
    }
}
