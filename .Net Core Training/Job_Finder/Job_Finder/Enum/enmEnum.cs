namespace Job_Finder.Enum
{
    /// <summary>
    /// Represent Operation Type for crud(I, U, D).
    /// </summary>
    public enum enmOperationType
    {
        /// <summary>
        /// Insert
        /// </summary>
        I,

        /// <summary>
        /// Update
        /// </summary>
        U,

        /// <summary>
        /// Delete
        /// </summary>
        D
    }


    public enum enmCompanyType
    {
        /// <summary>
        /// Product_base
        /// </summary>
        P,

        /// <summary>
        /// Service_base
        /// </summary>
        S
    }

    public enum enmUserRole
    {
        /// <summary>
        /// Admin
        /// </summary>
        A,

        /// <summary>
        /// Recruiter
        /// </summary>
        R,

        /// <summary>
        /// Job seeker
        /// </summary>
        J
    }

    public enum enmJobType
    {
        /// <summary>
        /// Full Time
        /// </summary>
        Ft,

        /// <summary>
        /// Part time
        /// </summary>
        Pt,

        /// <summary>
        /// Remote
        /// </summary>
        Rm,

        /// <summary>
        /// Freelance
        /// </summary>
        Fl
    }

    public enum enmJobApplicationStatus
    {
        /// <summary>
        /// Applied
        /// </summary>
        Ap,

        /// <summary>
        /// Shortlisted
        /// </summary>
        Sh,

        /// <summary>
        /// Interview Scheduled
        /// </summary>
        Is,

        /// <summary>
        /// Pending
        /// </summary>
        Pd,

        /// <summary>
        /// Selected
        /// </summary>
        Sl,

        /// <summary>
        /// Rejected
        /// </summary>
        Rj
    }

    public enum enmGender
    {
        /// <summary>
        /// Male
        /// </summary>
        M,

        /// <summary>
        /// Female
        /// </summary>
        F
    }

}
