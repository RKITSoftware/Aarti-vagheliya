using Caching.Models;
using System.Collections.Generic;

namespace Caching.Data
{
    /// <summary>
    /// This class provide data for states.
    /// </summary>
    public class BLStateData
    {
        /// <summary>
        /// This methods store object of State and related data.
        /// </summary>
        /// <returns></returns>
        public List<State> RetriveState()
        {
            List<State> objState = new List<State>()
            {
                new State{ StateId = 1, StateName = "Gujarat" , StateCode = "GJ" },
                new State{ StateId = 2, StateName = "Assam" , StateCode = "AS" },
                new State{ StateId = 3, StateName = "Bihar" , StateCode = "BH" },
                new State{ StateId = 4, StateName = "Chhattisgarh" , StateCode = "CG" },
                new State{ StateId = 5, StateName = "Goa" , StateCode = "GO" },
                new State{ StateId = 6, StateName = "Haryana" , StateCode = "HR" },
                new State{ StateId = 7, StateName = "Jharkhand" , StateCode = "JK" },
                new State{ StateId = 8, StateName = "Karnataka" , StateCode = "KN" },
                new State{ StateId = 9, StateName = "Kerala" , StateCode = "KR" },
                new State{ StateId = 10, StateName = "Maharashtra" , StateCode = "MH" },
                new State{ StateId = 11, StateName = "Manipur" , StateCode = "MN" },
                new State{ StateId = 12, StateName = "Meghalaya" , StateCode = "ML" },
                new State{ StateId = 13, StateName = "Mizoram" , StateCode = "MZ" },
                new State{ StateId = 14, StateName = "Odisha" , StateCode = "OD" },
                new State{ StateId = 15, StateName = "Punjab" , StateCode = "PJ" },
                new State{ StateId = 16, StateName = "Rajasthan" , StateCode = "RJ" },
                new State{ StateId = 17, StateName = "Sikkim" , StateCode = "SK" },
                new State{ StateId = 18, StateName = "Telangana" , StateCode = "TL" },
                new State{ StateId = 19, StateName = "Uttarakhand" , StateCode = "UK" },
                new State{ StateId = 20, StateName = "AndhraPradesh" , StateCode = "AP" },

            };
            return objState;
        }
    }
}