﻿using System.Collections.Generic;

namespace Token_Custom.Models
{
    /// <summary>
    /// Class for State data
    /// </summary>
    public class StateDate
    {
        /// <summary>
        /// Method for retive state data from dictionary
        /// </summary>
        /// <returns>Dictionary</returns>
        public static Dictionary<int, string> RetriveStateData()
        {
            // Dictionary to store state data with ID as the key and name as the value.
            Dictionary<int, string> objState = new Dictionary<int, string>();

            // Adding state data to the dictionary.
            objState.Add(1, "Gujarat");
            objState.Add(2, "Assam");
            objState.Add(3, "Bihar");
            objState.Add(4, "Chhattisgarh");
            objState.Add(5, "Goa");
            objState.Add(6, "Haryana");
            objState.Add(8, "Jharkhand");
            objState.Add(9, "Karnataka");
            objState.Add(10, "Kerala");
            objState.Add(11, "Maharashtra");
            objState.Add(12, "Manipur");
            objState.Add(13, "Meghalaya");
            objState.Add(14, "Mizoram");
            objState.Add(15, "Odisha");
            objState.Add(16, "Punjab");
            objState.Add(17, "Rajasthan");
            objState.Add(18, "Sikkim");
            objState.Add(19, "Telangana");
            objState.Add(20, "Uttarakhand");

            // Returning the populated state data dictionary.
            return objState;
        }
    }
}