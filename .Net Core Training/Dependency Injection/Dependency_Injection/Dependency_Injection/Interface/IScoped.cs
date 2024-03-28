namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for a scoped service.
    /// </summary>
    public interface IScoped
    {
        /// <summary>
        /// Gets the ID of the scoped service.
        /// </summary>
        /// <returns>The ID of the scoped service.</returns>
        Guid GetId();
    }
}
