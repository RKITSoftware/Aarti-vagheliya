using Dependency_Injection.Interface;
using Dependency_Injection.Model;

namespace Dependency_Injection.Service
{
    /// <summary>
    /// Service class responsible for managing dancer data.
    /// </summary>
    public class DancerService : IDancerService
    {
        #region Private Member

        /// <summary>
        /// Private static count for unique id.
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// Private static list to store dancers data.
        /// </summary>
        private static List<DCR01> _lstDancer = new List<DCR01>();

        /// <summary>
        /// For demo purpose
        /// </summary>
        private IHttpContextAccessor _context { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DancerService()
        {
            
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="context"></param>
        public DancerService(IHttpContextAccessor context)
        {
            _context = context;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves a dancer by their ID.
        /// </summary>
        /// <param name="id">The ID of the dancer to retrieve.</param>
        /// <returns>The dancer object if found; otherwise, null.</returns>
        public DCR01 GetDancerById(int id)
        {
            return _lstDancer.FirstOrDefault(x => x.R01F01 == id);
        }

        /// <summary>
        /// Retrieves a list of all dancers.
        /// </summary>
        /// <returns>A list of all dancers.</returns>
        public List<DCR01> GetDancers()
        {
            return _lstDancer;
        }

        /// <summary>
        /// Adds a new dancer to the list.
        /// </summary>
        /// <param name="objDCR01">The dancer object to add.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string AddNewdancer(DCR01 objDCR01)
        {
            objDCR01.R01F01 = Generator();
            _lstDancer.Add(objDCR01);
            return "success";
        }

        /// <summary>
        /// Updates an existing dancer.
        /// </summary>
        /// <param name="id">The ID of the dancer to update.</param>
        /// <param name="objDCR01">The updated dancer object.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string UpdateDancer(int id, DCR01 objDCR01)
        {
            int index = _lstDancer.FindIndex(x => x.R01F01 == id);

            if(index != -1)
            {
                _lstDancer[index] = objDCR01;
                return "Success.";
            }
            return "Fail.";
        }

        /// <summary>
        /// Deletes a dancer by their ID.
        /// </summary>
        /// <param name="id">The ID of the dancer to delete.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string DeleteDancer(int id)
        {
            int index = _lstDancer.FindIndex(x => x.R01F01 == id);
            
            if (index != -1)
            {
                _lstDancer.RemoveAt(index);
                return "Success.";
            }
            return "Fail.";

        }

        #endregion

        #region Private Method

        /// <summary>
        /// Generates a unique ID for a new dancer.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int Generator()
        {
            return ++_count;
        }

        #endregion
    }
}
