namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for a Singleton Services.
    /// </summary>
    public interface ISingleton
    {
        /// <summary>
        /// Gets the ID of the singleton service.
        /// </summary>
        /// <returns>The ID of the singleton service.</returns>
        Guid GetId();
    }
}
