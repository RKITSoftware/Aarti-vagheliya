using Controller_Initialization.Model;

namespace Controller_Initialization.BusinessLogic
{
    /// <summary>
    /// This class contains business logic related to states.
    /// </summary>
    public class BLState
    {
        #region Private Member

        //Static counter for unique ID
        private static int _count = 0;

        // Static list of states initialized with some initial data
        private static List<STT01> _lstState = new List<STT01>
        {
            new STT01{ T01F01 = Counter(), T01F02 = "Gujarat", T01F03 = "GJ" },
            new STT01{ T01F01 = Counter(), T01F02 = "Rajasthan", T01F03 = "RJ" },
            new STT01{ T01F01 = Counter(), T01F02 = "Maharastra", T01F03 = "MH" }
        };

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves the list of states.
        /// </summary>
        /// <returns>The list of states.</returns>
        public List<STT01> GetList()
        {
            return _lstState;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Increases the count and returns it.
        /// </summary>
        /// <returns>The incremented count.</returns>
        private static int Counter()
        {
            return ++_count;
        }

        #endregion
    }
}
