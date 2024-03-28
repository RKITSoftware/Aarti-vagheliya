using Dependency_Injection.Interface;

namespace Dependency_Injection.Service
{
    /// <summary>
    /// Implementation of service lifetimes for dependency injection.
    /// </summary>
    public class ServiceLifeTime : ISingleton, ITransient, IScoped
    {
        /// <summary>
        /// Declare private id member.
        /// </summary>
        private Guid _id;

        /// <summary>
        /// Constructor initializes a new instance of the ServiceLifeTime class and generates a unique identifier.
        /// </summary>
        public ServiceLifeTime()
        {
            _id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the unique identifier associated with the service instance.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        public Guid GetId()
        {
            return _id;
        }
    }
}
