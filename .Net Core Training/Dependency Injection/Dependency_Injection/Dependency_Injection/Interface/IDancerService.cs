using Dependency_Injection.Model;

namespace Dependency_Injection.Interface
{
    /// <summary>
    /// Interface for manage Dancer Services.
    /// </summary>
    public interface IDancerService
    {
        /// <summary>
        /// retirve all the dancer's data from the static list. 
        /// </summary>
        /// <returns>list of dancers</returns>
        List<DCR01> GetDancers();

        /// <summary>
        /// get one dancer's details from the list
        /// </summary>
        /// <param name="id">Id of the dancer object</param>
        /// <returns>returns one dancer's data.</returns>
        DCR01 GetDancerById(int id);

        /// <summary>
        /// Add new dancer to the list.
        /// </summary>
        /// <param name="objDCR01">object which is add to the list</param>
        /// <returns>returns success message.</returns>
        string AddNewdancer(DCR01 objDCR01);

        /// <summary>
        /// Update data of Dancer
        /// </summary>
        /// <param name="id">Id of the dancer</param>
        /// <param name="objDCR01">Updated Object.</param>
        /// <returns></returns>
        string UpdateDancer(int id, DCR01 objDCR01);

        /// <summary>
        /// Delete dancer from the list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string DeleteDancer(int id);
    }
}
