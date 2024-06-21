namespace FinalDemo_Advance_C_.Enums
{
    /// <summary>
    /// Enum representing different types of contacts(Supplier, Retailer, Wholesaler, Consumer).
    /// </summary>
    public enum enmContactType
    {
        /// <summary>
        /// Supplier
        /// </summary>
        Sp,

        /// <summary>
        /// Retailer
        /// </summary>
        Rt,

        /// <summary>
        /// Wholesaler
        /// </summary>
        Ws,

        /// <summary>
        /// Consumer
        /// </summary>
        Cs
    }


    /// <summary>
    /// Represents the types of transactions (Purchase, Sale).
    /// </summary>
    public enum enmTransactionType
    {
        /// <summary>
        /// Indicates a purchase transaction.
        /// </summary>
        P = 0,

        /// <summary>
        /// Indicates a sale transaction.
        /// </summary>
        S = 1,
    }


    /// <summary>
    /// Represents the roles that can be assigned to a user( Admin, DEO, Accountant)
    /// </summary>
    public enum enmUserRole
    {
        /// <summary>
        /// Admin
        /// </summary>
        Ad,

        /// <summary>
        /// DEO
        /// </summary>
        De,

        /// <summary>
        /// Accountant
        /// </summary>
        Ac
    }


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

}