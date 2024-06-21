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
    /// Represents the type of job (FT: Full Time, PT: Part Time, RM: Remote, FL: Freelance).
    /// </summary>
    public enum enmJobType
    {
        /// <summary>
        /// Full Time
        /// </summary>
        FT,

        /// <summary>
        /// Part time
        /// </summary>
        PT,

        /// <summary>
        /// Remote
        /// </summary>
        RM,

        /// <summary>
        /// Freelance
        /// </summary>
        FL
    }

    /// <summary>
    /// Represents the status of a job application (AP: Applied, SH: Shortlisted, IS: Interview Scheduled, PD: Pending, SL: Selected, RJ: Rejected).
    /// </summary>
    public enum enmJobApplicationStatus
    {
        /// <summary>
        /// Applied
        /// </summary>
        AP,

        /// <summary>
        /// Shortlisted
        /// </summary>
        SH,

        /// <summary>
        /// Interview Scheduled
        /// </summary>
        IS,

        /// <summary>
        /// Pending
        /// </summary>
        PD,

        /// <summary>
        /// Selected
        /// </summary>
        SL,

        /// <summary>
        /// Rejected
        /// </summary>
        RJ
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
