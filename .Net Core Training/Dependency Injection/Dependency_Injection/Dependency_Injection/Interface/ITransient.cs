namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for a transient services.
    /// </summary>
    public interface ITransient
    {
        /// <summary>
        /// Gets the ID of the transient service.
        /// </summary>
        /// <returns>The ID of the transient service.</returns>
        Guid GetId();
    }
}
