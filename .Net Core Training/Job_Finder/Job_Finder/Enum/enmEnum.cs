namespace Job_Finder.Enum
{
    /// <summary>
    /// Represents the operation types for CRUD operations (I: Insert, U: Update, D: Delete).
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

    /// <summary>
    /// Represents the type of company (P: Product-based, S: Service-based).
    /// </summary>
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

    /// <summary>
    /// Represents the role of a user (A: Admin, R: Recruiter, J: Job seeker).
    /// </summary>
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

    /// <summary>
    /// Represents the type of job (Ft: Full Time, Pt: Part Time, Rm: Remote, Fl: Freelance).
    /// </summary>
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

    /// <summary>
    /// Represents the status of a job application (Ap: Applied, Sh: Shortlisted, Is: Interview Scheduled, Pd: Pending, Sl: Selected, Rj: Rejected).
    /// </summary>
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

    /// <summary>
    /// Represents the gender of a person (M: Male, F: Female).
    /// </summary>
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
